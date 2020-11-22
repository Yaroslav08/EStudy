using EStudy.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EStudy.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private IUserRepository userRepository;
        private IFileRepository fileRepository;
        private IIHERepository iHERepository;
        private IDepartmentRepository departmentRepository;
        private ISpecialtyRepository specRepository;
        private IGroupRepository groupRepository;
        private IEmailRepository emailRepository;
        private IGroupMemberRepository groupMemberRepository;
        private ICourseRepository courseRepository;
        private ILessonRepository lessonRepository;
        private ILessonFileRepository lessonFileRepository;
        private IHomeworkRepository homeworkRepository;

        public UnitOfWork(
            IUserRepository _userRepository,
            IFileRepository _fileRepository,
            IIHERepository _iHERepository,
            IDepartmentRepository _departmentRepository,
            ISpecialtyRepository _specRepository,
            IGroupRepository _groupRepository,
            IEmailRepository _emailRepository,
            IGroupMemberRepository _groupMemberRepository,
            ICourseRepository _courseRepository,
            ILessonRepository _lessonRepository,
            ILessonFileRepository _lessonFileRepository,
            IHomeworkRepository _homeworkRepository)
        {
            userRepository = _userRepository;
            fileRepository = _fileRepository;
            iHERepository = _iHERepository;
            departmentRepository = _departmentRepository;
            specRepository = _specRepository;
            groupRepository = _groupRepository;
            emailRepository = _emailRepository;
            groupMemberRepository = _groupMemberRepository;
            courseRepository = _courseRepository;
            lessonRepository = _lessonRepository;
            lessonFileRepository = _lessonFileRepository;
            homeworkRepository = _homeworkRepository;
        }

        public IUserRepository UserRepository => userRepository;
        public IFileRepository FileRepository => fileRepository;
        public IIHERepository IHERepository => iHERepository;
        public IDepartmentRepository DepartmentRepository => departmentRepository;
        public ISpecialtyRepository SpecialtyRepository => specRepository;
        public IGroupRepository GroupRepository => groupRepository;
        public IEmailRepository EmailRepository => emailRepository;
        public IGroupMemberRepository GroupMemberRepository => groupMemberRepository;
        public ICourseRepository CourseRepository => courseRepository;
        public ILessonRepository LessonRepository => lessonRepository;
        public ILessonFileRepository LessonFileRepository => lessonFileRepository;
        private IHomeworkRepository HomeworkRepository => homeworkRepository;
    }
}