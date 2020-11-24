using EStudy.Application.ViewModels.Homework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Application.Interfaces
{
    public interface IHomeworkService
    {
        Task<List<HomeworkViewModel>> GetAll();
        Task<List<HomeworkViewModel>> GetHomeworkByUserId(int id);
        Task<List<HomeworkViewModel>> GetHomeworkByLessonId(long id);
        Task<List<HomeworkViewModel>> GetHomeworkByCourseIdOfStudent(int id, int userId);
        Task<string> CreateHomework(HomeworkCreateModel model);
        Task<string> SetMark(HomeworkMarkCreateModel model);
        Task<string> EditHomework(HomeworkEditModel model);
    }
}