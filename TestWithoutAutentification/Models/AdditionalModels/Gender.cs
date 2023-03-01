using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWithoutAutentification.Models.AdditionalModels
{
    public class Gender
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Resume> Resumes { get; set; } = new();
    }
}
