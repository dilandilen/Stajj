using Entity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValidator:AbstractValidator<Product>
    {
        public ProductValidator() {
        RuleFor(p=>p.ProductName).NotEmpty().WithMessage("Ürün İsmi Boş olamaz");
        RuleFor(p => p.ProductName).Length(3,40);
            RuleFor(p => p.Brandname).NotEmpty().WithMessage("Marka Adı Boş olamaz");
            RuleFor(p => p.Cost_price).GreaterThanOrEqualTo(0); 
            RuleFor(p => p.Selling_price).GreaterThanOrEqualTo(0);
            RuleFor(p => p.Cost_price).LessThanOrEqualTo(p => p.Selling_price).When(p => p.Cost_price > 0 && p.Selling_price > 0);
            RuleFor(p => p.Stock).GreaterThanOrEqualTo(0);
        }
        public static bool ContainSpecialCharacters(string text)
        {
            string pattern = @"[!@#$%^&*()_+{}\[\]:;<>,.?~\\-]";

            return Regex.IsMatch(text, pattern);
        }
    }
}
