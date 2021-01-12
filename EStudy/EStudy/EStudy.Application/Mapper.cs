using AutoMapper;
using EStudy.Domain.Models;
using EStudy.Application.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Text;
using EStudy.Application.ViewModels.University;
using EStudy.Application.ViewModels.Department;
using EStudy.Application.ViewModels.Specialty;
using EStudy.Application.ViewModels.Group;
using EStudy.Application.ViewModels.Course;
using EStudy.Application.ViewModels.Lesson;
using EStudy.Application.ViewModels.Homework;

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
            CreateMap<User, UserEditModel>()
                .ForMember(d => d.GenderValue, s => s.MapFrom(d => Convert.ToInt32(d.Gender)));
            CreateMap<User, UserNotConfirmed>()
                .ForMember(d => d.Role, s => s.MapFrom(d => d.Role.ToString()));
            CreateMap<UserEditModel, User>();


            CreateMap<University, UniversityViewModel>()
                .ForMember(d => d.Departments, s => s.MapFrom(d => d.Departments));
            CreateMap<UniversityCreateModel, University>();
            CreateMap<UniversityEditModel, University>();
            CreateMap<University, UniversityEditModel>();


            CreateMap<Department, DepartmentViewModel>()
                .ForMember(d => d.University, s => s.MapFrom(d => d.University));
            CreateMap<DepartmentCreateModel, Department>();
            CreateMap<DepartmentEditModel, Department>();
            CreateMap<Department, DepartmentEditModel>();


            CreateMap<Specialty, SpecialtyViewModel>()
                .ForMember(d => d.Department, s => s.MapFrom(d => d.Department));
            CreateMap<SpecialtyCreateModel, Specialty>();
            CreateMap<SpecialtyEditModel, Specialty>();
            CreateMap<Specialty, SpecialtyEditModel>();


            CreateMap<Group, GroupViewModel>()
                .ForMember(d => d.Specialty, s => s.MapFrom(d => d.Specialty))
                .ForMember(d => d.Emails, s => s.MapFrom(d => d.Emails));
            CreateMap<GroupCreateModel, Group>();
            CreateMap<GroupEditModel, Group>();
            CreateMap<Group, GroupEditModel>();
            CreateMap<GroupMember, GroupMemberViewModel>()
                .ForMember(d => d.Group, s => s.MapFrom(d => d.Group))
                .ForMember(d => d.User, s => s.MapFrom(d => d.User))
                .ForMember(d => d.Role, s => s.MapFrom(d => d.MemberRole.ToString()));


            CreateMap<Email, EmailViewModel>()
                .ForMember(d => d.Group, s => s.MapFrom(d => d.Group));
            CreateMap<EmailCreateModel, Email>();
            CreateMap<EmailEditModel, Email>();

            CreateMap<Course, CourseViewModel>()
                .ForMember(d => d.Teacher, s => s.MapFrom(d => d.Teacher))
                .ForMember(d => d.Group, s => s.MapFrom(d => d.Group));
            CreateMap<CourseCreateModel, Course>();


            CreateMap<Lesson, LessonViewModel>()
                .ForMember(d => d.Course, s => s.MapFrom(d => d.Course))
                .ForMember(d => d.LessonFiles, s => s.MapFrom(d => d.LessonFiles));
            CreateMap<LessonCreateModel, Lesson>();

            CreateMap<LessonFile, LessonFileViewModel>()
                .ForMember(d => d.Lesson, s => s.MapFrom(d => d.Lesson));
            CreateMap<LessonCreateModel, Lesson>();

            CreateMap<Homework, HomeworkViewModel>()
                .ForMember(d => d.User, s => s.MapFrom(d => d.User))
                .ForMember(d => d.Lesson, s => s.MapFrom(d => d.Lesson));
            CreateMap<HomeworkCreateModel, Homework>();
        }
    }
}