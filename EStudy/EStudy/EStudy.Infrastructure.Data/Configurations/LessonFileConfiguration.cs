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
    public class LessonFileConfiguration : IEntityTypeConfiguration<LessonFile>
    {
        public void Configure(EntityTypeBuilder<LessonFile> builder)
        {
            builder.HasKey(d => d.Id);
            builder.HasIndex(d => new
            {
                d.OriginalName,
                d.MD5CheckSum,
                d.Path,
                d.LessonId,
                d.Extension
            });
        }
    }
}