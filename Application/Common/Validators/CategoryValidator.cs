using Domain.Entities;
using FluentValidation;

namespace Application.Common.Validators;

public class CategoryValidator : AbstractValidator<Category>
{
    public CategoryValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Nomini kiriting")
            .Length(3, 50).WithMessage("3 va 50 harfdan iborat bo'lsin");
    }
}
