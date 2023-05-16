using System.ComponentModel.DataAnnotations;

namespace WorkOne.Models.UserModels
{
    public class RegisterUserModel
    {
        [Required(ErrorMessage = "Не указано Email")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 30 символов")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указано пароль")]
        [StringLength(8, MinimumLength = 6, ErrorMessage = "Длина строки должна быть от 6 до 8 символов")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string PasswordConfirm { get; set; }

        public string? Address { get; set; }
    }
}
