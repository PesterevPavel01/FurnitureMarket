using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ис_Мебельного_магазина.Domain.Models;

namespace InterfaceApplication.Models.Dto
{
    public class EmployeeDto
    {
        public short Id { get; set; }
        public string NameEmployee { get; set; }
        public string Address { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Status { get; set; }

        public EmployeeDto() { }

        public EmployeeDto(short id, string name, string address, string login, string password, string status) 
        {
            Id = id;
            NameEmployee = name;
            Address = address;
            Login = login;
            Password = password;
            Status = status;
        }

    }
}
