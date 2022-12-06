namespace LocalGoods.BLL.Exceptions.BadRequestException
{
    public class AuthException : BadRequestException
    {
        public AuthException() : base() { }

        public AuthException(string message) : base(message) { }
    }
}
