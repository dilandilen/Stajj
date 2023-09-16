using FluentValidation;
using Entity;

public class CategoryValidator : AbstractValidator<Category>
{
    public CategoryValidator()
    {
        RuleFor(c => c.CategoryName).NotEmpty().WithMessage("Kategori adı boş olamaz.");
        RuleFor(c => c.CategoryName).Length(2, 30).WithMessage("Kategori adı 2 ile 30 karakter arasında olmalıdır.");
        RuleFor(c => c.Imgurl).MaximumLength(30).WithMessage("Resim URL'si en fazla 30 karakter olmalıdır.");
    }
}
