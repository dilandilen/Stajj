using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.dto
{
    public class ResetPassword
    {

        [Required(ErrorMessage = "Lütfen e-posta adresini boş geçmeyiniz.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Lütfen uygun formatta e-posta adresi giriniz.")]
        [Display(Name = "E-Posta Adresiniz")]
        public string Email { get; set; }
  
    }
}
