﻿using EStudy.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EStudy.Infrastructure.Data
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; }
        IFileRepository FileRepository { get; }
        IIHERepository IHERepository { get; }
        IDepartmentRepository DepartmentRepository { get; }
        ISpecialtyRepository SpecialtyRepository { get; }
        IGroupRepository GroupRepository { get; }
        IEmailRepository EmailRepository { get; }
    }
}