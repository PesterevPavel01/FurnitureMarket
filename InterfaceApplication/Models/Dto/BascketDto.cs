using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ис_Мебельного_магазина.Domain.Models;

namespace InterfaceApplication.Models.Dto
{
    public class BascketDto
    {
        public int Id { get; set; }
        public double Number { get; set; }
        public int EmployeeId { get; set; }
        public int ProductId { get; set; }

        public BascketDto() { }

        public BascketDto(Bascket basket)
        {
            this.Id = basket.Id;
            this.Number = basket.Number;
            this.EmployeeId= basket.EmployeeId;
            this.ProductId = basket.ProductId;
        }

        public BascketDto(int id, double number, int employeeId, int productId)
        {
            Id = id;
            Number = number;
            EmployeeId = employeeId;
            ProductId = productId;
        }
    }
}
