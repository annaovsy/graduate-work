using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWithoutAutentification.Models.AdditionalModels
{
    public class Salary
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public Currency Currency { get; set; }
    }
}
