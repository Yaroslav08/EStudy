using EStudy.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EStudy.Infrastructure.Data
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IFileRepository FileRepository { get; }
        IUniversityRepository UniversityRepository { get; }
        IDepartmentRepository DepartmentRepository { get; }
        ISpecialtyRepository SpecialtyRepository { get; }
        IGroupRepository GroupRepository { get; }
        IEmailRepository EmailRepository { get; }
        IGroupMemberRepository GroupMemberRepository { get; }
        ICourseRepository CourseRepository { get; }
        ILessonRepository LessonRepository { get; }
        ILessonFileRepository LessonFileRepository { get; }
        IHomeworkRepository HomeworkRepository { get; }
    }
}