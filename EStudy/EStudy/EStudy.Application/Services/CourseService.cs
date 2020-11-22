using AutoMapper;
using EStudy.Application.Interfaces;
using EStudy.Application.ViewModels.Course;
using EStudy.Domain.Interfaces;
using EStudy.Domain.Models;
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

        public async Task<CourseViewModel> GetCourseById(int id) =>
            mapper.Map<CourseViewModel>(await unitOfWork.CourseRepository.GetByWhereAsync(d => d.Id == id));

        public async Task<List<CourseViewModel>> GetAll() =>
            mapper.Map<List<CourseViewModel>>(await unitOfWork.CourseRepository.GetAllAsync());

        public async Task<List<CourseViewModel>> GetCoursesByGroupId(int groupId) =>
            mapper.Map<List<CourseViewModel>>(await unitOfWork.CourseRepository.GetCoursesByGroupIdAsync(groupId));

        public async Task<string> CreateCourse(CourseCreateModel model)
        {
            var course = mapper.Map<Course>(model);
            course.CreatedFromIP = model.IP;
            course.CreatedByUserId = model.UserId;
            return await unitOfWork.CourseRepository.CreateAsync(course);
        }

        public async Task<string> EditCourse(CourseEditModel model)
        {
            var course = await unitOfWork.CourseRepository.GetByWhereAsync(d => d.Id == model.Id);
            if (course == null) return Constants.Constants.CourseNotFound;
            var editCourse = mapper.Map<Course>(model);
            editCourse.CreatedByUserId = course.CreatedByUserId;
            editCourse.CreatedAt = course.CreatedAt;
            editCourse.CreatedFromIP = course.CreatedFromIP;
            editCourse.GroupId = course.GroupId;
            editCourse.IsEdit = true;
            editCourse.DateLastEdit = DateTime.Now;
            editCourse.EditedByUserId = model.UserId;
            editCourse.EditedFromIP = model.IP;
            return await unitOfWork.CourseRepository.UpdateAsync(course);
        }
    }
}