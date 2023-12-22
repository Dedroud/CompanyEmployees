using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Configuration
{
    public class ComnataConfiguration : IEntityTypeConfiguration<Comnata>
    {
        public void Configure(EntityTypeBuilder<Comnata> builder)
        {
            builder.HasData
            (
            new Comnata
            {
                Id = new Guid("b4d33fd4-b129-5dfd-2905-13d6416df55a"),
                Name = "1",
            },
            new Comnata
            {
                Id = new Guid("b4d33fd4-b129-5dfd-2905-13d6416df55a"),
                Name = "2",
            },
            new Comnata
            {
                Id = new Guid("b4ca4fa1-b184-3cdc-3159-13b2180fa22a"),
                Name = "3",
            }
            );
        }
    }
}
