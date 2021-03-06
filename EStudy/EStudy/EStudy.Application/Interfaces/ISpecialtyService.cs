﻿using EStudy.Application.ViewModels.Department;
using EStudy.Application.ViewModels.Specialty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Application.Interfaces
{
    public interface ISpecialtyService
    {
        Task<string> CreateSpecialty(SpecialtyCreateModel model);
        Task<string> EditSpecialty(SpecialtyEditModel model);
        Task<SpecialtyEditModel> GetForEdit(int id);
        Task<SpecialtyViewModel> GetSpecialtyById(int id);
        Task<List<SpecialtyViewModel>> GetAllSpecialties();
        Task<List<SpecialtyViewModel>> GetSpecialtiesByDepartmentId(int id);
        Task<List<DepartmentViewModel>> GetAllDepartments();
        Task<List<SpecialtyViewModel>> Search(string q);
    }
}