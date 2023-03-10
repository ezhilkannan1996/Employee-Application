using System.ComponentModel.DataAnnotations;

namespace EmployeeApp.Models
{
    public class UserData
    {
        [Key]
        public string Email { get; set; }
        public string Password { get; set; }
        public bool KeepLoggedIn { get; set; }
    }
}
