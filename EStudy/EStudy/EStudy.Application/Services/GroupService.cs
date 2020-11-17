using AutoMapper;
using EStudy.Application.Interfaces;
using EStudy.Application.ViewModels.Group;
using EStudy.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Application.Services
{
    public class GroupService : IGroupService
    {
        private IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public GroupService(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }

        public async Task<string> CreateGroup(GroupCreateModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<string> EditGroup(GroupEditModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<GroupViewModel> GetGroupById(int id)
        {
            return mapper.Map<GroupViewModel>(await unitOfWork.GroupRepository.GetByWhereAsync(d => d.Id == id));
        }

        public async Task<List<GroupViewModel>> SearchGroups(string name, int count, int skip, bool? isReleased = null)
        {
            return mapper.Map<List<GroupViewModel>>(await unitOfWork.GroupRepository.SearchGroupsAsync(name, count, skip, isReleased));
        }
    }
}