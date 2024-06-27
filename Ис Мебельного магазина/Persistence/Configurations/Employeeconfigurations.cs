using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ис_Мебельного_магазина.Domain.Models;

namespace Ис_Мебельного_магазина.Persistence.Configurations
{
    public class Employeeconfigurations : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Address).HasMaxLength(40);
            builder.Property(d => d.NameEmployee).IsRequired().HasMaxLength(40);
            builder.Property(d => d.Login).IsRequired().HasMaxLength(50);
            builder.Property(d => d.Password).IsRequired().HasMaxLength(50);
            builder.Property(d => d.Status).HasDefaultValue("user").HasMaxLength(50);
        }
    }
}
