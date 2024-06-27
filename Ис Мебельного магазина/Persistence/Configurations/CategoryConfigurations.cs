using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ис_Мебельного_магазина.Domain.Models;

namespace Ис_Мебельного_магазина.Persistence.Configurations
{
    public class CategoryConfigurations : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.NameCategory)
            .HasMaxLength(40);
            builder.Property(d => d.ExtraCharge)
            .HasMaxLength(40);
            builder.Property(d => d.Description)
            .HasMaxLength(40);
        }
    }
}
