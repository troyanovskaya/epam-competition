namespace LocalGoods.BLL.Exceptions.BadRequestException
{
    public class AuthException : BadRequestException
    {
        public AuthException() { }

        public AuthException(string message) : base(message) { }
    }
}
