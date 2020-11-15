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

        public UnitOfWork(IUserRepository _userRepository, IFileRepository _fileRepository)
        {
            userRepository = _userRepository;
            fileRepository = _fileRepository;
        }

        public IUserRepository UserRepository => userRepository;
        public IFileRepository FileRepository => fileRepository;
    }
}