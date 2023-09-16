using FluentValidation;
using Entity;

public class PersonelValidator : AbstractValidator<Personel>
{
    public PersonelValidator()
    {
        RuleFor(p => p.Name).NotEmpty().WithMessage("Ad alanı boş olamaz.");
        RuleFor(p => p.SurName).NotEmpty().WithMessage("Soyad alanı boş olamaz.");
        RuleFor(p => p.Email).NotEmpty().WithMessage("E-posta adresi boş olamaz.");
        RuleFor(p => p.Email).EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.");
        RuleFor(p => p.Phone).NotEmpty().WithMessage("Telefon numarası boş olamaz.");
        RuleFor(p => p.Phone).Must(BeAValidPhoneNumber).WithMessage("Geçerli bir telefon numarası giriniz (11 haneli).");
        RuleFor(p => p.Role).NotEmpty().WithMessage("Rol alanı boş olamaz.");
        RuleFor(p => p.Salary).GreaterThan(0).WithMessage("Maaş miktarı 0'dan büyük olmalıdır.");
    }

    private bool BeAValidPhoneNumber(string phone)
    {
        return !string.IsNullOrEmpty(phone) && phone.Length == 11;
    }
}
