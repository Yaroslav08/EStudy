using EStudy.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Application.ViewModels.Specialty
{
    public class SpecialtyCreateModel : RequestModel
    {
        [Required, MinLength(3), MaxLength(150)]
        public string Name { get; set; }
        [MinLength(2), MaxLength(20)]
        public string Shifr { get; set; }
        [MinLength(2), MaxLength(6)]
        public string Code { get; set; }
        [Required]
        public TypeDiploma Qualification { get; set; }
        [MinLength(5), MaxLength(250)]
        public string EducationalProgram { get; set; }
        [MinLength(5), MaxLength(250)]
        public string ProfessionalQualification { get; set; }
        [MinLength(10), MaxLength(5000)]
        public string About { get; set; }
        public int DepartmentId { get; set; }
    }
}