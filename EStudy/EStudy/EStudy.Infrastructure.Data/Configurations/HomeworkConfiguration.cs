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
    public class HomeworkConfiguration : IEntityTypeConfiguration<Homework>
    {
        public void Configure(EntityTypeBuilder<Homework> builder)
        {
            builder.HasKey(d => d.Id);
            builder.HasIndex(d => new
            {
                d.UserId,
                d.LessonId,
                d.IsComplate,
                d.Text
            });
            builder.HasOne(d => d.Lesson).WithMany(d => d.Homeworks).HasForeignKey(d => d.LessonId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(d => d.User).WithMany(d => d.Homeworks).HasForeignKey(d => d.UserId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}