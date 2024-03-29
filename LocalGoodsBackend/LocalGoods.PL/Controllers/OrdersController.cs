﻿using AutoMapper;
using FluentValidation;
using LocalGoods.BLL.Models.Order;
using LocalGoods.BLL.Models.OrderStatus;
using LocalGoods.BLL.Services.Interfaces;
using LocalGoods.PL.Models.Order;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocalGoods.PL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;
        private readonly IValidator<CreateOrderModel> _createOrderValidator;

        public OrdersController(IMapper mapper, IOrderService orderService,
            IValidator<CreateOrderModel> createOrderValidator)
        {
            _orderService = orderService;
            _mapper = mapper;
            _createOrderValidator = createOrderValidator;
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<OrderModel>))]
        public async Task<ActionResult> GetAll()
        {
            var orders = await _orderService.GetAllAsync();

            return Ok(orders);
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Buyer, Vendor")]
        [HttpGet("current-user")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<OrderModel>))]
        public async Task<ActionResult> GetAllCurrentUserOrdersByOrderStatusIds([FromQuery] OrderRequest orderRequest)
        {
            var orders = await _orderService.GetAllCurrentUserOrdersByOrderStatusIdsAsync(orderRequest.OrderStatusIds);

            return Ok(orders);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrderModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetById(Guid id)
        {
            var order = await _orderService.GetByIdAsync(id);

            return Ok(order);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("statuses")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<OrderStatusModel>))]
        public async Task<ActionResult> GetOrderStatuses()
        {
            var orderStatuses = await _orderService.GetAllOrderStatusesAsync();

            return Ok(orderStatuses);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("statuses/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(OrderStatusModel))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetOrderStatuseByid(Guid id)
        {
            var orderStatuse = await _orderService.GetOrderStatuseByidAsync(id);

            return Ok(orderStatuse);
        }

        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Add([FromBody] CreateOrderModel createOrderModel)
        {
            await _createOrderValidator.ValidateAndThrowAsync(createOrderModel);

            var createdOrder = await _orderService.CreateAsync(createOrderModel);

            return CreatedAtAction(nameof(GetById), new { id = createdOrder.Id }, createdOrder);
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Vendor")]
        [HttpPut("{id}/status")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> ChangeOrderStatus(Guid id)
        {
            await _orderService.ChangeStatusAsync(id);

            return Ok();
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Vendor")]
        [HttpPut("{id}/cancel")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> CancelOrder(Guid id)
        {
            await _orderService.CancelAsync(id);

            return Ok();
        }
    }
}
