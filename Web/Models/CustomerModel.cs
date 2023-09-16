using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class CustomerModel
    {
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Ad alanı gereklidir.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyad alanı gereklidir.")]
        public string SurName { get; set; }

        [Required(ErrorMessage = "Email alanı gereklidir.")]
        [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Telefon alanı gereklidir.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Adres alanı gereklidir.")]
        public string Adress { get; set; }
        public bool IsDelete { get; set; }
    }
}
