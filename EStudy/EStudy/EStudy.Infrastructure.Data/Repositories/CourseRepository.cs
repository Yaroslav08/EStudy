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
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public async Task<List<Course>> GetCoursesByGroupIdAsync(int id)
        {
            return await db.Courses.AsNoTracking()
                .Where(d => d.GroupId == id)
                .Select(d => new Course
                {
                    Id = d.Id,
                    CreatedAt = d.CreatedAt,
                    Name = d.Name,
                    ShortName = d.ShortName,
                    Start = d.Start,
                    End = d.End
                }).ToListAsync();
        }

        public async Task<List<Course>> GetCoursesByTeacherId(int id)
        {
            return await db.Courses.AsNoTracking()
                .Where(d => d.TeacherId == id)
                .Select(d => new Course
                {
                    Id = d.Id,
                    Name = d.Name,
                    ShortName = d.ShortName,
                    Start = d.Start,
                    End = d.End
                })
                .ToListAsync();
        }
    }
}