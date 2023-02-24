using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWithoutAutentification.Models.AdditionalModels;

namespace TestWithoutAutentification.Models
{
    public class Vacancy
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Должность")]
        public string Position { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Специализация")]
        public Specialization Specialization { get; set; }
        public int? SpecializationId { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Зарплата")]
        public Salary Salary { get; set; }
        public int? SalaryId { get; set; }

        [Display(Name = "Город")]
        public int? CityId { get; set; }
        public City City { get; set; }

        [Display(Name = "Адрес")]
        public string Address { get; set; }

        [Display(Name = "Возможность удаленной работы")]
        public bool Remote { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Требуемый опыт")]
        public int? WorkExperienceId { get; set; }
        public WorkExperience WorkExperience { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Требования")]
        public string Requirements { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Условия работы")]
        public string Conditions { get; set; }

        [DisplayFormat(DataFormatString = "{0:g}")]
        public DateTime CreationDate { get; set; }

        public int? CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
