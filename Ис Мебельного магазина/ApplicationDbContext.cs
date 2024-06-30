using Microsoft.EntityFrameworkCore;
using Ис_Мебельного_магазина.Domain.Models;
using Ис_Мебельного_магазина.Persistence.Configurations;

namespace Ис_Мебельного_магазина
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Category> categories{get;set;} = null!;
        public DbSet<Employee> employees { get; set; } = null!;
        public DbSet<Provider> providers{ get; set; } = null!;
        public DbSet<Purchase> purchaseOfGoods{ get; set; } = null!;
        public DbSet<Product> products { get; set; } = null!;
        public DbSet<Bascket> basckets { get; set; } = null!;


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfigurations());
            modelBuilder.ApplyConfiguration(new Employeeconfigurations());
            modelBuilder.ApplyConfiguration(new ProviderConfigurations());
            modelBuilder.ApplyConfiguration(new PupchaseOfGoodConfigurations());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new BascketConfiguration());
        }

    }
}
