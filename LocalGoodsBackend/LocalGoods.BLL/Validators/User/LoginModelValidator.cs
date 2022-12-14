using FluentValidation;
using LocalGoods.BLL.Models.Auth;

namespace LocalGoods.BLL.Validators.User
{
    public class LoginModelValidator : AbstractValidator<LoginModel>
    {
        public LoginModelValidator()
        {
            RuleFor(lm => lm.Email).NotEmpty().EmailAddress();
            RuleFor(lm => lm.Password).NotEmpty().Length(8, 100).Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[A-Za-z\\d@?&\\/]{8,}$");
        }
    }
}
