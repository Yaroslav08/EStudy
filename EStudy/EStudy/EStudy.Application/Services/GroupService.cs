using AutoMapper;
using EStudy.Application.Interfaces;
using EStudy.Application.ViewModels.Group;
using EStudy.Application.ViewModels.Specialty;
using EStudy.Domain.Models;
using EStudy.Domain.Models.Enums;
using EStudy.Infrastructure.Data;
using Extensions;
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
            group.CodeForConnect = Generator.GetString(11, false, true);
            return await unitOfWork.GroupRepository.CreateAsync(group);
        }

        public async Task<string> EditGroup(GroupEditModel model)
        {
            var group = await unitOfWork.GroupRepository.GetByWhereAsTrackingAsync(d => d.Id == model.Id);
            if (group == null) return Constants.Constants.GroupNotFound;
            return await unitOfWork.GroupRepository.UpdateAsync(model.GetGroupToDb(group));
        }

        public async Task<GroupViewModel> GetGroupById(int id)
        {
            return mapper.Map<GroupViewModel>(await unitOfWork.GroupRepository.GetByWhereAsync(d => d.Id == id));
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

        public async Task<string> AddUserToGroup(GroupMemberModel model)
        {
            var group = await unitOfWork.GroupRepository.FindByIdAsync(model.GroupId);
            if (group == null)
                return Constants.Constants.GroupNotFound;
            var groupMember = new GroupMember
            {
                GroupId = model.GroupId,
                UserId = model.UserId,
                Title = model.Title
            };
            groupMember.CreatedByUserId = model.UserId;
            groupMember.CreatedFromIP = model.IP;
            groupMember.MemberRole = model.MemberRole switch
            {
                GroupMemberRoleModel.ClassTeacher => GroupMemberRole.ClassTeacher,
                GroupMemberRoleModel.Headman => GroupMemberRole.Headman,
                GroupMemberRoleModel.Student => GroupMemberRole.Student,
                _=> throw new ArgumentNullException()
            };
            var result = await unitOfWork.GroupMemberRepository.CreateAsync(groupMember);
            return await unitOfWork.GroupRepository.UpdateAsync(group);
        }

        public async Task<string> EditGroupMember(GroupMemberModel model)
        {
            var groupMember = await unitOfWork.GroupMemberRepository.FindByIdAsync(model.Id);
            if (groupMember == null)
                return Constants.Constants.GroupMemberNotFound;
            groupMember.GroupId = model.GroupId;
            groupMember.Title = model.Title;
            groupMember.EditedByUserId = model.UserId;
            groupMember.EditedFromIP = model.IP;
            return await unitOfWork.GroupMemberRepository.UpdateAsync(groupMember);
        }

        public async Task<int> GetCountStudents(int groupId)
        {
            return await unitOfWork.GroupMemberRepository
                .CountAsync(d => d.GroupId == groupId && d.MemberRole != GroupMemberRole.ClassTeacher);
        }

        public async Task<List<GroupViewModel>> GetAllGroups()
        {
            return mapper.Map<List<GroupViewModel>>(await unitOfWork.GroupRepository.GetAllAsync())
                .OrderByDescending(d => d.CreatedAt).ToList();
        }

        public async Task<List<SpecialtyViewModel>> GetAllSpecialties()
        {
            return mapper.Map<List<SpecialtyViewModel>>(await unitOfWork.SpecialtyRepository.GetAllShortSpecialtyAsync());
        }

        public async Task<List<GroupViewModel>> Search(string q, bool IsReleased)
        {
            return mapper.Map<List<GroupViewModel>>(await unitOfWork.GroupRepository.SearchGroupsAsync(q, IsReleased));
        }

        public async Task<GroupEditModel> GetForEdit(int id)
        {
            return mapper.Map<GroupEditModel>(await unitOfWork.GroupRepository.GetByWhereAsync(d => d.Id == id));
        }

        public async Task<List<GroupMemberViewModel>> GetGroupMembers(int id)
        {
            return mapper.Map<List<GroupMemberViewModel>>(await unitOfWork.GroupMemberRepository.GetGroupMembersAsync(id));
        }
    }
}