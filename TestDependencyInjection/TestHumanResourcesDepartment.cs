using NUnit.Framework;
using DependencyInjection.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestDependencyInjection
{
    [TestFixture]
    public class TestHumanResourcesDepartment
    {
        static List<Employee> employees = null;

        [SetUp]
        public void Setup()
        {
            employees = new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    FirstName = "Alexey",
                    LastName = "Perov",
                    BirthdayDate = DateTime.Parse("08/08/1958"),
                    TaxCode = 1958080801,
                    Profiles = new List<Profile>
                    {
                        new Profile {
                            Id = 1,
                            Rate = 5920,
                            Position = "Mechanic",
                            EmploymentDate = DateTime.Parse("01/04/1998"),
                            FireDate = DateTime.Parse("15/08/2005")
                        },
                        new Profile {
                            Id = 2,
                            Rate = 7600,
                            Position = "Boss",
                            EmploymentDate = DateTime.Parse("15/08/2005"),
                            FireDate = null
                        }
                    }
                },
                new Employee
                {
                    Id = 2,
                    FirstName = "Sergey",
                    LastName = "Smirnov",
                    BirthdayDate = DateTime.Parse("15/03/1990"),
                    TaxCode = 1958080802,
                    Profiles = new List<Profile>
                    {
                        new Profile {
                            Id = 3,
                            Rate = 4500,
                            Position = "Electric",
                            EmploymentDate = DateTime.Parse("12/02/2012"),
                            FireDate = null
                        }
                    }
                }
            };
        }

        [TestCase(1, 15)]
        [TestCase(2, 8)]
        public void TestGetWorkExperiance(int id, int exp)
        {
            // arrange
            IHumanResourcesDepartment hrd = new HumanResourcesDepartment();
            Employee employee = employees.Where(p => p.Id == id).First();
            // act
            int actual = hrd.GetWorkExperience(employee);

            // assert
            Assert.AreEqual(actual, exp);
        }

        [TestCase(1, 25)]
        [TestCase(2, 15)]
        public void TestGetExperienceBonus(int id, int expected)
        {
            // arrange
            IHumanResourcesDepartment hdr = new HumanResourcesDepartment();
            Employee employee = employees.Where(p => p.Id == id).First();

            // act
            int actual = hdr.GetExperienceBonus(employee);

            // assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 4)]
        [TestCase(2, 12)]
        public void TestGetHarmPercentage(int id, int expected)
        {
            IHumanResourcesDepartment hdr = new HumanResourcesDepartment();
            Employee employee = employees.Where(p => p.Id == id).First();

            int actual = hdr.GetHarmPercentage(employee);

            Assert.AreEqual(expected, actual);
        }
    }
}