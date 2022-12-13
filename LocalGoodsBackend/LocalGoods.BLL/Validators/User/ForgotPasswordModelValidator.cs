using FluentValidation;
using LocalGoods.BLL.Models.Auth;

namespace LocalGoods.BLL.Validators.User
{
    public class ForgotPasswordModelValidator : AbstractValidator<ForgotPasswordModel>
    {
        public ForgotPasswordModelValidator()
        {
            RuleFor(fpm => fpm.Email).NotEmpty().EmailAddress();
        }
    }
}
