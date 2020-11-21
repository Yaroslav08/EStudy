using EStudy.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Application.ViewModels.Course
{
    public class CourseEditModel : RequestModel
    {
        [Required]
        public int Id { get; set; }
        [Required, MinLength(7), MaxLength(100)]
        public string Name { get; set; }
        [MinLength(2), MaxLength(50)]
        public string ShortName { get; set; }
        public int? OrientedOnCourse { get; set; }
        [MinLength(3), MaxLength(250)]
        public string Theme { get; set; }
        [Required]
        public DateTime Start { get; set; } = DateTime.Now;
        [Required]
        public DateTime End { get; set; } = DateTime.Now.AddMonths(4);
        [Required]
        public bool WithExam { get; set; } = false;
        [Required]
        public int MaxMarkUpToExam { get; set; } = 50;
        [Required]
        public int MaxMarkOnExam { get; set; } = 50;
        [Required]
        public int CommonHours { get; set; }
        public int? HoursPracticalTasks { get; set; }
        public int? HoursSeminarTasks { get; set; }
        public int? HoursLectures { get; set; }
        [Required]
        public TypeSubject TypeSubject { get; set; }
        [MinLength(5), MaxLength(1000)]
        public string Literature { get; set; }
        [Required]
        public MarkType FinalMark { get; set; }
        [Required]
        public PreparationLevel Level { get; set; }
        public int TeacherId { get; set; }
    }
}