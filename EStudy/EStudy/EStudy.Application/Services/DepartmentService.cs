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
            throw new NotImplementedException();
        }

        public async Task<string> EditDepartment(DepartmentCreateModel model)
        {
            throw new NotImplementedException();
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