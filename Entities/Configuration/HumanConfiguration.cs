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
    public class HumanConfiguration : IEntityTypeConfiguration<Human>
    {
        public void Configure(EntityTypeBuilder<Human> builder)
        {
            builder.HasData
            (
            new Human
            {
                Id = new Guid("54164014-112a-5a5a-6dd1-cb6db1891308"),
                Name = "Nikita",
                Age = 28,
                ComnataId = new Guid("b4d33fd4-b129-5dfd-2905-13d6416df55a"),
            },
            new Human
            {
                Id = new Guid("ad867425-a5ba-5629-b3b1-ad0d4655bbt8"),
                Name = "Nik",
                Age = 11,
                ComnataId = new Guid("b4d33fd4-b129-5dfd-2905-13d6416df55a"),
            },
            new Human
            {
                Id = new Guid("ed651a8c-1751-7b63-5a58-3519ab79g44d"),
                Name = "Ivan",
                Age = 67,
                ComnataId = new Guid("b4ca4fa1-b184-3cdc-3159-13b2180fa22a"),
            },
            new Human
            {
                Id = new Guid("ad737b1a-0493-1a43-7a78-6583ab97b10h"),
                Name = "fred",
                Age = 45,
                ComnataId = new Guid("b4ca4fa1-b184-3cdc-3159-13b2180fa22a"),
            }
            );
        }
    }
}
