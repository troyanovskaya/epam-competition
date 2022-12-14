namespace LocalGoods.BLL.Exceptions.BadRequestException
{
    public class ProductBadRequestException : BadRequestException
    {
        public ProductBadRequestException() : base() { }

        public ProductBadRequestException(string message) : base(message) { }
    }
}
