using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
// add new references
using OperationPlatform.Domain.Abstract;
using OperationPlatform.WebUI.Models;

namespace OperationPlatform.WebUI.Controllers
{
    public class NavController : Controller
    {
        private IProductsRepository repository;

        public NavController(IProductsRepository repo)
        {
            repository = repo;
        }

        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;
            //IEnumerable<string> categories = repository.Products
            //                                    .Select(x => x.Category)
            //                                    .Distinct()
            //                                    .OrderBy(x => x);
            IEnumerable<string> categories = new string[] { "DeviceReports", "Test" };
            
            return PartialView(categories);
        }

    }
}
