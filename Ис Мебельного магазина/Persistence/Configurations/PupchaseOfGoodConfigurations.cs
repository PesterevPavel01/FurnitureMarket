using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Ис_Мебельного_магазина.Domain.Models;

namespace Ис_Мебельного_магазина.Persistence.Configurations
{
    public class PupchaseOfGoodConfigurations : IEntityTypeConfiguration<PurchaseOfGoods>
    {
        public void Configure(EntityTypeBuilder<PurchaseOfGoods> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.PurchaseType)
            .HasMaxLength(40);
            builder.Property(d => d.PurchasePrise)
            .HasMaxLength(40);
            builder.Property(d => d.PurchaseType)
         .HasMaxLength(40);
            builder.Property(d => d.PurchaseDescription)
         .HasMaxLength(40);
            builder.Property(d => d.PurchaseVolume)
         .HasMaxLength(40);
        }
    }
}
