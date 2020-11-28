using EStudy.Application.ViewModels.Group;
using EStudy.Application.ViewModels.Specialty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Application.Interfaces
{
    public interface IGroupService
    {
        Task<string> CreateGroup(GroupCreateModel model);
        Task<string> EditGroup(GroupEditModel model);
        Task<GroupViewModel> GetGroupById(int id);
        Task<List<GroupViewModel>> SearchGroups(string name, int count, int skip, bool? isReleased = null);

        Task<string> CreateEmail(EmailCreateModel model);
        Task<string> EditEmail(EmailEditModel model);
        Task<List<EmailViewModel>> GetEmailsByGroupId(int groupId);

        Task<string> AddUserToGroup(GroupMemberModel model);
        Task<string> EditGroupMember(GroupMemberModel model);
        Task<int> GetCountStudents(int groupId);

        Task<List<GroupViewModel>> GetAllGroups();
        Task<List<SpecialtyViewModel>> GetAllSpecialties();
        Task<List<GroupViewModel>> Search(string q, int count, int skip, bool? IsReleased);
    }
}