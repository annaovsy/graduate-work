using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWithoutAutentification.Models.AdditionalModels
{
    public class PlaceOfWork
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Organization { get; set; }
        public string Position { get; set; }        
    }
}
