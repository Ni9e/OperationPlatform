using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// add new references
using OperationPlatform.Domain.Abstract;
using OperationPlatform.Domain.Entities;

namespace OperationPlatform.Domain.Concrete
{
    public class EFProductRepository : IProductsRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Product> Products
        {
            get { return context.Products; }
        }

        public void SaveProduct(Product product)
        {
            if (product.ProductID == 0)
            {
                context.Products.Add(product);
            }
            else
            {
                Product p = context.Products.FirstOrDefault(m => m.ProductID == product.ProductID);
                p.Name = product.Name;
                p.Description = product.Description;
                p.Price = product.Price;
                p.Category = product.Category;
                p.ImageData = product.ImageData;
                p.ImageMimeType = product.ImageMimeType;                
            }

            context.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            context.Products.Remove(product);
            context.SaveChanges();
        }
    }
}
