using System;
using System.Collections.Generic;
using GameBlog.Models;
using System.ComponentModel.DataAnnotations;
namespace GameBlog.Areas.Admin.Models
{
    public class UsersIndexViewModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public IEnumerable<String> Role { get; set; }
    }

    public class CreateUserViewModel
    {
        
        [Display(Name = "Имя пользователя")]
        [Required(ErrorMessage = "Вы не ввели имя пользователя")]
        public string UserName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Вы не ввели Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Вы не ввели Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Display(Name = "Подтвеждение пароля")]
        [Required(ErrorMessage = "Вы не ввели повторно пароль для подтверждения")]
        [Compare("Password",ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        public string PasswordConfirmed { get; set; }

        [Display(Name = "Год рождения")]
        [Required(ErrorMessage = "Вы не ввели год рождения")]
        public int Year { get; set; }

        [Display(Name = "Роль пользователя")]
        [Required(ErrorMessage = "Вы не указали роль пользователя в системе")]
        public string RoleId { get; set; }
    }

    public class UserUpdateViewModel
    {
        [ScaffoldColumn(false)]
        public string Id { get; set; }

        [Display(Name = "Имя пользователя")]
        [Required(ErrorMessage = "Вы не ввели имя пользователя")]
        public string UserName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Вы не ввели Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Год рождения")]
        [Required(ErrorMessage = "Вы не ввели год рождения")]
        public int Year { get; set; }

        [Display(Name = "Роль пользователя")]
        [Required(ErrorMessage = "Вы не указали роль пользователя в системе")]
        public string RoleId { get; set; }
    }

    public class UserDeleteViewModel
    {
        [ScaffoldColumn(false)]
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
   
}