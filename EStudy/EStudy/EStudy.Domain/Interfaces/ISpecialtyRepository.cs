using EStudy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Domain.Interfaces
{
    public interface ISpecialtyRepository : IRepository<Specialty>
    {
        Task<List<Specialty>> GetAllShortSpecialtyAsync();
        Task<List<Specialty>> SearchAsync(string q);
    }
}