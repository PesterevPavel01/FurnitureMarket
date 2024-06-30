using Ис_Мебельного_магазина.Domain.Models;

namespace InterfaceApplication.Models.Dto
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Firm { get; set; }
        public int CategoryId { get; set; }

        public ProductDto() { }

        public ProductDto(int id, string name, string price, string firm)
        {
            Id = id;
            Name = name;
            Price = price;
            Firm = firm;
        }

        public ProductDto (Product product)
        {
            this.Id = product.Id;
            this.Name = product.Name;
            this.Price = product.Price;
            this.Firm = product.Firm;

        }
    }
}
