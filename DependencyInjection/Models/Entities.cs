using System;
using System.Collections.Generic;
using System.Linq;

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


    /// <summary>
    /// Interface IAccountingDepartment
    /// </summary>
    public interface IAccountingDepartment
    {
        decimal Bonus { get; set; }
        decimal IncomeTaxRate { get; set; }
        decimal MilitaryContributionRate { get; set; }
        decimal SocialInsuranceRate { get; set; }
        decimal TradeUnionTax { get; set; }

        decimal GetMonthSalary(Employee employee, IHumanResourcesDepartment hrd);
    }

    /// <summary>
    /// Class AccountingDepartment
    /// </summary>
    public class AccountingDepartment : IAccountingDepartment
    {
        public decimal Bonus { get; set; } = 5m;
        public decimal IncomeTaxRate { get; set; } = 15m;
        public decimal MilitaryContributionRate { get; set; } = 1.5m;
        public decimal SocialInsuranceRate { get; set; } = 2.5m;
        public decimal TradeUnionTax { get; set; } = 1m;
        public AccountingDepartment()
        {

        }

        public AccountingDepartment(decimal _Bonus, decimal _IncomeTaxRate,
                                    decimal _MilitaryContributionRate, decimal _SocialInsuranceRate,
                                    decimal _TradeUnionTax)
        {
            Bonus = _Bonus;
            IncomeTaxRate = _IncomeTaxRate;
            MilitaryContributionRate = _MilitaryContributionRate;
            SocialInsuranceRate = _SocialInsuranceRate;
            TradeUnionTax = _TradeUnionTax;
        }

        public decimal GetMonthSalary(Employee employee, IHumanResourcesDepartment hrd)
        {
            decimal rate = employee.Profiles.Last().Rate;
            int harm = hrd.GetHarmPercentage(employee);
            int experienceBonus = hrd.GetExperienceBonus(employee);

            decimal profit = 1m + (harm + experienceBonus + Bonus) / 100m;
            decimal taxes = 1m - (IncomeTaxRate + MilitaryContributionRate + SocialInsuranceRate + TradeUnionTax) / 100m;
            return rate * profit * taxes;
        }
    }



    /// <summary>
    /// Interface IHumanResourcesDepartment
    /// </summary>
    public interface IHumanResourcesDepartment
    {
        int GetExperienceBonus(Employee employee);
        int GetHarmPercentage(Employee employee);
        int GetWorkExperience(Employee employee);
    }

    /// <summary>
    /// Class HumanResourcesDepartment
    /// </summary>
    public class HumanResourcesDepartment : IHumanResourcesDepartment
    {
        /// <summary>
        /// Method calculates total work experiance of the employee (Years)
        /// </summary>
        /// <param name="employee">Employee whose work experience needs to be calculated </param>
        /// <returns>Number of years</returns>
        public int GetWorkExperience(Employee employee)
        {
            Profile firstProfile = employee.Profiles.First();
            Profile lastProfile = employee.Profiles.Last();

            DateTime fireDate = lastProfile.FireDate ?? DateTime.Now;
            DateTime employmentDate = firstProfile.EmploymentDate;

            if (fireDate.Year <= employmentDate.Year)
                return 0;
            else if (fireDate.Month <= employmentDate.Month && fireDate.Day < employmentDate.Day)
                return fireDate.Year - employmentDate.Year - 1;
            else
                return fireDate.Year - employmentDate.Year;
        }

        /// <summary>
        /// Method returns experience bonus percentage depend on numbers of work experience
        /// </summary>
        /// <param name="employee">Employee whose experience bonus needs to be calculated</param>
        /// <returns>Percentage of experience bonus</returns>
        public int GetExperienceBonus(Employee employee)
        {
            int exp = this.GetWorkExperience(employee);
            
            if (exp < 1)
                return 0;
            else if (exp >= 1 && exp < 3)
                return 7;
            else if (exp >= 3 && exp < 5)
                return 10;
            else if (exp >= 5 && exp < 10)
                return 15;
            else if (exp >= 10 && exp < 15)
                return 20;
            else if (exp >= 15 && exp < 20)
                return 25;
            else if (exp >= 20 && exp < 25)
                return 30;
            else if (exp >= 25 && exp < 30)
                return 35;
            else if (exp >= 30 && exp < 40)
                return 40;
            else
                return 45;
        }

        /// <summary>
        /// Method returns harm percentage bonus depend on employee position
        /// </summary>
        /// <param name="employee">Employee whose harm bonus needs to be calculated</param>
        /// <returns>Percentage of harm bonus</returns>
        public int GetHarmPercentage(Employee employee)
        {
            string position = employee.Profiles.Last().Position;

            switch (position)
            {
                case "Mechanic":
                    return 8;
                case "Electric":
                    return 12;
                case "Driver":
                    return 10;
                case "Accountant":
                case "HR":
                case "Technic":
                    return 0;
                case "Master":
                    return 8;
                case "Cleaner":
                case "Boss":
                    return 4;
                default:
                    return 0;
            }
        }
    }


    public class AccountingDepartmentProgressiveTax : IAccountingDepartment
    {
        public decimal Bonus { get; set; } = 5m;
        public decimal IncomeTaxRate { get; set; } = 15m;
        public decimal MilitaryContributionRate { get; set; } = 1.5m;
        public decimal SocialInsuranceRate { get; set; } = 2.5m;
        public decimal TradeUnionTax { get; set; } = 1m;
        
        public decimal GetMonthSalary(Employee employee, IHumanResourcesDepartment hrd)
        {
            decimal rate = employee.Profiles.Last().Rate;
            int harm = hrd.GetHarmPercentage(employee);
            int experienceBonus = hrd.GetExperienceBonus(employee);

            decimal profit = 1m + (harm + experienceBonus + Bonus) / 100m;
            decimal salary = rate * profit;

            if (salary >= 5000)
            {
                IncomeTaxRate = 18m;
            }
            if (rate > 7000)
            {
                SocialInsuranceRate = 3.5m;
            }
            decimal taxes = 1m - (IncomeTaxRate + MilitaryContributionRate + SocialInsuranceRate + TradeUnionTax) / 100m;
            return salary * taxes;
        }
    }
}