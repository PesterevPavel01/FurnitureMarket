using System.Collections.Generic;
using Ис_Мебельного_магазина.Domain.Models;

namespace Ис_Мебельного_магазина.Domain.Interactors
{
    public class BascketInteractor
    {
        private ApplicationDbContext context;

        public BascketInteractor(ApplicationDbContext context)
        {
            this.context = context;
        }
        public Bascket AddBascket(Bascket buscket)
        {
            try {
                context.Add(buscket);
                context.SaveChanges();
            } catch {
                return null;
            }

            return buscket;
        }

        public Bascket? GetBascket(int id)
        {
            return GetAll().FirstOrDefault(b=>b.Id==id);
        }

        public Bascket RemoveCategory(Bascket bascket)
        {
            Bascket currentBascket = GetBascket(bascket.Id);
            if (currentBascket is null)
            {
                try {
                    context.Remove(currentBascket);
                    context.SaveChanges();
                } catch {
                    return null;
                }
                return currentBascket;
            }
            return null;
        }

        public IQueryable<Bascket> GetAll()
        {
            return context.Set<Bascket>();
        }
    }
}
