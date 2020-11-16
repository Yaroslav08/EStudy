using EStudy.Application.Interfaces;
using EStudy.Application.Services;
using EStudy.Domain.Interfaces;
using EStudy.Infrastructure.Data;
using EStudy.Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace EStudy.Infrastructure.IoC
{
    public static class DependencyContainer
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IFileRepository, FileRepository>();
            services.AddScoped<IIHERepository, IHERepository>();
        }
    }
}