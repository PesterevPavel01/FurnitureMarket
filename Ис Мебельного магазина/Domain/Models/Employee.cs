using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ис_Мебельного_магазина.Domain.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string NameEmployee { get; set; }
        public string?  Address{ get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string? Status { get; set; }
    }
}
