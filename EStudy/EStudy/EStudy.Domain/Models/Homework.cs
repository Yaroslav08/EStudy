﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Domain.Models
{
    public class Homework : BaseModel<long>
    {
        [Required]
        public bool IsComplate { get; set; } = false;
        [MinLength(2), MaxLength(500)]
        public string Text { get; set; }
        [MinLength(5), MaxLength(500)]
        public string Links { get; set; }
        [MinLength(1), MaxLength(5)]
        public string Mark { get; set; }
        public DateTime? MarkSetAt { get; set; }
        public int UserSetMark { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
        public long LessonId { get; set; }
        public Lesson Lesson { get; set; }
        public List<HomeworkFile> HomeworkFiles { get; set; }
    }
}