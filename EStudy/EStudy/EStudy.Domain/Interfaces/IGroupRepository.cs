using EStudy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Domain.Interfaces
{
    public interface IGroupRepository : IRepository<Group>
    {
        Task<List<Group>> SearchGroupsAsync(string name, bool isReleased);
    }
}