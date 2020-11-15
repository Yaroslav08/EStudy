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
                .ForMember(d => d.Role, s => s.MapFrom(d => d.Role.ToString()))
                .ForMember(d => d.Email, s => s.MapFrom(d => d.IsShowEmail ? d.Email : null))
                .ForMember(d => d.Phone, s => s.MapFrom(d => d.IsShowPhone ? d.Phone : null));
        }
    }
}