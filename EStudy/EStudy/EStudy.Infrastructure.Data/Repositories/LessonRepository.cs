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
    public class LessonRepository : Repository<Lesson>, ILessonRepository
    {
        public async Task<List<Lesson>> GetAllLessonsByCourseIdAsync(int id)
        {
            return await db.Lessons.AsNoTracking()
                .Where(d => d.CourseId == id)
                .Select(d => new Lesson
                {
                    Id = d.Id,
                    Theme = d.Theme,
                    DateLesson = d.DateLesson,
                    TypeLesson = d.TypeLesson
                })
                .ToListAsync();
        }
    }
}