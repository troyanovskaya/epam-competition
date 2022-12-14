using LocalGoods.BLL.Services.Interfaces;
using LocalGoods.Shared.FilterModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using LocalGoods.BLL.Models.Product;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;

namespace LocalGoods.PL.Controllers
{
    [ApiController]
    [Route(("api/[controller]"))]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IValidator<CreateProductModel> _createProductValidator;

        public ProductsController(IProductService productService,
            IValidator<CreateProductModel> createProductValidator)
        {
            _productService = productService;
            _createProductValidator = createProductValidator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ProductModel>))]
        public async Task<ActionResult> GetAll([FromQuery] ProductFilterModel productFilterModel)
        {
            var products = await _productService.GetAllByFilterAsync(productFilterModel);

            return Ok(products);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetById(Guid id)
        {
            var product = await _productService.GetByIdAsync(id);

            return Ok(product);
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Buyer, Vendor")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Add([FromBody] CreateProductModel createProductModel)
        {
            await _createProductValidator.ValidateAndThrowAsync(createProductModel);

            var createdProduct = await _productService.CreateAsync(createProductModel);

            return CreatedAtAction(nameof(GetById), new { id = createdProduct.Id }, createdProduct);
        }
        
        [Authorize(Roles = "Vendor")]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Put(EditProductModel model)
        {
            await _productService.EditProductAsync(model);
            return NoContent();
        }

        [Authorize(Roles = "Vendor")]
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _productService.DeleteProductAsync(id);
            return NoContent();
        }
    }
}
