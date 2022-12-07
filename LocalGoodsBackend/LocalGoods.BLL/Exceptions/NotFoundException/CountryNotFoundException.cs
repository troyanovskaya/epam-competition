using System;

namespace LocalGoods.BLL.Exceptions.NotFoundException
{
    public class CountryNotFoundException : NotFoundException
    {
        public CountryNotFoundException() : base("Country was not found") { }

        public CountryNotFoundException(Guid id) : base($"Country with id {id} was not found") { }
    }
}
