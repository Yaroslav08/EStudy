using AutoMapper;
using EStudy.Application.Interfaces;
using EStudy.Application.ViewModels.Department;
using EStudy.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Application.Services
{
    public class DepartmentService : IDepartmentService
    {
        private IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public DepartmentService(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }

        public async Task<string> CreateDepartment(DepartmentCreateModel model)
        {
            return await unitOfWork.DepartmentRepository.CreateAsync(new Domain.Models.Department
            {
                Name = model.Name,
                Shifr = model.Shifr,
                HeadById = model.HeadById,
                Phone = model.Phone,
                ContactInformation = model.ContactInformation,
                Description = model.Description,
                UniversityId = model.UniversityId,
                CreatedByUserId = model.UserId,
                CreatedFromIP = model.IP
            });
        }

        public async Task<string> EditDepartment(DepartmentEditModel model)
        {
            var depart = await unitOfWork.DepartmentRepository.GetByWhereAsTrackingAsync(d => d.Id == model.Id);
            if (depart == null) return Constants.Constants.DepartmentNotFound;
            return await unitOfWork.DepartmentRepository.UpdateAsync(model.GetDepartmentToDb(depart));
        }

        public async Task<DepartmentViewModel> GetDepartmentById(int id)
        {
            return mapper.Map<DepartmentViewModel>(await unitOfWork.DepartmentRepository.GetByWhereAsync(d => d.Id == id));
        }

        public async Task<List<DepartmentViewModel>> GetDepartments()
        {
            return mapper.Map<List<DepartmentViewModel>>(await unitOfWork.DepartmentRepository.GetAllAsync());
        }
    }
}