using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWithoutAutentification.Models.AdditionalModels
{
    public class Image
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }

        public Resume Resume { get; set; }
        public Company Company { get; set; }
    }
}
