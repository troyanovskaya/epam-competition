using LocalGoods.DAL.Contexts;
using LocalGoods.DAL.Entities;
using LocalGoods.DAL.Repositories.Interfaces;
using System;

namespace LocalGoods.DAL.Repositories
{
    public class CityRepository : BaseRepository<Guid, City>, ICityRepository
    {
        public CityRepository(LocalGoodsDbContext context) : base(context)
        {
        }
    }
}
