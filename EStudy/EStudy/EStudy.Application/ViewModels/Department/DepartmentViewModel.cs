using EStudy.Application.ViewModels.IHE;
using EStudy.Application.ViewModels.Specialty;
using EStudy.Application.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Application.ViewModels.Department
{
    public class DepartmentViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public string Shifr { get; set; }
        public UserViewModel Head { get; set; }
        public string Phone { get; set; }
        public string ContactInformation { get; set; }
        public string Description { get; set; }
        public IHEViewModel IHE { get; set; }
        public List<SpecialtyViewModel> Specialties { get; set; }
    }
}