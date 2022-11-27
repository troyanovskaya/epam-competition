using System;

namespace LocalGoods.DAL.Entities
{
    public abstract class EntityBase: ISqlEntity
    {
        public Guid Id { get; set; }
    }
}