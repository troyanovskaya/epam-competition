using LocalGoods.BLL.Models.Product;
using LocalGoods.BLL.Models.Vendor;
using LocalGoods.BLL.Services.Interfaces;
using LocalGoods.DAL.Entities;
using LocalGoods.Shared.FilterModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocalGoods.PL.Controllers
{
    [ApiController]
    [Route(("api/[controller]"))]
    public class VendorsController : ControllerBase
    {
        private readonly IVendorService _vendorService;
        private readonly IProductService _productService;

        public VendorsController(IVendorService vendorService, IProductService productService)
        {
            _vendorService = vendorService;
            _productService = productService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<VendorModel>))]
        public async Task<ActionResult> GetAll([FromQuery] VendorFilterModel vendorFilterModel)
        {
            var vendors = await _vendorService.GetAllByFilterAsync(vendorFilterModel);

            return Ok(vendors);
        }

        [HttpGet("{id}/products")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ProductModel>))]
        public async Task<ActionResult> GetProductsByVendorId(Guid id)
        {
            var products = await _productService.GetByVendorIdAsync(id);

            return Ok(products);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VendorModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetById(Guid id)
        {
            var vendor = await _vendorService.GetByIdAsync(id);

            return Ok(vendor);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Add([FromBody] CreateVendorModel createVendorModel)
        {
            var createdVendor = await _vendorService.CreateAsync(createVendorModel);

            return CreatedAtAction(nameof(GetById), new { id = createdVendor.Id }, createdVendor);
        }
    }
}
