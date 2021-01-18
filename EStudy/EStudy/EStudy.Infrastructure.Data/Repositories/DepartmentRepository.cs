using EStudy.Domain.Interfaces;
using EStudy.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Infrastructure.Data.Repositories
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public async Task<List<Department>> GetAllShortDepartmentsAsync()
        {
            return await db.Departments.AsNoTracking().Select(d => new Department
            {
                Id = d.Id,
                Name = d.Name
            }).ToListAsync();
        }

        public async Task<int> GetUniversityId()
        {
            var university = await db.Universities.AsNoTracking().Select(d => new University { Id = d.Id }).SingleOrDefaultAsync();
            return university.Id;
        }

        public async Task<List<Department>> SearchAsync(string q)
        {
            return await db.Departments
                .AsNoTracking()
                .Where(d => d.Name.Contains(q) || d.Phone.Contains(q))
                .ToListAsync();
        }
    }
}