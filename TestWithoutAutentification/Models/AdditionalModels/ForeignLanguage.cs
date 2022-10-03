using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWithoutAutentification.Models.AdditionalModels
{
    public class ForeignLanguage
    {
        public int Id { get; set; }

        public int LanguageId { get; set; }
        public Language Language { get; set; }

        public int LanguageLevelId { get; set; }
        public LanguageLevel LanguageLevel { get; set; }

        public List<Resume> Resumes { get; set; } = new();
    }
}
