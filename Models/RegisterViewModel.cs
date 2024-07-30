using System.ComponentModel.DataAnnotations;

namespace StorePIatform.Models
{
    public class RegisterViewModel
    {

        [Key]
        public int Id { get; set; }
  
        public string FullName { get; set; }


        public string Email { get; set; }


        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
