using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Domain.Models
{
    public class LessonFile
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; } = Guid.NewGuid().ToString("N");
        [Required]
        public DateTime CreatedAt { get; set; }
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
        public Lesson Lesson { get; set; }
    }
}