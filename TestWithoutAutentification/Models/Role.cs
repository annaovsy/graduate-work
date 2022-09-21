using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWithoutAutentification.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; }
        public List<Company> Companies { get; set; }
        public Role()
        {
            Users = new List<User>();
            Companies = new List<Company>();
        }
    }
}
