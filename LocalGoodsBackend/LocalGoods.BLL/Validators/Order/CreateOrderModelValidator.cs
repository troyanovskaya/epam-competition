using FluentValidation;
using LocalGoods.BLL.Models.Order;
using LocalGoods.BLL.Validators.OrderDetails;

namespace LocalGoods.BLL.Validators.Order
{
    public class CreateOrderModelValidator : AbstractValidator<CreateOrderModel>
    {
        public CreateOrderModelValidator()
        {
            RuleFor(cvm => cvm.PaymentMethodId).NotEmpty();
            RuleFor(cvm => cvm.DeliveryMethodId).NotEmpty();
            RuleFor(cvm => cvm.DeliveryInformation).Length(0, 255);
            RuleFor(cvm => cvm.OrderDetails).NotNull();
            RuleForEach(cvm => cvm.OrderDetails).NotNull().SetValidator(new CreateOrderDetailsModelValidator());
        }
    }
}
