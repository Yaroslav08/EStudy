using AutoMapper;
using EStudy.Application.Interfaces;
using EStudy.Application.ViewModels.IHE;
using EStudy.Domain.Models;
using EStudy.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Application.Services
{
    public class IHEService : IIHEService
    {
        private IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public IHEService(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }

        public async Task<string> CreateIHE(IHECreateModel model)
        {
            if (await unitOfWork.IHERepository.CountAsync() > 0)
                return Constants.Constants.AccessDenited;
            return await unitOfWork.IHERepository.CreateAsync(new Domain.Models.IHE
            {
                Name = model.Name,
                ShortName = model.ShortName,
                EnglishName = model.EnglishName,
                CodeEDEBO = model.CodeEDEBO,
                CreatedFromIP = model.IP,
                CreatedByUserId = model.UserId
            });
        }

        public async Task<string> EditIHE(IHEEditModel model)
        {
            var ihe = await unitOfWork.IHERepository.GetByWhereAsTrackingAsync(d => d.Id == model.Id);
            if (ihe == null) return Constants.Constants.IHENotFound;
            ihe.Name = model.Name;
            ihe.ShortName = model.ShortName;
            ihe.EnglishName = model.EnglishName;
            ihe.Accreditation = model.Accreditation;
            ihe.AddressInfo = model.AddressInfo;
            ihe.Area = model.Area;
            ihe.CodeEDEBO = model.CodeEDEBO;
            ihe.Description = model.Description;
            ihe.Locality = model.Locality;
            ihe.PostalCode = model.PostalCode;
            ihe.Region = model.Region;
            ihe.Type = model.Type;
            ihe.IsEdit = true;
            ihe.DateLastEdit = DateTime.Now;
            ihe.EditedByUserId = model.UserId;
            ihe.EditedFromIP = model.IP;
            return await unitOfWork.IHERepository.UpdateAsync(ihe);
        }

        public async Task<IHEViewModel> GetIhe()
        {
            return mapper.Map<IHEViewModel>(await unitOfWork.IHERepository.FirstAsync());
        }
    }
}