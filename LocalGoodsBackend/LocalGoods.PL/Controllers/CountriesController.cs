using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LocalGoods.BLL.Models.City;
using LocalGoods.BLL.Models.Country;
using LocalGoods.BLL.Models.Order;
using LocalGoods.BLL.Models.Product;
using LocalGoods.BLL.Services;
using LocalGoods.BLL.Services.Interfaces;
using LocalGoods.PL.Models.Country;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LocalGoods.PL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryService _countryService;
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public CountriesController(
            ICountryService countryService,
            IProductService productService,
            IMapper mapper)
        {
            _countryService = countryService;
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CountryModel>))]
        public async Task<IActionResult> GetAll()
        {
            var countries = await _countryService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<CountryResponse>>(countries));
        }
        
        [HttpGet("{id}/cities")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CityModel>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCitiesByCountryId(Guid id)
        {
            var cities = await _countryService.GetAllCitiesByCountryIdAsync(id);

            return Ok(cities);
        }

        [HttpGet("{id}/products")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ProductModel>))]
        public async Task<IActionResult> GetProductsByCountryId(Guid id)
        {
            var products = await _productService.GetByCountryIdAsync(id);

            return Ok(products);
        }
    }
}