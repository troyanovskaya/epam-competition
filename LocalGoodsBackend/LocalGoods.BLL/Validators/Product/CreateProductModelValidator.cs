using FluentValidation;
using LocalGoods.BLL.Models.Product;

namespace LocalGoods.BLL.Validators.Product
{
    public class CreateProductModelValidator : AbstractValidator<CreateProductModel>
    {
        public CreateProductModelValidator()
        {
            RuleFor(cpm => cpm.Name).NotEmpty().Length(5, 50).Matches("^[A-Za-z0-9 _]*[A-Za-z0-9][A-Za-z0-9 _]*$");
            RuleFor(cpm => cpm.Description).NotEmpty().Length(5, 200).Matches("^[A-Za-z0-9 _]*[A-Za-z0-9][A-Za-z0-9 _]*$");
            RuleFor(cpm => cpm.Price).NotNull().GreaterThan(0);
            RuleFor(cpm => cpm.Poster).NotEmpty();
            RuleFor(cpm => cpm.VendorId).NotEmpty();
            RuleFor(cpm => cpm.Amount).NotNull().GreaterThan(0);
            RuleFor(cpm => cpm.Discount).GreaterThanOrEqualTo(0);
            RuleFor(cpm => cpm.UnitTypeId).NotEmpty();

            RuleFor(cpm => cpm.CategoryIds).NotNull();
            RuleForEach(cpm => cpm.CategoryIds).NotEmpty();
            RuleForEach(cpm => cpm.Images).NotEmpty();
        }
    }
}
