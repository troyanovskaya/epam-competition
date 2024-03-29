﻿using FluentValidation;
using LocalGoods.BLL.Models.Auth;

namespace LocalGoods.BLL.Validators.User
{
    public class ResetPasswordModelValidator : AbstractValidator<ResetPasswordModel>
    {
        public ResetPasswordModelValidator()
        {
            RuleFor(rpm => rpm.Email).NotEmpty().EmailAddress();
            RuleFor(rpm => rpm.Password).NotEmpty().Length(8, 100).Matches("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)[A-Za-z\\d@?&\\/]{8,}$");
            RuleFor(rpm => rpm.Token).NotEmpty();
        }
    }
}
