using AutoMapper;
using EStudy.Application.Interfaces;
using EStudy.Application.ViewModels.Group;
using EStudy.Domain.Models;
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
            var group = mapper.Map<Group>(model);
            group.CreatedFromIP = model.IP;
            group.CreatedByUserId = model.UserId;
            return await unitOfWork.GroupRepository.CreateAsync(group);
        }

        public async Task<string> EditGroup(GroupEditModel model)
        {
            var group = await unitOfWork.GroupRepository.GetByWhereAsync(d => d.Id == model.Id);
            if (group == null) return Constants.Constants.GroupNotFound;
            var editGroup = mapper.Map<Group>(model);
            editGroup.Id = group.Id;
            editGroup.CreatedAt = group.CreatedAt;
            editGroup.CreatedByUserId = group.CreatedByUserId;
            editGroup.CreatedFromIP = group.CreatedFromIP;
            editGroup.IsEdit = true;
            editGroup.DateLastEdit = DateTime.Now;
            editGroup.EditedByUserId = model.UserId;
            editGroup.EditedFromIP = model.IP;
            return await unitOfWork.GroupRepository.UpdateAsync(editGroup);
        }

        public async Task<GroupViewModel> GetGroupById(int id)
        {
            return mapper.Map<GroupViewModel>(await unitOfWork.GroupRepository.GetByWhereAsync(d => d.Id == id));
        }

        public async Task<List<GroupViewModel>> SearchGroups(string name, int count, int skip, bool? isReleased = null)
        {
            return mapper.Map<List<GroupViewModel>>(await unitOfWork.GroupRepository.SearchGroupsAsync(name, count, skip, isReleased));
        }

        public async Task<string> CreateEmail(EmailCreateModel model)
        {
            var email = mapper.Map<Email>(model);
            email.CreatedFromIP = model.IP;
            email.CreatedByUserId = model.UserId;
            return await unitOfWork.EmailRepository.CreateAsync(email);
        }

        public async Task<string> EditEmail(EmailEditModel model)
        {
            var email = await unitOfWork.EmailRepository.GetByWhereAsync(d => d.Id == model.Id);
            if (email == null) return Constants.Constants.EmailNotFound;
            var editEmail = mapper.Map<Email>(model);
            editEmail.Id = email.Id;
            editEmail.CreatedAt = email.CreatedAt;
            editEmail.CreatedByUserId = email.CreatedByUserId;
            editEmail.CreatedFromIP = email.CreatedFromIP;
            editEmail.IsEdit = true;
            editEmail.DateLastEdit = DateTime.Now;
            editEmail.EditedByUserId = model.UserId;
            editEmail.EditedFromIP = model.IP;
            return await unitOfWork.EmailRepository.UpdateAsync(editEmail);
        }

        public async Task<List<EmailViewModel>> GetEmailsByGroupId(int groupId)
        {
            return mapper.Map<List<EmailViewModel>>(await unitOfWork.EmailRepository.GetListByWhereAsync(d => d.GroupId == groupId));
        }
    }
}