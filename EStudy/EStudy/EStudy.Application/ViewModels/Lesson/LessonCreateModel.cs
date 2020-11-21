using EStudy.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Application.ViewModels.Lesson
{
    public class LessonCreateModel : RequestModel
    {
        [Required, MinLength(3), MaxLength(50)]
        public string Theme { get; set; }
        [MinLength(5), MaxLength(2500)]
        public string Text { get; set; }
        [Required]
        public DateTime DateLesson { get; set; }
        [Required]
        public TypeLesson TypeLesson { get; set; }
        public int CourseId { get; set; }
    }
}