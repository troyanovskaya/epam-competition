using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LocalGoods.BLL.Exceptions.NotFoundException;
using LocalGoods.BLL.Models.City;
using LocalGoods.BLL.Models.Country;
using LocalGoods.BLL.Services.Interfaces;
using LocalGoods.DAL.Repositories.Interfaces;

namespace LocalGoods.BLL.Services
{
    public class CountryService: ICountryService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly IMapper _mapper;

        public CountryService(
            ICountryRepository countryRepository,
            IMapper mapper)
        {
            _countryRepository = countryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CountryModel>> GetAllAsync()
        {
            var countries = await _countryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CountryModel>>(countries);
        }

        public async Task<IEnumerable<CityModel>> GetAllCitiesByCountryIdAsync(Guid countryId)
        {
            var country = await _countryRepository.GetByIdAsync(countryId);

            if (country is null)
            {
                throw new CountryNotFoundException(countryId);
            }

            return _mapper.Map<IEnumerable<CityModel>>(country.Cities);
        }
    }
}