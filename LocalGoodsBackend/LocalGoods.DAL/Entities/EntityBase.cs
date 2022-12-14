using System;

namespace LocalGoods.DAL.Entities
{
    public abstract class EntityBase<TId>: ISqlEntity
    {
        public TId Id { get; set; }
    }
}