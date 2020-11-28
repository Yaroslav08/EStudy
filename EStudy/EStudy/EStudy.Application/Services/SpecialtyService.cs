using AutoMapper;
using EStudy.Application.Interfaces;
using EStudy.Application.ViewModels.Department;
using EStudy.Application.ViewModels.Specialty;
using EStudy.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Application.Services
{
    public class SpecialtyService : ISpecialtyService
    {
        private IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public SpecialtyService(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }

        public async Task<string> CreateSpecialty(SpecialtyCreateModel model)
        {
            return await unitOfWork.SpecialtyRepository.CreateAsync(new Domain.Models.Specialty
            {
                Name = model.Name,
                Shifr = model.Shifr,
                Code = model.Code,
                Qualification = model.Qualification,
                EducationalProgram = model.EducationalProgram,
                ProfessionalQualification = model.ProfessionalQualification,
                About = model.About,
                DepartmentId = model.DepartmentId,
                CreatedByUserId = model.UserId,
                CreatedFromIP = model.IP
            });
        }

        public async Task<string> EditSpecialty(SpecialtyEditModel model)
        {
            var spec = await unitOfWork.SpecialtyRepository.GetByWhereAsTrackingAsync(d => d.Id == model.Id);
            if (spec == null) return Constants.Constants.SpecialtyNotFound;
            return await unitOfWork.SpecialtyRepository.UpdateAsync(model.GetSpecialtyToDb(spec));
        }

        public async Task<SpecialtyViewModel> GetSpecialtyById(int id)
        {
            return mapper.Map<SpecialtyViewModel>(await unitOfWork.SpecialtyRepository.GetByWhereAsync(d => d.Id == id));
        }

        public async Task<List<SpecialtyViewModel>> GetAllSpecialties()
        {
            return mapper.Map<List<SpecialtyViewModel>>(await unitOfWork.SpecialtyRepository.GetAllAsync());
        }

        public async Task<List<SpecialtyViewModel>> GetSpecialtiesByDepartmentId(int id)
        {
            return mapper.Map<List<SpecialtyViewModel>>(await unitOfWork.SpecialtyRepository.GetListByWhereAsync(d => d.DepartmentId == id));
        }

        public async Task<SpecialtyEditModel> GetForEdit(int id)
        {
            return mapper.Map<SpecialtyEditModel>(await unitOfWork.SpecialtyRepository.GetByWhereAsync(d => d.Id == id));
        }

        public async Task<List<DepartmentViewModel>> GetAllDepartments()
        {
            return mapper.Map<List<DepartmentViewModel>>(await unitOfWork.DepartmentRepository.GetAllShortDepartmentsAsync());
        }

        public async Task<List<SpecialtyViewModel>> Search(string q)
        {
            return mapper.Map<List<SpecialtyViewModel>>(await unitOfWork.SpecialtyRepository.SearchAsync(q));
        }
    }
}