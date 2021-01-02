using EStudy.Application.Interfaces;
namespace EStudy.Application
{
    public interface IDataManager
    {
        ICourseService CourseService { get; set; }
        IDepartmentService DepartmentService { get; set; }
        IGroupService GroupService { get; set; }
        IHomeworkService HomeworkService { get; set; }
        ILessonService LessonService { get; set; }
        ISpecialtyService SpecialtyService { get; set; }
        IUniversityService UniversityService { get; set; }
        IUserService UserService { get; set; }
    }
}