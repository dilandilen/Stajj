using FluentValidation;
using Entity;
using System.Text.RegularExpressions;

public class CustomerValidator : AbstractValidator<Customer>
{
    public CustomerValidator()
    {
        RuleFor(c => c.Name).NotEmpty().WithMessage("Ad alanı boş olamaz.");
        RuleFor(c => c.SurName).NotEmpty().WithMessage("Soyad alanı boş olamaz.");
        RuleFor(c => c.Email).NotEmpty().WithMessage("E-posta adresi boş olamaz.");
        RuleFor(c => c.Email).EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.");
        RuleFor(c => c.Phone).NotEmpty().WithMessage("Telefon numarası boş olamaz.");
        RuleFor(c => c.Phone).Must(BeAValidPhoneNumber).WithMessage("Geçerli bir telefon numarası giriniz (11 haneli).");
        RuleFor(c => c.Adress).NotEmpty().WithMessage("Adres alanı boş olamaz.");
    }

    private bool BeAValidPhoneNumber(string phone)
    {
        return !string.IsNullOrEmpty(phone) && phone.Length == 11;
    }

    private bool BeAValidPassword(string password)
    {
        return !string.IsNullOrEmpty(password) && password.Length >= 8 && Regex.IsMatch(password, @"[\W]");
    }
}
