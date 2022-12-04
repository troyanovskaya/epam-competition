using LocalGoods.BLL.Services.Interfaces;
using LocalGoods.Shared.FilterModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using LocalGoods.BLL.Models.Product;

namespace LocalGoods.PL.Controllers
{
    [ApiController]
    [Route(("api/[controller]"))]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Add([FromBody] CreateProductModel createProductModel)
        {
            var createdProduct = await _productService.CreateAsync(createProductModel);

            var location = Url.Action(nameof(GetById), new { id = createdProduct.Id }) ?? $"/{createdProduct.Id}";
            return Created(location, createdProduct);
        }
    }
}
