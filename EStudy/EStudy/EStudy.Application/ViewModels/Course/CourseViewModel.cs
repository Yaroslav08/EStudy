using EStudy.Application.ViewModels.Group;
using EStudy.Application.ViewModels.User;
using EStudy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Application.ViewModels.Course
{
    public class CourseViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public int? OrientedOnCourse { get; set; }
        public string Theme { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public bool WithExam { get; set; }
        public int MaxMarkUpToExam { get; set; }
        public int MaxMarkOnExam { get; set; }
        public int CommonHours { get; set; }
        public int? HoursPracticalTasks { get; set; }
        public int? HoursSeminarTasks { get; set; }
        public int? HoursLectures { get; set; }
        public TypeSubject TypeSubject { get; set; }
        public string Literature { get; set; }
        public MarkType FinalMark { get; set; }
        public PreparationLevel Level { get; set; }
        public UserViewModel Teacher { get; set; }
        public GroupViewModel Group { get; set; }
        public List<LessonViewModel> Lessons { get; set; }
    }
}