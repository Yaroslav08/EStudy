using EStudy.Domain.Interfaces;
using EStudy.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Infrastructure.Data.Repositories
{
    public class HomeworkRepository : Repository<Homework>, IHomeworkRepository
    {
        public async Task<List<Homework>> GetHomeworkByCourseIdOfStudentAsync(int courseId, int userId)
        {
            var lessons = await db.Lessons.AsNoTracking()
                .Include(d => d.Homeworks.Where(d => d.UserId == userId))
                .Where(d => d.CourseId == courseId)
                .ToListAsync();
            var homeworks = new List<Homework>();
            lessons.ForEach(d =>
            {
                d.Homeworks.ForEach(d =>
                {
                    homeworks.Add(d);
                });
            });

            return homeworks;
        }
    }
}