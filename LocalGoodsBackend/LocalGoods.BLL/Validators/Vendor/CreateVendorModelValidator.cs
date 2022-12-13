using FluentValidation;
using LocalGoods.BLL.Models.Vendor;
using LocalGoods.BLL.Validators.DeliveryInformation;
using LocalGoods.BLL.Validators.PaymentInformation;

namespace LocalGoods.BLL.Validators.Vendor
{
    public class CreateVendorModelValidator : AbstractValidator<CreateVendorModel>
    {
        public CreateVendorModelValidator()
        {
            RuleFor(cvm => cvm.Name).NotEmpty().Length(5, 50).Matches("^[A-Za-z0-9 _]*[A-Za-z0-9][A-Za-z0-9 _]*$");
            RuleFor(cvm => cvm.ViberNumber).Length(11, 15).Matches("^[0-9]*$");
            RuleFor(cvm => cvm.TelegramName).Length(5, 100);
            RuleFor(cvm => cvm.InstagramName).Length(5, 255);
            RuleFor(cvm => cvm.PaymentMethods).NotNull();
            RuleForEach(cvm => cvm.PaymentMethods).NotNull().SetValidator(new PaymentInformationModelValidator());
            RuleFor(cvm => cvm.DeliveryMethods).NotNull();
            RuleForEach(cvm => cvm.DeliveryMethods).NotNull().SetValidator(new DeliveryInformationModelValidator());
        }
    }
}
