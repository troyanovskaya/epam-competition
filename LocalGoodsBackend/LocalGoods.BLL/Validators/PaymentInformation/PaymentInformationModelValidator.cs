using FluentValidation;
using LocalGoods.BLL.Models.PaymentMethod;

namespace LocalGoods.BLL.Validators.PaymentInformation
{
    public class PaymentInformationModelValidator : AbstractValidator<PaymentInformationModel>
    {
        public PaymentInformationModelValidator()
        {
            RuleFor(pim => pim.PaymentMethodId).NotEmpty();
        }
    }
}
