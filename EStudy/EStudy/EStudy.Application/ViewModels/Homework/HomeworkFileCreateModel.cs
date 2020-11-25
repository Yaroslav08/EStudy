using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Application.ViewModels.Homework
{
    public class HomeworkFileCreateModel : RequestModel
    {
        public string Path { get; set; }
        public string OriginalName { get; set; }
        public long HomeworkId { get; set; }
    }
}