using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// add new references
using OperationPlatform.Domain.Entities;

namespace OperationPlatform.Domain.Abstract
{
    public interface IOrderProcessor
    {
        void ProcessOrder(Cart cart, ShippingDetails shippingDetails);
    }
}
