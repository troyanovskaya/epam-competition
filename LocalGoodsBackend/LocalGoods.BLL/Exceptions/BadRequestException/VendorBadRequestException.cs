namespace LocalGoods.BLL.Exceptions.BadRequestException
{
    public class VendorBadRequestException : BadRequestException
    {
        public VendorBadRequestException() : base() { }

        public VendorBadRequestException(string message) : base(message) { }
    }
}
