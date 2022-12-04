using System;

namespace LocalGoods.BLL.Exceptions.NotFoundException
{
    public class CityNotFoundException : NotFoundException
    {
        public CityNotFoundException() { }

        public CityNotFoundException(Guid id) : base($"City with id {id} was not found") { }
    }
}
