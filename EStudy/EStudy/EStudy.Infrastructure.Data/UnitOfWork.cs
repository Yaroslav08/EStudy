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

        public UnitOfWork(
            IUserRepository _userRepository,
            IFileRepository _fileRepository,
            IIHERepository _iHERepository,
            IDepartmentRepository _departmentRepository)
        {
            userRepository = _userRepository;
            fileRepository = _fileRepository;
            iHERepository = _iHERepository;
            departmentRepository = _departmentRepository;
        }

        public IUserRepository UserRepository => userRepository;
        public IFileRepository FileRepository => fileRepository;
        public IIHERepository IHERepository => iHERepository;
        public IDepartmentRepository DepartmentRepository => departmentRepository;
    }
}