using System;

namespace LocalGoods.BLL.Exceptions.BadRequestException
{
    public class BadRequestException : Exception
    {
        public BadRequestException() { }

        public BadRequestException(string message) : base(message) { }
    }
}
