using LocalGoods.BLL.Models.City;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocalGoods.BLL.Services.Interfaces
{
    public interface ICityService
    {
        Task<IEnumerable<CityModel>> GetByCountryId(Guid id);
    }
}
