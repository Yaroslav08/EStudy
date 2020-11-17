using EStudy.Application.ViewModels.Group;
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
    }
}