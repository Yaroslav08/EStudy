using AutoMapper;
using EStudy.Application.Interfaces;
using EStudy.Application.ViewModels.Lesson;
using EStudy.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Application.Services
{
    public class LessonService : ILessonService
    {
        private IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public LessonService(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }

        public async Task<List<LessonViewModel>> GetAll() =>
            mapper.Map<List<LessonViewModel>>(await unitOfWork.LessonRepository.GetAllAsync());

        public async Task<List<LessonViewModel>> GetAllLessonsByCourseId(int id) =>
            mapper.Map<List<LessonViewModel>>(await unitOfWork.LessonRepository.GetAllLessonsByCourseIdAsync(id));

        public async Task<LessonViewModel> GetById(long id) =>
            mapper.Map<LessonViewModel>(await unitOfWork.LessonRepository.GetByWhereAsync(d => d.Id == id));
    }
}