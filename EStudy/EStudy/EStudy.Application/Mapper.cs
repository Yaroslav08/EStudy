using AutoMapper;
using EStudy.Domain.Models;
using EStudy.Application.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace EStudy.Application
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<User, UserViewModel>()
                .ForMember(d => d.Role, s => s.MapFrom(d => d.Role.ToString()));
        }
    }
}