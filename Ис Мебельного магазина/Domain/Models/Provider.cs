using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ис_Мебельного_магазина.Domain.Models
{
    public class Provider
    {
        public int Id { get; set; }
        public int NumberPhone { get; set; }
        public int Fax { get; set; }
        public int Inn { get; set; }
        public string NameProvider { get; set; } = "";
        public string? additionally { get; set; }

        public List<PurchaseOfGoods> purchaseOfGoods{ get; set; } = new List<PurchaseOfGoods>();
    }
}
