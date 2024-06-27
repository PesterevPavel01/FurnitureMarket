using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ис_Мебельного_магазина.Domain.Models;

namespace Ис_Мебельного_магазина.Domain.Interactors
{
    public class ProductIteractors
    {
        private ApplicationDbContext context;

        public ProductIteractors(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void AddProduct(Product productcatalog)
        {
            context.Add(productcatalog);
            context.SaveChanges();
        }

        public IQueryable<Product> GetAll()
        {
            return context.Set<Product>();
        }

        public Product CreateProduct(Product product)
        {
            try
            {
                context.Add(product);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                return null;
            }

            return product;
        }

        public Product? GetProduct(Product productId)
        {
            return context.products.Find(productId);
        }
        public void Update(Product productcatalog)
        {
            context.Update(productcatalog);
            context.SaveChanges();
        }

        public Product? RemoveProduct(Product product)
        {
            try
            {
                context.Remove(product);
                context.SaveChanges();
                return product;
            }
            catch (Exception ex)
            {
                return null;
            }
            return null ;

        }

    }
}
