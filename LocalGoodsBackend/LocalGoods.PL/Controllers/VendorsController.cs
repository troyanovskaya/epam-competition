using LocalGoods.BLL.Models.Filters;
using LocalGoods.BLL.Models.Vendor;
using LocalGoods.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> Add([FromBody] CreateVendorModel createVendorModel)
        {
            await _vendorService.CreateAsync(createVendorModel);

            return Ok();
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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> GetById(Guid id)
        {
            var vendor = await _vendorService.GetByIdAsync(id);

            return Ok(vendor);
        }
    }
}
