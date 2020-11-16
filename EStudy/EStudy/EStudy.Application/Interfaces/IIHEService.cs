using EStudy.Application.ViewModels.IHE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Application.Interfaces
{
    public interface IIHEService
    {
        Task<string> CreateIHE(IHECreateModel model);
        Task<string> EditIHE(IHEEditModel model);
        Task<IHEViewModel> GetIhe();
    }
}