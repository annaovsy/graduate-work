using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWithoutAutentification.Models.AdditionalModels
{
    public class EducationalInstitution
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Specialization { get; set; }
        public int EndYear { get; set; }

        public int ResumeId { get; set; }
        public Resume Resume { get; set; }
    }
}
