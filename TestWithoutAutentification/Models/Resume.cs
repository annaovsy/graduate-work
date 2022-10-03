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

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobilePhone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Position { get; set; }
        public string AboutMyself { get; set; }

        public int? CityId { get; set; }
        public City City { get; set; }

        public int? SexId { get; set; }
        public Sex Sex { get; set; }

        public int? WorkExperienceId { get; set; }
        public WorkExperience WorkExperience { get; set; }

        public int? SalaryId { get; set; }
        public Salary Salary { get; set; }

        public int? EducationLevelId { get; set; }
        public EducationLevel EducationLevel { get; set; }

        //public int NativeLanguageId { get; set; }
        //public NativeLanguage Language { get; set; }

        public List<Citizenship> Citizenships { get; set; } = new();

        public List<PlaceOfWork> PlacesOfWork { get; set; } = new();

        public List<EducationalInstitution> EducationalInstitutions { get; set; } = new();

        public List<ForeignLanguage> ForeignLanguages { get; set; } = new();

        public int? UserId { get; set; }
        public User User { get; set; }
    }
}