using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SystemSup.Models
{
    public partial class Department
    {
        public Department()
        {
            Activs = new HashSet<Activ>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        [Required]
        [Display(Name = "Название отдела")]
        [MaxLength(50, ErrorMessage = "Превышена максимальная длина записи")]
        public string Name { get; set; }

        public ICollection<Activ> Activs { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
