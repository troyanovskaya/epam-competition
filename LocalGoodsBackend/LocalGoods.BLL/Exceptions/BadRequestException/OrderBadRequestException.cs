namespace LocalGoods.BLL.Exceptions.BadRequestException
{
    public class OrderBadRequestException : BadRequestException
    {
        public OrderBadRequestException() { }

        public OrderBadRequestException(string message) : base(message) { }
    }
}
