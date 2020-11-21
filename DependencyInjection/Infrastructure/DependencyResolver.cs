using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;
using Ninject;
using DependencyInjection.Models;

namespace DependencyInjection.Infrastructure
{
    public class DependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public DependencyResolver(IKernel _kernel)
        {
            kernel = _kernel;
            AddBinding();
        }

        private void AddBinding()
        {
            kernel.Bind<IHumanResourcesDepartment>().To<HumanResourcesDepartment>();
            // kernel.Bind<IAccountingDepartment>().To<AccountingDepartment>();
            kernel.Bind<IAccountingDepartment>().To<AccountingDepartmentProgressiveTax>()
                        .WithPropertyValue("Bonus", 45m);
            kernel.Bind<IEmployeesProvider>().To<EmployeesProvider>();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
    }
}