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
    public class IHERepository : Repository<IHE>, IIHERepository
    {
        public async Task<bool> ValidStudentCodeConnectAsync(string code)
        {
            return await db.IHEs.AsNoTracking()
                .SingleOrDefaultAsync(d => d.CodeForStudent == code) != null ? true : false;
        }

        public async Task<bool> ValidTeacherCodeConnectAsync(string code)
        {
            return await db.IHEs.AsNoTracking()
                .SingleOrDefaultAsync(d => d.CodeForTeacher == code) != null ? true : false;
        }
    }
}