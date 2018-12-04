using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SystemSup.Models
{
    public partial class User
    {
        public User()
        {
            Requests = new HashSet<Request>();
        }

        // ID 
        public int Id { get; set; }
        // Фамилия Имя Отчество
        [Required]
        [Display(Name = "Ф.И.О.")]
        [MaxLength(50, ErrorMessage = "Превышена максимальная длина записи")]
        public string Name { get; set; }
        // Логин
        [Required]
        [Display(Name = "Логин")]
        [MaxLength(50, ErrorMessage = "Превышена максимальная длина записи")]
        public string Login { get; set; }
        // Пароль
        [Required]
        [Display(Name = "Пароль")]
        [MaxLength(50, ErrorMessage = "Превышена максимальная длина записи")]
        public string Password { get; set; }
        // Должность
        [Display(Name = "Должность")]
        [MaxLength(50, ErrorMessage = "Превышена максимальная длина записи")]
        public string Position { get; set; }
        // Отдел
        [Display(Name = "Отдел")]
        public int? DepartmentId { get; set; }
        // Статус
        [Required]
        [Display(Name = "Статус")]
        public int RoleId { get; set; }

        public Department Department { get; set; }
        public Role Role { get; set; }
        public ICollection<Request> Requests { get; set; }
    }
}
