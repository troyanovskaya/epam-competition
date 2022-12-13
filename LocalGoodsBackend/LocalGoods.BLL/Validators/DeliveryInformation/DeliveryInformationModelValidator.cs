using FluentValidation;
using LocalGoods.BLL.Models.DeliveryMethod;

namespace LocalGoods.BLL.Validators.DeliveryInformation
{
    public class DeliveryInformationModelValidator : AbstractValidator<DeliveryInformationModel>
    {
        public DeliveryInformationModelValidator()
        {
            RuleFor(dim => dim.DeliveryMethodId).NotEmpty();
            RuleFor(dim => dim.Information).NotEmpty();
        }
    }
}
