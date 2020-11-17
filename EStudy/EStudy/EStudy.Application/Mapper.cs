using AutoMapper;
using EStudy.Domain.Models;
using EStudy.Application.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Text;
using EStudy.Application.ViewModels.IHE;
using EStudy.Application.ViewModels.Department;
using EStudy.Application.ViewModels.Specialty;

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

            CreateMap<IHE, IHEViewModel>()
                .ForMember(d => d.Departments, s => s.MapFrom(d => d.Departments));
            CreateMap<IHEEditModel, IHE>();

            CreateMap<Department, DepartmentViewModel>()
                .ForMember(d => d.IHE, s => s.MapFrom(d => d.IHE));

            CreateMap<Specialty, SpecialtyViewModel>()
                .ForMember(d => d.Department, s => s.MapFrom(d => d.Department));
        }
    }
}