using EStudy.Application.ViewModels.Lesson;
using EStudy.Application.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Application.ViewModels.Homework
{
    public class HomeworkViewModel
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsComplate { get; set; }
        public string Text { get; set; }
        public string Links { get; set; }
        public string Mark { get; set; }
        public DateTime? MarkSetAt { get; set; }
        public UserViewModel User { get; set; }
        public LessonViewModel Lesson { get; set; }
    }
}