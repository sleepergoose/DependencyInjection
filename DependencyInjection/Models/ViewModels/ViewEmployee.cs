using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DependencyInjection.Models.ViewModels
{
    public class ViewEmployee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public Int64 TaxCode { get; set; }
        public decimal CurrentRate { get; set; }
        public DateTime EmploymentDate { get; set; }
        public Nullable<DateTime> FireDate { get; set; }

    }
}
