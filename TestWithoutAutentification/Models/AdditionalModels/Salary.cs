using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestWithoutAutentification.Models.AdditionalModels
{
    public class Salary
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Обязательное поле")]
        public int Amount { get; set; }

        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }

        public Resume Resume { get; set; }
        public Vacancy Vacancy { get; set; }
    }
}
