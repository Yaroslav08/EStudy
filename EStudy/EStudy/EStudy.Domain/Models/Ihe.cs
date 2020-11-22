using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Domain.Models
{
    public class IHE : BaseModel<int>
    {
        [Required, MinLength(3), MaxLength(200)]
        public string Name { get; set; }
        [MinLength(3), MaxLength(200)]
        public string EnglishName { get; set; }
        [MinLength(2), MaxLength(50)]
        public string ShortName { get; set; }
        public int CodeEDEBO { get; set; }
        [MinLength(2), MaxLength(100)]
        public string Type { get; set; }
        [MinLength(2), MaxLength(200)]
        public string Area { get; set; }
        [MinLength(2), MaxLength(100)]
        public string Accreditation { get; set; }
        [MinLength(5), MaxLength(200)]
        public string Logo { get; set; }
        [MinLength(5), MaxLength(200)]
        public string Logo50 { get; set; }
        [MinLength(5), MaxLength(200)]
        public string Logo150 { get; set; }
        [MinLength(5), MaxLength(1000)]
        public string Description { get; set; }
        [MinLength(4), MaxLength(150)]
        public string AddressInfo { get; set; }
        [MinLength(3), MaxLength(50)]
        public string Locality { get; set; }
        [MinLength(5), MaxLength(50)]
        public string Region { get; set; }
        [MinLength(3), MaxLength(6)]
        public string PostalCode { get; set; }
        [Required, MinLength(15), MaxLength(20)]
        public string CodeForTeacher { get; set; }
        [Required, MinLength(15), MaxLength(20)]
        public string CodeForStudent { get; set; }
        public List<Department> Departments { get; set; }
    }
}