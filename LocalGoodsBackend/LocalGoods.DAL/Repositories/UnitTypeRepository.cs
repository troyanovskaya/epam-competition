using LocalGoods.DAL.Contexts;
using LocalGoods.DAL.Entities;
using LocalGoods.DAL.Repositories.Interfaces;
using System;

namespace LocalGoods.DAL.Repositories
{
    public class UnitTypeRepository : BaseRepository<Guid, UnitType>, IUnitTypeRepository
    {
        public UnitTypeRepository(LocalGoodsDbContext context) : base(context)
        {
        }
    }
}
