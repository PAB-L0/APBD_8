using FluentValidation;
using Labs_8.RequestModels;

namespace Labs_8.Validators;

public class ProductRequestModelValidator : AbstractValidator<CreateProductRequestModel>
{
    public ProductRequestModelValidator()
    {
        RuleFor(e => e.ProductName).MaximumLength(100).NotNull();
        RuleFor(e => e.ProductWeight).GreaterThan(0).NotNull();
        RuleFor(e => e.ProductWidth).GreaterThan(0).NotNull();
        RuleFor(e => e.ProductHeight).GreaterThan(0).NotNull();
        RuleFor(e => e.ProductDepth).GreaterThan(0).NotNull();
    }
}