using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class PersonelModel
    {
        public int PersonelId { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname is required")]
        public string SurName { get; set; }


        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Role is required")]
        public string Role { get; set; }

        [Required(ErrorMessage = "Salary is required")]
        public int Salary { get; set; }
    }
}
