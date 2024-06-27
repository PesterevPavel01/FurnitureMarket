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
    public class ProviderConfigurations : IEntityTypeConfiguration<Provider>
    {
        public void Configure(EntityTypeBuilder<Provider> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.NumberPhone)
            .HasMaxLength(40);
            builder.Property(d => d.Fax)
            .HasMaxLength(40);
            builder.Property(d => d.Inn)
            .HasMaxLength(40);
            builder.Property(d => d.NameProvider)
           .HasMaxLength(40);
            builder.Property(d => d.additionally)
            .HasMaxLength(40);
        }
    }
}
