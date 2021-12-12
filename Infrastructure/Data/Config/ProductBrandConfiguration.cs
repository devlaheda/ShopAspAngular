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
    public class ProductBrandConfiguration : IEntityTypeConfiguration<ProductBrand>
    {
        public void Configure(EntityTypeBuilder<ProductBrand> builder)
        {
           // var brands = JsonSerializer.Deserialize<List<ProductBrand>>(File.ReadAllText("../Infrastructure/Data/DataSeed/brands.json"));
            builder.Property(Pb => Pb.Name).IsRequired();
          // builder.HasData(brands);
        }
    }
}