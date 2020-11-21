using EStudy.Application.ViewModels.Course;
using EStudy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Application.ViewModels.Lesson
{
    public class LessonViewModel
    {
        public long Id { get;set; }
        public DateTime CreatedAt { get; set; }
        public string Theme { get; set; }
        public string Text { get; set; }
        public int Mark { get; set; }
        public DateTime DateLesson { get; set; }
        public TypeLesson TypeLesson { get; set; }
        public CourseViewModel Course { get; set; }
        public List<LessonFileViewModel> LessonFiles { get; set; }
    }
}