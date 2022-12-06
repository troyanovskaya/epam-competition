using System;

namespace LocalGoods.BLL.Exceptions.NotFoundException
{
    public class CityNotFoundException : NotFoundException
    {
        public CityNotFoundException() : base("City was not found") { }

        public CityNotFoundException(Guid id) : base($"City with id {id} was not found") { }
    }
}
