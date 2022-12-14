using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LocalGoods.BLL.Services.Interfaces;
using LocalGoods.PL.Models.Category;
using LocalGoods.PL.Models.DeliveryMethod;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LocalGoods.PL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeliveryMethodsController: ControllerBase
    {
        private readonly IDeliveryMethodService _deliveryMethodService;
        private readonly IMapper _mapper;

        public DeliveryMethodsController(
            IDeliveryMethodService deliveryMethodService, 
            IMapper mapper)
        {
            _deliveryMethodService = deliveryMethodService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<DeliveryMethodResponse>))]
        public async Task<IActionResult> GetAll()
        {
            var deliveryMethods = await _deliveryMethodService.GetAllDeliveryMethodsAsync();
            return Ok(_mapper.Map<IEnumerable<DeliveryMethodResponse>>(deliveryMethods));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DeliveryMethodResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var deliveryMethod = await _deliveryMethodService.GetDeliveryMethodByIdAsync(id);
            return Ok(_mapper.Map<DeliveryMethodResponse>(deliveryMethod));
        }
    }
}