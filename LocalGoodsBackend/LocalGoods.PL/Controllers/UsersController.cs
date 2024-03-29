﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LocalGoods.BLL.Models.Order;
using LocalGoods.BLL.Services;
using LocalGoods.BLL.Services.Interfaces;
using LocalGoods.PL.Models.UnitType;
using LocalGoods.PL.Models.User;
using LocalGoods.PL.Models.Vendor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LocalGoods.PL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IOrderService _orderService;
        private readonly IVendorService _vendorService;
        private readonly IMapper _mapper;

        public UsersController(
            IUserService userService,
            IMapper mapper,
            IOrderService orderService,
            IVendorService vendorService)
        {
            _userService = userService;
            _mapper = mapper;
            _orderService = orderService;
            _vendorService = vendorService;
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Admin")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<UserResponse>))]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<UserResponse>>(users));
        }

        [Authorize(AuthenticationSchemes = "Bearer", Roles = "Buyer, Vendor")]
        [HttpGet("{id}/orders")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<OrderModel>))]
        public async Task<IActionResult> GetUserOrders(Guid id)
        {
            var orders = await _orderService.GetByUserIdAsync(id);
            return Ok(_mapper.Map<IEnumerable<OrderModel>>(orders));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await _userService.GetByIdAsync(id);
            return Ok(_mapper.Map<UserResponse>(user));
        }

        [HttpGet("{id}/vendor")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(VendorResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetVendorByUserId(Guid id)
        {
            var vendor = await _vendorService.GetByUserIdAsync(id);
            return Ok(_mapper.Map<VendorResponse>(vendor));
        }

        [HttpGet("{id}/roles")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<string>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetRolesByUserId(Guid id)
        {
            var roles = await _userService.GetRolesByUserId(id);
            return Ok(roles);
        }
    }
}