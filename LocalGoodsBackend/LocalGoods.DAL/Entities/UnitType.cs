using System;

namespace LocalGoods.DAL.Entities
{
    public class UnitType: EntityBase<Guid>
    {
        public string Name { get; set; }
    }
}