using System;

namespace LocalGoods.BLL.Exceptions.NotFoundException
{
    public class NotFoundException : Exception
    {
        public NotFoundException() { }

        public NotFoundException(string message) : base(message) { }
    }
}
