using FluentValidation;
using LocalGoods.BLL.Models.OrderDetails;

namespace LocalGoods.BLL.Validators.OrderDetails
{
    public class CreateOrderDetailsModelValidator : AbstractValidator<CreateOrderDetailsModel>
    {
        public CreateOrderDetailsModelValidator()
        {
            RuleFor(codm => codm.Amount).NotNull().GreaterThan(0);
            RuleFor(codm => codm.ProductId).NotEmpty();
        }
    }
}
