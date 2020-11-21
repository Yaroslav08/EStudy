using AutoMapper;
using EStudy.Application.Interfaces;
using EStudy.Application.ViewModels.Course;
using EStudy.Domain.Interfaces;
using EStudy.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Application.Services
{
    public class CourseService : ICourseService
    {
        private IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public CourseService(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }

        public async Task<CourseViewModel> GetCourseById(int id)
        {
            return mapper.Map<CourseViewModel>(await unitOfWork.CourseRepository.GetByWhereAsync(d => d.Id == id));
        }

        public async Task<List<CourseViewModel>> GetAll()
        {
            return mapper.Map<List<CourseViewModel>>(await unitOfWork.CourseRepository.GetAllAsync());
        }

        public async Task<List<CourseViewModel>> GetCoursesByGroupId(int groupId)
        {
            return mapper.Map<List<CourseViewModel>>(await unitOfWork.CourseRepository.GetCoursesByGroupIdAsync(groupId));
        }
    }
}