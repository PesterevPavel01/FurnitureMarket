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
    internal class BascketConfiguration:IEntityTypeConfiguration<Bascket>
    {
        public void Configure(EntityTypeBuilder<Bascket> builder)
        {
            builder.HasKey(d => d.Id);    
        }
    }
}
