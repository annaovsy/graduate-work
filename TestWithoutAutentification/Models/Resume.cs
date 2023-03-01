using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TestWithoutAutentification.Models.AdditionalModels;

namespace TestWithoutAutentification.Models
{
    public class Resume
    {
        public int Id { get; set; }

        [Display(Name = "Фото")]
        public int? ImageId { get; set; }
        public Image Image { get; set; }

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
        public int? CityId { get; set; }
        public City City { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Дата рождения")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:D}")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Пол")]
        public int? GenderId { get; set; }
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Опыт работы")]
        public int? WorkExperienceId { get; set; }
        public WorkExperience WorkExperience { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Желаемая должность")]
        public string Position { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Специализация")]
        public int? SpecializationId { get; set; }
        public Specialization Specialization { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Зарплата")]
        public Salary Salary { get; set; }
        public int? SalaryId { get; set; }

        [Display(Name = "О себе")]
        [DataType(DataType.MultilineText)]
        public string AboutMyself { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Уровень образования")]
        public int? EducationLevelId { get; set; }
        public EducationLevel EducationLevel { get; set; }

        [Display(Name = "Иностранный язык")]
        public ForeignLanguage ForeignLanguage { get; set; }
        public int? ForeignLanguageId { get; set; }

        [NotMapped]
        [Display(Name = "Возраст")]
        public int Age {
            get
            {
                return DateTime.Today.Year - DateOfBirth.Year - 1 +
                    ((DateTime.Today.Month > DateOfBirth.Month || DateTime.Today.Month == DateOfBirth.Month && DateTime.Today.Day >= DateOfBirth.Day) ? 1 : 0);
            }
        }

        [NotMapped]
        public string FullName
        {
            get
            {
                return FirstName + ' ' + LastName;
            }
        }

        [DisplayFormat(DataFormatString = "{0:g}")]
        public DateTime CreationDate { get; set; }

        public List<PlaceOfWork> PlacesOfWork { get; set; } = new();

        public List<EducationalInstitution> EducationalInstitutions { get; set; } = new();

        public int? UserId { get; set; }
        public User User { get; set; }
    }
}