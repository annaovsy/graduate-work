using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWithoutAutentification.Models.AdditionalModels
{
    public class ForeignLanguage
    {
        public int Id { get; set; }
        public Language Language { get; set; }
        public LanguageLevel LanguageLevel { get; set; }
    }
}
