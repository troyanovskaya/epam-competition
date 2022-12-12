﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LocalGoods.BLL.Services.Interfaces;
using LocalGoods.PL.Models.UnitType;
using Microsoft.AspNetCore.Mvc;

namespace LocalGoods.PL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UnitTypesController: ControllerBase
    {
        private readonly IUnitTypeService _unitTypeService;
        private readonly IMapper _mapper;

        public UnitTypesController(
            IUnitTypeService unitTypeService, 
            IMapper mapper)
        {
            _unitTypeService = unitTypeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var unitTypes = await _unitTypeService.GetAllUnitTypesAsync();
            return Ok(_mapper.Map<IEnumerable<UnitTypeResponse>>(unitTypes));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var unitType = await _unitTypeService.GetUnitTypeByIdAsync(id);
            return Ok(_mapper.Map<UnitTypeResponse>(unitType));
        }
    }
}