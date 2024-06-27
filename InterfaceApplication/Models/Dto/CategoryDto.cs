using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ис_Мебельного_магазина.Domain.Models;

namespace InterfaceApplication.Models.Dto
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string NameCategory { get; set; }
        public string ExtraCharge { get; set; }
        public string Description { get; set; }

        public CategoryDto() { }

        public CategoryDto(Category category) {
            this.Id = category.Id;
            this.NameCategory = category.NameCategory; 
            this.ExtraCharge = category.ExtraCharge;
            this.Description = category.Description;
        }

        public CategoryDto(int id, string nameCategory, string extraCharge, string description)
        {
            Id = id;
            NameCategory = nameCategory;
            ExtraCharge = extraCharge;
            Description = description;
        }
    }
}
