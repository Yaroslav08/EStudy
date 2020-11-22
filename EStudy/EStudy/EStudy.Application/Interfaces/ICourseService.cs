using EStudy.Application.ViewModels.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Application.Interfaces
{
    public interface ICourseService
    {
        Task<CourseViewModel> GetCourseById(int id);
        Task<List<CourseViewModel>> GetAll();
        Task<List<CourseViewModel>> GetCoursesByGroupId(int groupId);
        Task<string> CreateCourse(CourseCreateModel model);
        Task<string> EditCourse(CourseEditModel model);
    }
}