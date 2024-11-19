using System.ComponentModel.DataAnnotations;

namespace Lab5.Models
{
    public class ProfileViewModel
    {
        [Display(Name = "Ім'я користувача")]
        public string UserName { get; set; }
        [Display(Name = "ПІБ")]

        public string FullName { get; set; }

        [Display(Name = "Email")]

        public string Email { get; set; }
        [Display(Name = "Номер телефону")]
        public string Phone { get; set; }
    }
}