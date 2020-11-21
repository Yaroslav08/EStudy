using EStudy.Application.ViewModels.Course;
using EStudy.Application.ViewModels.Specialty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Application.ViewModels.Group
{
    public class GroupViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public byte Course { get; set; }
        public DateTime StartStudy { get; set; }
        public DateTime EndStudy { get; set; }
        public bool IsReleased { get; set; }
        public byte CountStudents { get; set; }
        public string CodeForConnect { get; set; }
        public string AdditionalInfo { get; set; }
        public string Email { get; set; }
        public List<EmailViewModel> Emails { get; set; }
        public SpecialtyViewModel Specialty { get; set; }
        public List<CourseViewModel> Courses { get; set; }
    }
}