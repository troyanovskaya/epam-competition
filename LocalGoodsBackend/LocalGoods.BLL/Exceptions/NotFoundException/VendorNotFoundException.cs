using System;

namespace LocalGoods.BLL.Exceptions.NotFoundException
{
    public class VendorNotFoundException : NotFoundException
    {
        public VendorNotFoundException() { }

        public VendorNotFoundException(Guid id) : base($"Vendor with id {id} was not found") { }
    }
}
