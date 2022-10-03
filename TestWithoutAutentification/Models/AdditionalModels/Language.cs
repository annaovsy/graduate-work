using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWithoutAutentification.Models.AdditionalModels
{
    public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<ForeignLanguage> ForeignLanguages { get; set; } = new();
    }
}
