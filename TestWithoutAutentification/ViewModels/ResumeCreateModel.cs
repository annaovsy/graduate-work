using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TestWithoutAutentification.Models;
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
        public City City { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Дата рождения")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Пол")]
        public Sex Sex { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Гражданство")]
        public List<int> Citizenships { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Опыт работы")]
        public WorkExperience WorkExperience { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Желаемая должность")]
        public string Position { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Зарплата")]
        public Salary Salary { get; set; }

        //[Display(Name = "Места работы")]
        //public List<int> PlasesOfWorkId { get; set; } = new List<int>();

        [Display(Name = "О себе")]
        [DataType(DataType.MultilineText)]
        public string AboutMyself { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Уроень образования")]
        public EducationLevel EducationLevel { get; set; }

        [Display(Name = "Иностранные языки")]
        public ForeignLanguage ForeignLanguageee { get; set; }
        public List<ForeignLanguage> ForeignLanguages { get; set; }

    }
}
