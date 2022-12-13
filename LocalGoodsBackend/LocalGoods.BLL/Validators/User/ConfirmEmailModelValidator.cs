using FluentValidation;
using LocalGoods.BLL.Models.Auth.JWT;

namespace LocalGoods.BLL.Validators.User
{
    public class ConfirmEmailModelValidator : AbstractValidator<ConfirmEmailModel>
    {
        public ConfirmEmailModelValidator()
        {
            RuleFor(cem => cem.Email).NotEmpty().EmailAddress();
            RuleFor(cem => cem.Token).NotEmpty();
        }
    }
}
