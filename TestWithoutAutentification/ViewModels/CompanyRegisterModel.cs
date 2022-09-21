using System.ComponentModel.DataAnnotations;

namespace TestWithoutAutentification.ViewModels
{
    public class CompanyRegisterModel
    {
        [Required(ErrorMessage = "Не указано Название компании")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указан Город")]
        public string City { get; set; }

        [Required(ErrorMessage = "Не указано Имя")]
        public string FirstNameContactPerson { get; set; }

        [Required(ErrorMessage = "Не указана Фамилия")]
        public string LastNameContactPerson { get; set; }

        [Required(ErrorMessage = "Не указан Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
    }
}
