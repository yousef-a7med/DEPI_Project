using Hospital.DAL.Enum;
using System.ComponentModel.DataAnnotations;

namespace Hospital.BLL.ModelVM.Users
{
    public class CreateUserVM
    {
        [MinLength(2,ErrorMessage ="Name is required")]
        [Required]
        public string FullName { get; set; }
        public string Password { get; set; }
        public Role Role { get; set; }
        public bool IsActive { get; set; }
        public string Email { get; set; }
    }
}
