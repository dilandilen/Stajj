using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.dto
{
	public class RegisterDto
    {
        [Required(ErrorMessage = "Lütfen e-posta adresini boş geçmeyiniz.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Lütfen uygun formatta e-posta adresi giriniz.")]
        [Display(Name = "E-Posta ")]
        public string Email { get; set; }
        //public string UserName { get; set; }
        [Required(ErrorMessage = "Lütfen şifreyi boş geçmeyiniz.")]
        [DataType(DataType.Password, ErrorMessage = "Lütfen uygun formatta şifre giriniz.")]
        [Display(Name = "Şifre")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Lütfen adınıızı boş geçmeyiniz.")]

        public string FirstName { get; set; }
        [Required(ErrorMessage = "Lütfen soyadı boş geçmeyiniz.")]

        public string LastName { get; set; }
        [Required(ErrorMessage = "Lütfen telefonu boş geçmeyiniz.")]

        public string PhoneNumber { get; set; }
	}
}
