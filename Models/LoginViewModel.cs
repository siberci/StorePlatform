using System.ComponentModel.DataAnnotations;

namespace StorePIatform.Models
{
    public class LoginViewModel
    {

        [Key]
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
