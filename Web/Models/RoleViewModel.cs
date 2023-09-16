using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class RoleViewModel
    {
        [Required(ErrorMessage = "Rolü boş geçmeyiniz.")]
        [Display(Name = "Rol Adı")]
        public string Name { get; set; }
    }
}
