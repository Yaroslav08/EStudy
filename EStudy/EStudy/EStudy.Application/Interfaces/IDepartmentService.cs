using EStudy.Application.ViewModels.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Application.Interfaces
{
    public interface IDepartmentService
    {
        Task<string> CreateDepartment(DepartmentCreateModel model);
        Task<string> EditDepartment(DepartmentCreateModel model);
        Task<List<DepartmentViewModel>> GetDepartments();
        Task<DepartmentViewModel> GetDepartmentById(int id);
    }
}