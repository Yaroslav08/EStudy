﻿using EStudy.Application.Interfaces;
using EStudy.Application.Services;
using EStudy.Domain.Interfaces;
using EStudy.Infrastructure.Data;
using EStudy.Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using EStudy.Application;
using EStudy.Application.ViewModels;

namespace EStudy.Infrastructure.IoC
{
    public static class DependencyContainer
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddSingleton<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IDataManager, DataManager>();
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IFileRepository, FileRepository>();
            services.AddSingleton<IUniversityRepository, UniversityRepository>();
            services.AddSingleton<IUniversityService, UniversityService>();
            services.AddSingleton<IDepartmentRepository, DepartmentRepository>();
            services.AddSingleton<IDepartmentService, DepartmentService>();
            services.AddSingleton<ISpecialtyRepository, SpecialtyRepository>();
            services.AddSingleton<ISpecialtyService, SpecialtyService>();
            services.AddSingleton<IGroupRepository, GroupRepository>();
            services.AddSingleton<IEmailRepository, EmailRepository>();
            services.AddSingleton<IGroupService, GroupService>();
            services.AddSingleton<IGroupMemberRepository, GroupMemberRepository>();
            services.AddSingleton<ICourseRepository, CourseRepository>();
            services.AddSingleton<ICourseService, CourseService>();
            services.AddSingleton<ILessonRepository, LessonRepository>();
            services.AddSingleton<ILessonFileRepository, LessonFileRepository>();
            services.AddSingleton<ILessonService, LessonService>();
            services.AddSingleton<IHomeworkRepository, HomeworkRepository>();
            services.AddSingleton<IHomeworkService, HomeworkService>();
            services.AddSingleton<IHomeworkFileRepository, HomeworkFileRepository>();
        }
    }
}