using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWithoutAutentification.Models.AdditionalModels
{
    public class Specialization
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Vacancy> Vacancies { get; set; } = new(); 
        public List<Resume> Resumes { get; set; } = new();
    }
}
