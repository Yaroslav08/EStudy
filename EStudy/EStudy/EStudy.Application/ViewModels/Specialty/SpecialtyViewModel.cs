using EStudy.Application.ViewModels.Department;
using EStudy.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Application.ViewModels.Specialty
{
    public class SpecialtyViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public string Shifr { get; set; }
        public string Code { get; set; }
        public TypeDiploma Qualification { get; set; }
        public string EducationalProgram { get; set; }
        public string ProfessionalQualification { get; set; }
        public string About { get; set; }
        public DepartmentViewModel Department { get; set; }
    }
}