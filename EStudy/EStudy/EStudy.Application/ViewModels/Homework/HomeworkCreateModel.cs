using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Application.ViewModels.Homework
{
    public class HomeworkCreateModel : RequestModel
    {
        [Required]
        public bool IsComplate { get; set; }
        [MinLength(2), MaxLength(500)]
        public string Text { get; set; }
        [MinLength(5), MaxLength(500)]
        public string Links { get; set; }
        public long LessonId { get; set; }
    }
}