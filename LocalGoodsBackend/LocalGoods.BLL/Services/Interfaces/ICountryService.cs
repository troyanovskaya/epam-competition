using LocalGoods.BLL.Models.Country;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LocalGoods.BLL.Services.Interfaces
{
    public interface ICountryService
    {
        Task<IEnumerable<CountryModel>> GetAllAsync();
    }
}
