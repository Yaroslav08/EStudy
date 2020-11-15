using AutoMapper;
using EStudy.Infrastructure.Data;
using EStudy.Application.Interfaces;
using EStudy.Application.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EStudy.Application.Services
{
    public class UserService : IUserService
    {
        private IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public UserService(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }

        public async Task<UserViewModel> GetUserById(int id)
        {
            return mapper.Map<UserViewModel>(await unitOfWork.UserRepository.GetByWhereAsync(d => d.Id == id));
        }

        public async Task<List<UserShortViewModel>> SearchUsers(string name, int count, int skip, string param = null) =>
             param switch
             {
                 "s" => mapper.Map<List<UserShortViewModel>>(await unitOfWork.UserRepository.SearchStudentsAsync(name, count, skip)),
                 "t" => mapper.Map<List<UserShortViewModel>>(await unitOfWork.UserRepository.SearchTeachersAsync(name, count, skip)),
                 _ => mapper.Map<List<UserShortViewModel>>(await unitOfWork.UserRepository.SearchAsync(name, count, skip))
             };
    }
}