using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DependencyInjection.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthdayDate { get; set; }
        public Int64 TaxCode { get; set; }
        public IEnumerable<Profile> Profiles { get; set; }

        public Employee()
        {
            Profiles = new List<Profile>();
        }
    }

    public class Profile
    {
        public int Id { get; set; }
        public decimal Rate { get; set; }
        public string Position { get; set; }
        public DateTime EmploymentDate { get; set; }
        public DateTime? FireDate { get; set; }
        public Employee Employee { get; set; }
    }

    public class AccountingDepartment
    {
        private Employee employee;
        public AccountingDepartment(Employee _employee)
        {
            employee = _employee;
        }
    }

    public class HumanResourcesDepartment
    {
        private Employee employee;
        public HumanResourcesDepartment(Employee _employee)
        {
            employee = _employee;
        }

        public TimeSpan? GetWorkExperience()
        {
            return employee.Profiles.Last().FireDate - (employee.Profiles.Last().FireDate ?? DateTime.Parse("0"));
        }
    }
}