using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using DependencyInjection.Models;
using DependencyInjection.Models.ViewModels;

namespace DependencyInjection.Controllers
{
    public class HomeController : Controller
    {
        private static List<int> list = new List<int>();

        private IHumanResourcesDepartment HRDepartment;
        private IAccountingDepartment AccountingDepartment;
        private IEmployeesProvider employeesProvider;

        public HomeController(  IHumanResourcesDepartment _HRDepartment,
                                IAccountingDepartment _AccountingDepartment,
                                IEmployeesProvider _EmployeesProvider)
        {
            HRDepartment = _HRDepartment;
            AccountingDepartment = _AccountingDepartment;
            employeesProvider = _EmployeesProvider;
        }

        public ActionResult Index()
        {
            List<Employee> employees = employeesProvider.GetAll().ToList();
            var res = employees.Select(e => new ViewEmployee
            {
                Id = e.Id,
                Name = e.FirstName + " " + e.LastName,
                BirthDate = e.BirthdayDate,
                TaxCode = e.TaxCode,
                CurrentRate = e.Profiles.Last().Rate,
                EmploymentDate = e.Profiles.First().EmploymentDate,
                FireDate = e.Profiles.Last().FireDate
            });



            return View(res);
        }


        public ActionResult Details(int id)
        {
            //if (!list.Contains(id))
            //{
            //    list.Add(id);
                List<Employee> employees = employeesProvider.GetAll().ToList();
                Employee employee = employees.Find(p => p.Id == id);

                ViewDetails viewDetails = new ViewDetails
                {
                    Name = employee.FirstName + " " + employee.LastName,
                    Rate = employee.Profiles.Last().Rate,
                    Salary = AccountingDepartment.GetMonthSalary(employee, HRDepartment),
                    WorkExpireance = HRDepartment.GetWorkExperience(employee),
                    ExperienceBonus = HRDepartment.GetExperienceBonus(employee),
                    HarmPercentage = HRDepartment.GetHarmPercentage(employee)
                };

                return PartialView(viewDetails);
            //}
            //else
            //    return PartialView(null);
        }
    }
}