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
        public async Task<List<Group>> SearchGroupsAsync(string name, bool isReleased)
        {
            return await db.Groups.AsNoTracking()
                    .Where(d => d.Name.Contains(name) && d.IsReleased == isReleased)
                    .OrderByDescending(d => d.CreatedAt)
                    .ToListAsync();
        }
    }
}