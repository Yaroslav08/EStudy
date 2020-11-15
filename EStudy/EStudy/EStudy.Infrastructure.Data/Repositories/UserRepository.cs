using EStudy.Domain.Interfaces;
using EStudy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EStudy.Infrastructure.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {

    }
}