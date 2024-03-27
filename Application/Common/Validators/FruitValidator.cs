using Domain.Entities;
using FluentValidation;

namespace Application.Common.Validators;

public class FruitValidator : AbstractValidator<Fruit>
{
    public FruitValidator()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage("Nomini kiriting")
            .Length(3, 50).WithMessage("nom uzunligi 3 50 orasida bo'lishligi kerak");
        RuleFor(x => x.Description).NotEmpty().WithMessage("Meva aqida ma'lumot kiriting");
        RuleFor(x => x.Price).GreaterThan(0).WithMessage("Narxni kiriting va u 0 dan katta bo'lsin");
        RuleFor(x => x.CategoryId).GreaterThan(0).WithMessage("Categoriyasini kiriting");
    }
}