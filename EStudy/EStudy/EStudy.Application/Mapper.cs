using AutoMapper;
using EStudy.Domain.Models;
using EStudy.Application.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Text;
using EStudy.Application.ViewModels.IHE;
using EStudy.Application.ViewModels.Department;
using EStudy.Application.ViewModels.Specialty;
using EStudy.Application.ViewModels.Group;
using EStudy.Application.ViewModels.Course;

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
            CreateMap<IHECreateModel, IHE>();
            CreateMap<IHEEditModel, IHE>();


            CreateMap<Department, DepartmentViewModel>()
                .ForMember(d => d.IHE, s => s.MapFrom(d => d.IHE));
            CreateMap<DepartmentCreateModel, Department>();
            CreateMap<DepartmentEditModel, Department>();


            CreateMap<Specialty, SpecialtyViewModel>()
                .ForMember(d => d.Department, s => s.MapFrom(d => d.Department));
            CreateMap<SpecialtyCreateModel, Specialty>();
            CreateMap<SpecialtyEditModel, Specialty>();


            CreateMap<Group, GroupViewModel>()
                .ForMember(d => d.Specialty, s => s.MapFrom(d => d.Specialty))
                .ForMember(d => d.Emails, s => s.MapFrom(d => d.Emails));
            CreateMap<GroupCreateModel, Group>();
            CreateMap<GroupEditModel, Group>();


            CreateMap<Email, EmailViewModel>()
                .ForMember(d => d.Group, s => s.MapFrom(d => d.Group));
            CreateMap<EmailCreateModel, Email>();
            CreateMap<EmailEditModel, Email>();

            CreateMap<Course, CourseViewModel>()
                .ForMember(d => d.Teacher, s => s.MapFrom(d => d.Teacher))
                .ForMember(d => d.Group, s => s.MapFrom(d => d.Group));
            CreateMap<CourseCreateModel, Course>();
        }
    }
}