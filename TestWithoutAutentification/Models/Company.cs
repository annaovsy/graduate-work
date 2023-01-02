using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestWithoutAutentification.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string FirstNameContactPerson { get; set; }
        public string LastNameContactPerson { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public string Site { get; set; }

        public int? RoleId { get; set; }
        public Role Role { get; set; }

        public List<Vacancy> Vacancies { get; set; }
        public Company()
        {
            Vacancies = new List<Vacancy>();
        }

        [NotMapped]
        public string FullNameContactPerson
        {
            get
            {
                return FirstNameContactPerson + ' ' + LastNameContactPerson;
            }
        }
    }
}
