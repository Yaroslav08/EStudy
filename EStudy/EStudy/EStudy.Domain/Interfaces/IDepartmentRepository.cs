using EStudy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Domain.Interfaces
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        Task<List<Department>> GetAllShortDepartmentsAsync();
        Task<int> GetUniversityId();
        Task<List<Department>> SearchAsync(string q);
    }
}