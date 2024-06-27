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
        public void AddProduct(PurchaseOfGoods purchase)
        {
            context.Add(purchase);
            context.SaveChanges();
        }
        public PurchaseOfGoods CreatePurchase(PurchaseOfGoods purchase)
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


        public void GetPurchase(PurchaseOfGoods purchase)
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

        public IQueryable<PurchaseOfGoods> GetAll()
        {
            return context.Set<PurchaseOfGoods>();
        }

        public PurchaseOfGoods? GetPurchases(PurchaseOfGoods purchaseId)
        {
            return context.purchaseOfGoods.Find(purchaseId);
        }

        public List<PurchaseOfGoods> GetPurchaseOfGoods()
        {
            IQueryable<PurchaseOfGoods> purchases = context.purchaseOfGoods;

            //categoryes = categoryes.where()
            return purchases.ToList();
        }


    }
}
