using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWithoutAutentification.Models.AdditionalModels;

namespace TestWithoutAutentification.Models
{
    public class Resume
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MobilePhone { get; set; }
        public City City { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Sex Sex { get; set; }
        public WorkExperience WorkExperience { get; set; }
        public string Position { get; set; }
        public Salary Salary { get; set; }
        public string AboutMyself { get; set; }
        public EducationLevel EducationLevel { get; set; }
        public NativeLanguage NativeLanguage { get; set; }

        public int? CitizenshipId { get; set; }
        public List<Citizenship> Citizenships { get; set; }
        public int? PlaceOfWorkId { get; set; }
        public List<PlaceOfWork> PlacesOfWork { get; set; }
        public int? EducationalInstitutionId { get; set; }
        public List<EducationalInstitution> EducationalInstitutions { get; set; }
        public int? ForeignLanguageId { get; set; }
        public List<ForeignLanguage> ForeignLanguages { get; set; }

        public Resume()
        {
            Citizenships = new List<Citizenship>();
            PlacesOfWork = new List<PlaceOfWork>();
            EducationalInstitutions = new List<EducationalInstitution>();
            ForeignLanguages = new List<ForeignLanguage>();
        }
    }
}
