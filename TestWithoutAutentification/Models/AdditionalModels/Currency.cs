﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWithoutAutentification.Models.AdditionalModels
{
    public class Currency
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Salary> Salaries { get; set; } = new();
    }
}
