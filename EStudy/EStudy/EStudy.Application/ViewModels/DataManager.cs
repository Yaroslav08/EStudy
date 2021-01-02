using EStudy.Application.Interfaces;
namespace EStudy.Application.ViewModels
{
    public class DataManager : IDataManager
    {
        public DataManager(ICourseService courseService, IDepartmentService departmentService, IGroupService groupService, IHomeworkService homeworkService, ILessonService lessonService, ISpecialtyService specialtyService, IUniversityService universityService, IUserService userService)
        {
            CourseService = courseService;
            DepartmentService = departmentService;
            GroupService = groupService;
            HomeworkService = homeworkService;
            LessonService = lessonService;
            SpecialtyService = specialtyService;
            UniversityService = universityService;
            UserService = userService;
        }

        public ICourseService CourseService { get; set; }
        public IDepartmentService DepartmentService { get; set; }
        public IGroupService GroupService { get; set; }
        public IHomeworkService HomeworkService { get; set; }
        public ILessonService LessonService { get; set; }
        public ISpecialtyService SpecialtyService { get; set; }
        public IUniversityService UniversityService { get; set; }
        public IUserService UserService { get; set; }
    }
}