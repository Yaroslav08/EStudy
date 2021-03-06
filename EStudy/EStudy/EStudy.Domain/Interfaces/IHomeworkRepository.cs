﻿using EStudy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Domain.Interfaces
{
    public interface IHomeworkRepository : IRepository<Homework>
    {
        Task<List<Homework>> GetHomeworkByCourseIdOfStudentAsync(int courseId, int userId);
    }
}