using EStudy.Application.ViewModels.Department;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Application.ViewModels.IHE
{
    public class IHEViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public string EnglishName { get; set; }
        public string ShortName { get; set; }
        public int CodeEDEBO { get; set; }
        public string Type { get; set; }
        public string Area { get; set; }
        public string Accreditation { get; set; }
        public string Logo { get; set; }
        public string Logo50 { get; set; }
        public string Logo150 { get; set; }
        public string Description { get; set; }
        public string AddressInfo { get; set; }
        public string Locality { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public List<DepartmentViewModel> Departments { get; set; }
    }
}