using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Application.ViewModels.Lesson
{
    public class LessonFileCreateViewModel : RequestModel
    {
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [MinLength(5), MaxLength(50)]
        public string MD5CheckSum { get; set; }
        [MinLength(2), MaxLength(25)]
        public string Extension { get; set; }
        public int SizeInBytes { get; set; }
        [MinLength(3), MaxLength(150)]
        public string OriginalName { get; set; }
        [MinLength(5), MaxLength(250)]
        public string Path { get; set; }
        public long LessonId { get; set; }
    }
}