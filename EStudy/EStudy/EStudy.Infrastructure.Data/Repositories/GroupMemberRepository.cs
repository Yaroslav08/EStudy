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
    public class GroupMemberRepository : Repository<GroupMember>, IGroupMemberRepository
    {
        public async Task<List<GroupMember>> GetGroupMembersAsync(int id)
        {
            return await db.GroupMembers
                .AsNoTracking()
                .Where(d => d.GroupId == id)
                .Include(d => d.User)
                .ToListAsync();
        }

        public async Task<bool> IsClassTeacherAsync(int groupId, int userId)
        {
            var member = await db.GroupMembers.AsNoTracking().FirstOrDefaultAsync(d => d.GroupId == groupId && d.UserId == userId);
            if (member == null) return false;
            if (member.MemberRole == Domain.Models.Enums.GroupMemberRole.ClassTeacher)
                return true;
            return false;
        }

        public async Task<bool> IsHeadmanAsync(int groupId, int userId)
        {
            var member = await db.GroupMembers.AsNoTracking().FirstOrDefaultAsync(d => d.GroupId == groupId && d.UserId == userId);
            if (member == null) return false;
            if (member.MemberRole == Domain.Models.Enums.GroupMemberRole.Headman)
                return true;
            return false;
        }

        public async Task<bool> IsMemberGroupAsync(int groupId, int userId)
        {
            var member = await db.GroupMembers.AsNoTracking().FirstOrDefaultAsync(d => d.GroupId == groupId && d.UserId == userId);
            if (member == null)
                return false;
            return true;
        }

        public async Task<bool> IsStudentAsync(int groupId, int userId)
        {
            var member = await db.GroupMembers.AsNoTracking().FirstOrDefaultAsync(d => d.GroupId == groupId && d.UserId == userId);
            if (member == null) return false;
            if (member.MemberRole == Domain.Models.Enums.GroupMemberRole.Student)
                return true;
            return false;
        }
    }
}