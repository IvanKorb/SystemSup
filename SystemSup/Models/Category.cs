using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SystemSup.Models
{
    public partial class Category
    {
        public Category()
        {
            Requests = new HashSet<Request>();
        }

        public int Id { get; set; }

        [Required]
        [Display(Name = "Название категории")]
        [MaxLength(50, ErrorMessage = "Превышена максимальная длина записи")]
        public string Name { get; set; }

        public ICollection<Request> Requests { get; set; }
    }
}
