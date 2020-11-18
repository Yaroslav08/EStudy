using EStudy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Domain.Interfaces
{
    public interface IGroupMemberRepository : IRepository<GroupMember>
    {
        Task<bool> IsClassTeacherAsync(int groupId, int userId);
        Task<bool> IsHeadmanAsync(int groupId, int userId);
        Task<bool> IsStudentAsync(int groupId, int userId);
        Task<bool> IsMemberGroupAsync(int groupId, int userId);
    }
}