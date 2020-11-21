using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DependencyInjection.Models.ViewModels
{
    public class ViewDetails
    {
        public string Name { get; set; }
        public decimal Rate { get; set; }
        public decimal Salary { get; set; }
        public int WorkExpireance { get; set; }
        public int ExperienceBonus { get; set; }
        public int HarmPercentage { get; set; }
    }
}