using FluentValidation;
using LocalGoods.BLL.Models.Auth;

namespace LocalGoods.BLL.Validators.User
{
    public class SignupModelValidator : AbstractValidator<SignupModel>
    {
        public SignupModelValidator()
        {
            RuleFor(sm => sm.Email).NotEmpty().EmailAddress();
            RuleFor(sm => sm.FirstName).NotEmpty().Length(1, 50);
            RuleFor(sm => sm.LastName).NotEmpty().Length(1, 50);
            RuleFor(sm => sm.PhoneNumber).NotEmpty().Length(11, 15).Matches("^\\+[0-9]*$");
            RuleFor(sm => sm.Password).NotEmpty().Length(8, 100).Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[A-Za-z\\d@?&\\/]{8,}$");
            RuleFor(sm => sm.AddressInformation).NotEmpty().Length(5, 200);
            RuleFor(sm => sm.CityId).NotEmpty();
        }
    }
}
