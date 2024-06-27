using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ис_Мебельного_магазина.Domain.Models;

namespace Ис_Мебельного_магазина.Domain.Interactors
{
    public class ProviderIteractor
    {
        private ApplicationDbContext context;

        public ProviderIteractor(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void AddProvider(Provider provider)
        {
            context.Add(provider);
            context.SaveChanges();
        }
        public void UpDate(Provider provider)
        {
            context.Update(provider);
            context.SaveChanges();
        }

        public void RemoveProvider(Provider provider)
        {
            context.Remove(provider);
            context.SaveChanges();
        }
    }
}
