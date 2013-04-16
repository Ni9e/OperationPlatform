using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
// add new references
using OperationPlatform.Domain.Entities;
using System.Web.Mvc;

namespace OperationPlatform.WebUI.Binders
{
    // We need to tell the MVC Framework that it can use CartModelBinder class to create instances of Cart.
    public class CartModelBinder : IModelBinder
    {
        private const string sessionKey = "Cart";

        // ControllerContext provides access to all of the information that the controller class has,
        // which includes details of the request from the client.
        // The ModelBindingContext gives you information about the model object you are being asked to build
        // and tools for making it eaiser.
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            // get the Cart from the session
            Cart cart = (Cart)controllerContext.HttpContext.Session[sessionKey];

            if (cart == null)
            {
                cart = new Cart();
                controllerContext.HttpContext.Session[sessionKey] = cart;
            }

            return cart;
        }
    }
}