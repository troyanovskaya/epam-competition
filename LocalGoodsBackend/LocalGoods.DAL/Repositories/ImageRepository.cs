using LocalGoods.DAL.Contexts;
using LocalGoods.DAL.Entities;
using LocalGoods.DAL.Repositories.Interfaces;
using System;

namespace LocalGoods.DAL.Repositories
{
    public class ImageRepository : BaseRepository<Guid, Image>, IImageRepository
    {
        public ImageRepository(LocalGoodsDbContext context) : base(context)
        {
        }
    }
}
