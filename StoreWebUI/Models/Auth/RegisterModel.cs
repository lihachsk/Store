using System;
using System.ComponentModel.DataAnnotations;
 
namespace StoreWebUI.Models.Auth
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Обязательно для заполнения")]
        [Display(Name = "Логин")]
        [StringLength(maximumLength:50, MinimumLength = 3,ErrorMessage = "Длинна имени должна состовлять от 3-х до 50-ти символов")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Обязательно для заполнения")]
        [Display(Name ="Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Обязательно для заполнения")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Обязательно для заполнения")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Повторите пароль")]
        public string PasswordConfirm { get; set; }
    }
}