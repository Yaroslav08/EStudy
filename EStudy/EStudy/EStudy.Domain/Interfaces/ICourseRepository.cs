using EStudy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Domain.Interfaces
{
    public interface ICourseRepository : IRepository<Course>
    {
        Task<List<Course>> GetCoursesByGroupIdAsync(int id);
        Task<List<Course>> GetCoursesByTeacherId(int id);
    }
}