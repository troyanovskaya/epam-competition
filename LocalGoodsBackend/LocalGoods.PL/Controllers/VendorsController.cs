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

        public VendorsController(IVendorService vendorService)
        {
            _vendorService = vendorService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<VendorModel>))]
        public async Task<ActionResult> GetAll([FromQuery] VendorFilterModel vendorFilterModel)
        {
            var vendors = await _vendorService.GetAllByFilterAsync(vendorFilterModel);

            return Ok(vendors);
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

            var location = Url.Action(nameof(GetById), new { id = createdVendor.Id }) ?? $"/{createdVendor.Id}";
            return Created(location, createdVendor);
        }
    }
}
