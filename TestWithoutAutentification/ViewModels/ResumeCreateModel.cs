using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TestWithoutAutentification.Models.AdditionalModels;

namespace TestWithoutAutentification.ViewModels
{
    public class ResumeCreateModel
    {
        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Фамилия")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Мобильный телефон")]
        [DataType(DataType.PhoneNumber)]
        public string MobilePhone { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Город проживания")]
        public int CityId { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Дата рождения")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Пол")]
        public int SexId { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Гражданство")]
        public List<int> CitizenshipsId { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Опыт работы")]
        public int WorkExperienceId { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Желаемая должность")]
        public string Position { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Зарплата")]
        public int Salary { get; set; }
        public int CurrencyId { get; set; }

        [Display(Name = "Места работы")]
        public List<int> PlasesOfWorkId { get; set; }

        [Display(Name = "О себе")]
        [DataType(DataType.MultilineText)]
        public string AboutMyself { get; set; }
    }
}
