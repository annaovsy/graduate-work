using System;
using System.Collections.Generic;
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

        public int? RoleId { get; set; }
        public Role Role { get; set; }
    }
}
