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

        public UnitOfWork(
            IUserRepository _userRepository,
            IFileRepository _fileRepository,
            IIHERepository _iHERepository)
        {
            userRepository = _userRepository;
            fileRepository = _fileRepository;
            iHERepository = _iHERepository;
        }

        public IUserRepository UserRepository => userRepository;
        public IFileRepository FileRepository => fileRepository;
        public IIHERepository IHERepository => iHERepository;
    }
}