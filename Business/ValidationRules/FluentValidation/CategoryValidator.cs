using FluentValidation;
using Entity;

public class CategoryValidator : AbstractValidator<Category>
{
    public CategoryValidator()
    {
        RuleFor(c => c.CategoryName).NotEmpty().WithMessage("Kategori adı boş olamaz.");
        RuleFor(c => c.CategoryName).Length(2, 30).WithMessage("Kategori adı 2 ile 30 karakter arasında olmalıdır.");
    }
}
