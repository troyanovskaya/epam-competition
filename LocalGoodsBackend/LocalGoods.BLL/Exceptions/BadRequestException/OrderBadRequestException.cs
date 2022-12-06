namespace LocalGoods.BLL.Exceptions.BadRequestException
{
    public class OrderBadRequestException : BadRequestException
    {
        public OrderBadRequestException() : base() { }

        public OrderBadRequestException(string message) : base(message) { }
    }
}
