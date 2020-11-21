using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DependencyInjection.Models
{
    public interface IEmployeesProvider
    {
        IEnumerable<Employee> GetAll();
    }

    public class EmployeesProvider : IEmployeesProvider
    {
        private List<Employee> employees;

        public EmployeesProvider()
        {
            employees = employees = new List<Employee>
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
                },
                new Employee
                {
                    Id = 3,
                    FirstName = "Sergey",
                    LastName = "Petrov",
                    BirthdayDate = DateTime.Parse("02/05/1986"),
                    TaxCode = 1986020503,
                    Profiles = new List<Profile>
                    {
                        new Profile {
                            Id = 4,
                            Rate = 4500,
                            Position = "Electric",
                            EmploymentDate = DateTime.Parse("05/08/2005"),
                            FireDate = null
                        }
                    }
                },
                new Employee
                {
                    Id = 4,
                    FirstName = "Andrew",
                    LastName = "Karpenko",
                    BirthdayDate = DateTime.Parse("14/06/1960"),
                    TaxCode = 1406196004,
                    Profiles = new List<Profile>
                    {
                        new Profile {
                            Id = 5,
                            Rate = 5920,
                            Position = "Mechanic",
                            EmploymentDate = DateTime.Parse("01/08/1982"),
                            FireDate = DateTime.Parse("03/02/1990")
                        },
                        new Profile {
                            Id = 6,
                            Rate = 6500,
                            Position = "Master",
                            EmploymentDate = DateTime.Parse("03/02/1990"),
                            FireDate = DateTime.Parse("12/09/2012")
                        },
                        new Profile {
                            Id = 7,
                            Rate = 7600,
                            Position = "Boss",
                            EmploymentDate = DateTime.Parse("12/09/2012"),
                            FireDate = DateTime.Parse("14/06/2020")
                        }
                    }
                }
            };
        }

        public IEnumerable<Employee> GetAll()
        {
            return employees;
        }
    }
}