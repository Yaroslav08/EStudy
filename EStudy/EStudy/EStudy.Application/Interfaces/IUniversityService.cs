using EStudy.Application.ViewModels.University;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Application.Interfaces
{
    public interface IUniversityService
    {
        Task<string> CreateUniversity(UniversityCreateModel model);
        Task<string> EditUniversity(UniversityEditModel model);
        Task<UniversityViewModel> GetUniversity();
    }
}