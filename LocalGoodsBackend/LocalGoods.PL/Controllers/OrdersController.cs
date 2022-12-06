using AutoMapper;
using LocalGoods.BLL.Models.Order;
using LocalGoods.BLL.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LocalGoods.PL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;

        public OrdersController(IMapper mapper, IOrderService orderService)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<OrderModel>))]
        public async Task<ActionResult> GetAll()
        {
            var orders = await _orderService.GetAllAsync();

            return Ok(orders);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrderModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetById(Guid id)
        {
            var order = await _orderService.GetByIdAsync(id);

            return Ok(order);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Add([FromBody] CreateOrderModel createOrderModel)
        {
            var createdOrder = await _orderService.CreateAsync(createOrderModel);

            return CreatedAtAction(nameof(GetById), new { id = createdOrder.Id }, createdOrder);
        }
    }
}
