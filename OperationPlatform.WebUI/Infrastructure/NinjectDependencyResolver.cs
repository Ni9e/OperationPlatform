using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// add new references
using System.Web.Mvc;
using Ninject;
using Ninject.Parameters;
using Ninject.Syntax;
using OperationPlatform.Domain.Abstract;
using OperationPlatform.Domain.Concrete;
using OperationPlatform.WebUI.Infrastructure.Abstract;
using OperationPlatform.WebUI.Infrastructure.Concrete;
using System.Configuration;

namespace OperationPlatform.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver()
        {
            kernel = new StandardKernel();
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        public IBindingToSyntax<T> Bind<T>()
        {
            return kernel.Bind<T>();
        }

        public IKernel Kernel
        {
            get { return kernel; }
        }

        private void AddBindings()
        {
            Bind<IProductsRepository>().To<EFProductRepository>();
            Bind<IAuthProvider>().To<FormsAuthProvider>();
            Bind<IReports>().To<EFReports>();

            EmailSettings emailSettings = new EmailSettings
            {
                WriteAsFile = bool.Parse(ConfigurationManager.AppSettings["Email.WriteAsFile"] ?? "false")
            };
            Bind<IOrderProcessor>().To<EmailOrderProcessor>().WithConstructorArgument("settings", emailSettings);
        }
    }
}