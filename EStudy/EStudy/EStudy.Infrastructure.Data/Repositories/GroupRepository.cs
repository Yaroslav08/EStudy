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
    public class GroupRepository : Repository<Group>, IGroupRepository
    {
        public async Task<List<Group>> SearchGroupsAsync(string name, int count, int skip, bool? isReleased)
        {
            if (isReleased == null)
            {
                return await db.Groups.AsNoTracking()
                    .Where(d => d.Name.Contains(name))
                    .Skip(skip).Take(count)
                    .OrderByDescending(d => d.CreatedAt)
                    .ToListAsync();
            }
            return await db.Groups.AsNoTracking()
                    .Where(d => d.Name.Contains(name) && d.IsReleased == Convert.ToBoolean(isReleased))
                    .Skip(skip).Take(count)
                    .OrderByDescending(d => d.CreatedAt)
                    .ToListAsync();
        }
    }
}