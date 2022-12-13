using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LocalGoods.BLL.Services.Interfaces;
using LocalGoods.PL.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LocalGoods.PL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController: ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsersController(
            IUserService userService, 
            IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<UserResponse>>(users));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var user = await _userService.GetByIdAsync(id);
            return Ok(_mapper.Map<UserResponse>(user));
        }

        [HttpGet("{id}/roles")]
        public async Task<IActionResult> GetRolesByUserId(Guid id)
        {
            var roles = await _userService.GetRolesByUserId(id);
            return Ok(roles);
        }
    }
}