using System.ComponentModel.DataAnnotations;

namespace Lab5.Models
{
    public class RegistrationViewModel
    {
        [Required]
        [MaxLength(50)]
        [Display(Name = "Ваше ім'я")]
        public string UserName { get; set; }

        [Required]
        [MaxLength(500)]
        [Display(Name = "Ваше ПІБ")]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Ваш Email")]
        public string Email { get; set; }

        [Required]
        [Phone]
        [RegularExpression(@"^\+380\d{9}$", ErrorMessage = "Невірний формат телефону")]
        [Display(Name = "Ваш номер телефону")]
        public string Phone { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [StringLength(16, MinimumLength = 8, ErrorMessage = "Пароль має бути від 8 до 16 символів")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,16}$", ErrorMessage = "Пароль має містити що найменше 1 цифру, 1 знак, 1 велику літеру, мати не менше 8 символів, і не більше 16 символів")]
        [Display(Name = "Ваш пароль")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Паролі не співпадають")]
        [Display(Name = "Підтвердження паролю")]
        public string ConfirmPassword { get; set; }
    }
}