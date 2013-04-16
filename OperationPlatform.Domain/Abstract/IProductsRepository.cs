using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// add new reference
using OperationPlatform.Domain.Entities;

namespace OperationPlatform.Domain.Abstract
{
    public interface IProductsRepository
    {
        IQueryable<Product> Products { get; }

        void SaveProduct(Product product);

        void DeleteProduct(Product product);
    }
}
