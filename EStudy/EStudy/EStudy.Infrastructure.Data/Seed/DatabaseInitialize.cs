using EStudy.Domain.Models;
using EStudy.Infrastructure.Data.Context;
using Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Infrastructure.Data.Seed
{
    public static class DatabaseInitialize
    {
        public async static Task SeedData(EStudyContext context)
        {
            await context.Users.AddRangeAsync(TestData.Data.GetUsers());
            await context.Universities.AddAsync(TestData.Data.GetUniversity());
        }
    }
}