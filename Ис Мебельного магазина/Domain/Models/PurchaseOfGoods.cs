using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ис_Мебельного_магазина.Domain.Models
{
    public class PurchaseOfGoods
    {
        public int Id { get; set; }
        public int PurchasePrise { get; set; }
        public string PurchaseVolume { get; set; } 
        public string PurchaseType { get; set; } 
        public string PurchaseDescription { get; set; } 


        public Provider? Providers { get; set; }// = new List<Provider>();
        public Category? Categories{ get; set; }// = new List<Category>();
        public List<Product> Products{ get; set; } = new List<Product>();
    }
}
