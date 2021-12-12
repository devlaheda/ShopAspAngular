using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            
            builder.Property(p=>p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p=>p.Description).IsRequired();
            builder.Property(p=> p.Price).HasColumnType("decimal(18,3)");
            builder.Property(p=>p.PictureUrl).IsRequired();
           // var product = JsonSerializer.Deserialize<List<Product>>(File.ReadAllText("../Infrastructure/Data/DataSeed/products.json"));
           // builder.HasData(product);
        }
    }
}