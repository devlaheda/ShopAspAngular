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
    public class ProductTypeConfiguration : IEntityTypeConfiguration<ProductType>
    {
        public void Configure(EntityTypeBuilder<ProductType> builder)
        {
           // var types = JsonSerializer.Deserialize<List<ProductType>>(File.ReadAllText("../Infrastructure/Data/DataSeed/types.json"));
            builder.Property(t => t.Name).IsRequired();
            //builder.HasData(types);
        
        }
    }
}