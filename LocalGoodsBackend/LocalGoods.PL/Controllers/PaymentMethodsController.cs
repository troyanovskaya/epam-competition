using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LocalGoods.BLL.Services.Interfaces;
using LocalGoods.PL.Models.DeliveryMethod;
using LocalGoods.PL.Models.PaymentMethod;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LocalGoods.PL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentMethodsController: ControllerBase
    {
        private readonly IPaymentMethodService _paymentMethodService;
        private readonly IMapper _mapper;

        public PaymentMethodsController(
            IPaymentMethodService paymentMethodService, 
            IMapper mapper)
        {
            _paymentMethodService = paymentMethodService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<PaymentMethodResponse>))]
        public async Task<IActionResult> GetAll()
        {
            var paymentMethods = await _paymentMethodService.GetAllPaymentMethodsAsync();
            return Ok(_mapper.Map<IEnumerable<PaymentMethodResponse>>(paymentMethods));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaymentMethodResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var paymentMethod = await _paymentMethodService.GetPaymentMethodByIdAsync(id);
            return Ok(_mapper.Map<PaymentMethodResponse>(paymentMethod));
        }
    }
}