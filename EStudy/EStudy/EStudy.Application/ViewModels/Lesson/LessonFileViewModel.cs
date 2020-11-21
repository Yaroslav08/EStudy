using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Application.ViewModels.Lesson
{
    public class LessonFileViewModel
    {
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string MD5CheckSum { get; set; }
        public string Extension { get; set; }
        public int SizeInBytes { get; set; }
        public string OriginalName { get; set; }
        public string Path { get; set; }
        public LessonViewModel Lesson { get; set; }
    }
}