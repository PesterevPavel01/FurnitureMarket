using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ис_Мебельного_магазина.Domain.Models;

namespace Ис_Мебельного_магазина.Domain.Interactors
{
    public class PurchaseOfGoodsIteractor
    {
        private ApplicationDbContext context;

        public PurchaseOfGoodsIteractor(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void AddProduct(Purchase purchase)
        {
            context.Add(purchase);
            context.SaveChanges();
        }
        public Purchase CreatePurchase(Purchase purchase)
        {
            try
            {
                context.Add(purchase);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                return null;
            }

            return purchase;
        }


        public void GetPurchase(Purchase purchase)
        {
            var s = GetPurchases(purchase);
            if (s is null)
            {
                context.Remove(s);
                context.SaveChanges();
            };
        }

        public void Update(Employee employee)
        {
            context.Update(employee);
            context.SaveChanges();

        }

        public IQueryable<Purchase> GetAll()
        {
            return context.Set<Purchase>();
        }

        public Purchase? GetPurchases(Purchase purchaseId)
        {
            return context.purchaseOfGoods.Find(purchaseId);
        }

        public List<Purchase> GetPurchaseOfGoods()
        {
            IQueryable<Purchase> purchases = context.purchaseOfGoods;

            //categoryes = categoryes.where()
            return purchases.ToList();
        }


    }
}
