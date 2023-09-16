using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class TodoListModel
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        [Required(ErrorMessage = "You cannot pass this field blank.")]
        public string Title { get; set; }

        [Column(TypeName = "bit")]
        public bool Status { get; set; }
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "You cannot pass this field blank.")]
        public string Hour { get; set; }
    }
}
