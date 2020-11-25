using AutoMapper;
using EStudy.Application.Interfaces;
using EStudy.Application.ViewModels.Homework;
using EStudy.Domain.Models;
using EStudy.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Application.Services
{
    public class HomeworkService : IHomeworkService
    {
        private IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public HomeworkService(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }

        public async Task<List<HomeworkViewModel>> GetAll()
        {
            return mapper.Map<List<HomeworkViewModel>>(await unitOfWork.HomeworkRepository.GetAllAsync());
        }

        public async Task<List<HomeworkViewModel>> GetHomeworkByUserId(int id)
        {
            return mapper.Map<List<HomeworkViewModel>>(await unitOfWork.HomeworkRepository.GetListByWhereAsync(d => d.UserId == id));
        }

        public async Task<List<HomeworkViewModel>> GetHomeworkByLessonId(long id)
        {
            return mapper.Map<List<HomeworkViewModel>>(await unitOfWork.HomeworkRepository.GetListByWhereAsync(d => d.LessonId == id));
        }

        public async Task<List<HomeworkViewModel>> GetHomeworkByCourseIdOfStudent(int id, int userId)
        {
            return mapper.Map<List<HomeworkViewModel>>(await unitOfWork.HomeworkRepository.GetHomeworkByCourseIdOfStudentAsync(id, userId));
        }

        public async Task<string> CreateHomework(HomeworkCreateModel model)
        {
            var homework = mapper.Map<Homework>(model);
            homework.CreatedByUserId = model.UserId;
            homework.CreatedFromIP = model.IP;
            return await unitOfWork.HomeworkRepository.CreateAsync(homework);
        }

        public async Task<string> EditHomework(HomeworkEditModel model)
        {
            var homework = await unitOfWork.HomeworkRepository.GetByWhereAsTrackingAsync(d => d.Id == model.Id);
            if (homework == null) return Constants.Constants.HomeworkNotFound;
            return await unitOfWork.HomeworkRepository.UpdateAsync(model.GetHomeworkToDb(homework));
        }

        public async Task<string> SetMark(HomeworkMarkCreateModel model)
        {
            var homework = await unitOfWork.HomeworkRepository.GetByWhereAsTrackingAsync(d => d.Id == model.Id);
            if (homework == null) return Constants.Constants.HomeworkNotFound;
            return await unitOfWork.HomeworkRepository.UpdateAsync(model.GetHomeworkMarkToDb(homework));
        }

        public async Task<string> CreateHomeworkFiles(FilesLoadModel model)
        {
            if (model.files.Count <= 0)
                return Constants.Constants.NotFound;
            var homeworkFiles = new List<HomeworkFile>();
            model.files.ForEach(d =>
            {
                homeworkFiles.Add(new HomeworkFile
                {
                    HomeworkId = d.HomeworkId,
                    LoadByUserId = d.UserId,
                    Path = d.Path,
                    OriginalName = d.OriginalName
                });
            });
            return await unitOfWork.HomeworkFileRepository.CreateRangeAsync(homeworkFiles);
        }

        public async Task<string> RemoveHomeworkFile(string id, int userId)
        {
            var hfile = await unitOfWork.HomeworkFileRepository.GetByWhereAsTrackingAsync(d => d.Id == id);
            if (hfile == null) return Constants.Constants.FileNotFound;
            if (hfile.LoadByUserId != userId) return Constants.Constants.AccessDenited;
            return await unitOfWork.HomeworkFileRepository.RemoveAsync(hfile);
        }
    }
}