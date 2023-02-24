using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TestWithoutAutentification.Models.AdditionalModels;

namespace TestWithoutAutentification.Models
{
    public class Company
    {
        public int Id { get; set; }

        [Display(Name = "Название компании")]
        [Required(ErrorMessage = "Обязательное поле")]
        public string Name { get; set; }

        [Display(Name = "Город")]
        [Required(ErrorMessage = "Обязательное поле")]
        public string City { get; set; }

        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Обязательное поле")]
        public string FirstNameContactPerson { get; set; }

        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Обязательное поле")]
        public string LastNameContactPerson { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Обязательное поле")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Обязательное поле")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Подтверждение пароля")]
        [Required(ErrorMessage = "Обязательное поле")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [NotMapped]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Телефон")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Display(Name = "Сайт")]
        public string Site { get; set; }

        public int? RoleId { get; set; }
        public Role Role { get; set; }

        public List<Vacancy> Vacancies { get; set; }
        public Company()
        {
            Vacancies = new List<Vacancy>();
        }

        [NotMapped]
        public string FullNameContactPerson
        {
            get
            {
                return FirstNameContactPerson + ' ' + LastNameContactPerson;
            }
        }
    }
}
