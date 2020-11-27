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
        Task<string> EditDepartment(DepartmentEditModel model);
        Task<DepartmentEditModel> GetDepartmentForEdit(int id);
        Task<List<DepartmentViewModel>> GetDepartments();
        Task<DepartmentViewModel> GetDepartmentById(int id);
    }
}