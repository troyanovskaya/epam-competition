using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LocalGoods.BLL.Models.UnitType;
using LocalGoods.BLL.Services.Interfaces;
using LocalGoods.DAL.Repositories.Interfaces;

namespace LocalGoods.BLL.Services
{
    public class UnitTypeService: IUnitTypeService
    {
        private readonly IUnitTypeRepository _unitTypeRepository;
        private readonly IMapper _mapper;

        public UnitTypeService(
            IUnitTypeRepository unitTypeRepository, 
            IMapper mapper)
        {
            _unitTypeRepository = unitTypeRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UnitTypeModel>> GetAllUnitTypesAsync()
        {
            var unitTypes = await _unitTypeRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UnitTypeModel>>(unitTypes);
        }

        public async Task<UnitTypeModel> GetUnitTypeByIdAsync(Guid id)
        {
            var unitType = await _unitTypeRepository.GetByIdAsync(id);
            return _mapper.Map<UnitTypeModel>(unitType);
        }
    }
}