using LocalGoods.DAL.Contexts;
using LocalGoods.DAL.Entities;
using LocalGoods.DAL.Repositories.Interfaces;
using System;

namespace LocalGoods.DAL.Repositories
{
    public class CountryRepository : BaseRepository<Guid, Country>, ICountryRepository
    {
        public CountryRepository(LocalGoodsDbContext context) : base(context)
        {
        }
    }
}
