using System;

namespace LocalGoods.BLL.Exceptions.BadRequestException
{
    public class BadRequestException : Exception
    {
        public BadRequestException() : base() { }

        public BadRequestException(string message) : base(message) { }
    }
}
