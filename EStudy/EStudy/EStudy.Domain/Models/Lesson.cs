using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Domain.Models
{
    public class Lesson : BaseModel<long>
    {
        [Required, MinLength(3), MaxLength(50)]
        public string Theme { get; set; }
        [MinLength(5), MaxLength(2500)]
        public string Text { get; set; }
        [Required]
        public int Mark { get; set; }
        public DateTime DateLesson { get; set; } = DateTime.Now;
        [Required]
        public TypeLesson TypeLesson { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public List<LessonFile> LessonFiles { get; set; }
    }

    public enum TypeLesson
    {
        Lecture,
        Seminar,
        Laboratory,
        Independent,
        Exam
    }
}