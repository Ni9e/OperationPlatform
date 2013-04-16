using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// Add new references
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using Moq;
using OperationPlatform.Domain.Entities;
using OperationPlatform.Domain.Abstract;
using OperationPlatform.Domain.Concrete;
using System.Configuration;
using OperationPlatform.WebUI.Infrastructure.Abstract;
using OperationPlatform.WebUI.Infrastructure.Concrete;

namespace OperationPlatform.WebUI.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;

        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        private void AddBindings()
        {
            //Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
            //mock.Setup(m => m.Products).Returns(new List<Product>
            //    {
            //        new Product { Name = "Football", Price = 25 },
            //        new Product { Name = "Surf board", Price = 179 },
            //        new Product { Name = "Running shoes", Price = 95 }
            //    }.AsQueryable());
            ninjectKernel.Bind<IProductsRepository>().To<EFProductRepository>();
            ninjectKernel.Bind<IReports>().To<EFReports>();

            EmailSettings emailSettings = new EmailSettings
            {
                WriteAsFile = bool.Parse(ConfigurationManager.AppSettings["Email.WriteAsFile"] ?? "false")
            };

            ninjectKernel.Bind<IOrderProcessor>().To<EmailOrderProcessor>().WithConstructorArgument("settings", emailSettings);
            ninjectKernel.Bind<IAuthProvider>().To<FormsAuthProvider>();
        }

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }
    }
}