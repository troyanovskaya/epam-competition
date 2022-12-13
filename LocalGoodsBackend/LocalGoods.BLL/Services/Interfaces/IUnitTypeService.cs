using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LocalGoods.BLL.Models.UnitType;

namespace LocalGoods.BLL.Services.Interfaces
{
    public interface IUnitTypeService
    {
        Task<IEnumerable<UnitTypeModel>> GetAllUnitTypesAsync();
        Task<UnitTypeModel> GetUnitTypeByIdAsync(Guid id);
    }
}