using EStudy.Application.ViewModels.Lesson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Application.Interfaces
{
    public interface ILessonService
    {
        Task<List<LessonViewModel>> GetAll();
        Task<List<LessonViewModel>> GetAllLessonsByCourseId(int id);
        Task<LessonViewModel> GetById(long id);
        Task<string> CreateLesson(LessonCreateModel model);
        Task<string> EditLesson(LessonEditModel model);
    }
}