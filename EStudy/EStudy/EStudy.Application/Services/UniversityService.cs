using AutoMapper;
using EStudy.Application.Interfaces;
using EStudy.Application.ViewModels.University;
using EStudy.Domain.Models;
using EStudy.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Application.Services
{
    public class UniversityService : IUniversityService
    {
        private IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public UniversityService(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }

        public async Task<string> CreateUniversity(UniversityCreateModel model)
        {
            if (await unitOfWork.UniversityRepository.CountAsync() > 0)
                return Constants.Constants.AccessDenited;
            return await unitOfWork.UniversityRepository.CreateAsync(new Domain.Models.University
            {
                Name = model.Name,
                ShortName = model.ShortName,
                EnglishName = model.EnglishName,
                CodeEDEBO = model.CodeEDEBO,
                CreatedFromIP = model.IP,
                CreatedByUserId = model.UserId
            });
        }

        public async Task<string> EditUniversity(UniversityEditModel model)
        {
            var University = await unitOfWork.UniversityRepository.GetByWhereAsTrackingAsync(d => d.Id == model.Id);
            if (University == null) return Constants.Constants.UniversityNotFound;
            return await unitOfWork.UniversityRepository.UpdateAsync(model.GetUniversityToDb(University));
        }

        public async Task<UniversityViewModel> GetUniversity()
        {
            return mapper.Map<UniversityViewModel>(await unitOfWork.UniversityRepository.FirstAsync());
        }
    }
}