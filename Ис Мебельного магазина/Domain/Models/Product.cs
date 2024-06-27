using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Ис_Мебельного_магазина.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public string Price { get; set; } 
        public string Firm { get; set; } 
        public int CategoryId { get; set; }
    }
}
