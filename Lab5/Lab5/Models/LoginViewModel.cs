using System.ComponentModel.DataAnnotations;

namespace Lab5.Models
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Ваш Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Ваш пароль")]
        public string Password { get; set; }

    }
}
