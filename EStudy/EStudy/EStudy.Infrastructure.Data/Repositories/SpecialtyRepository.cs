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
    public class SpecialtyRepository : Repository<Specialty>, ISpecialtyRepository
    {
        public async Task<List<Specialty>> GetAllShortSpecialtyAsync()
        {
            return await db.Specialties.AsNoTracking()
                .Select(d => new Specialty
                {
                    Id = d.Id,
                    Name = d.Name
                }).ToListAsync();
        }
    }
}