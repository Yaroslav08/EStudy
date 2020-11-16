using AutoMapper;
using EStudy.Domain.Models;
using EStudy.Application.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Text;
using EStudy.Application.ViewModels.IHE;

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
            CreateMap<User, UserShortViewModel>()
                .ForMember(d => d.Avatar, s => s.MapFrom(d => d.Avatar50));

            CreateMap<IHE, IHEViewModel>();
            CreateMap<IHEEditModel, IHE>();
        }
    }
}