using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Application.ViewModels.Homework
{
    public class HomeworkMarkCreateModel : RequestModel
    {
        [Required]
        public long Id { get; set; }
        [Required, MinLength(1), MaxLength(5)]
        public string Mark { get; set; }
    }
}