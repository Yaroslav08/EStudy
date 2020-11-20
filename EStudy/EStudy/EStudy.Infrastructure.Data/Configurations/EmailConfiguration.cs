using EStudy.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Infrastructure.Data.Configurations
{
    public class EmailConfiguration : IEntityTypeConfiguration<Email>
    {
        public void Configure(EntityTypeBuilder<Email> builder)
        {
            builder.HasKey(d => d.Id);
            builder.HasIndex(d => new
            {
                d.Address,
                d.Password,
                d.Title,
                d.Key
            });
        }
    }
}