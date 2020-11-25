using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Application.ViewModels.Homework
{
    public class FilesLoadModel
    {
        public List<HomeworkFileCreateModel> files { get; set; }
        public int UserId { get; set; }
    }
}