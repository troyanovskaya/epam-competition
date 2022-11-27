using System;
using LocalGoods.DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LocalGoods.DAL.Contexts
{
    public class LocalGoodsDbContext: IdentityDbContext<User, Role, Guid>
    {
        public LocalGoodsDbContext(DbContextOptions<LocalGoodsDbContext> options): base(options){}
    }
}