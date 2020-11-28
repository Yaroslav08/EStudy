﻿using EStudy.Domain.Interfaces;
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
    }
}