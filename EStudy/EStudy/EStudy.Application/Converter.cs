using EStudy.Application.ViewModels.Course;
using EStudy.Application.ViewModels.Department;
using EStudy.Application.ViewModels.Group;
using EStudy.Application.ViewModels.Homework;
using EStudy.Application.ViewModels.IHE;
using EStudy.Application.ViewModels.Lesson;
using EStudy.Application.ViewModels.Specialty;
using EStudy.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Application
{
    public static class Converter
    {
        public static IHE GetIHEToDb(this IHEEditModel model, IHE ihe)
        {
            ihe.Name = model.Name;
            ihe.ShortName = model.ShortName;
            ihe.EnglishName = model.EnglishName;
            ihe.CodeEDEBO = model.CodeEDEBO;
            ihe.Type = model.Type;
            ihe.Area = model.Area;
            ihe.Accreditation = model.Accreditation;
            ihe.Logo = model.Logo;
            ihe.Logo50 = model.Logo50;
            ihe.Logo150 = model.Logo150;
            ihe.Description = model.Description;
            ihe.AddressInfo = model.AddressInfo;
            ihe.Locality = model.Locality;
            ihe.Region = model.Region;
            ihe.PostalCode = model.PostalCode;
            ihe.IsEdit = true;
            ihe.DateLastEdit = DateTime.Now;
            ihe.EditedByUserId = model.UserId;
            ihe.EditedFromIP = model.IP;
            return ihe;
        }

        public static Department GetDepartmentToDb(this DepartmentEditModel model, Department department)
        {
            department.Name = model.Name;
            department.Shifr = model.Shifr;
            department.HeadById = model.HeadById;
            department.Phone = model.Phone;
            department.ContactInformation = model.ContactInformation;
            department.Description = model.Description;
            department.IHEId = model.IHEId;
            department.IsEdit = true;
            department.DateLastEdit = DateTime.Now;
            department.EditedByUserId = model.UserId;
            department.EditedFromIP = model.IP;
            return department;
        }

        public static Specialty GetSpecialtyToDb(this SpecialtyEditModel model, Specialty specialty)
        {
            specialty.Name = model.Name;
            specialty.Shifr = model.Shifr;
            specialty.Code = model.Code;
            specialty.Qualification = model.Qualification;
            specialty.EducationalProgram = model.EducationalProgram;
            specialty.ProfessionalQualification = model.ProfessionalQualification;
            specialty.About = model.About;
            specialty.DepartmentId = model.DepartmentId;
            specialty.IsEdit = true;
            specialty.DateLastEdit = DateTime.Now;
            specialty.EditedByUserId = model.UserId;
            specialty.EditedFromIP = model.IP;
            return specialty;
        }

        public static Group GetGroupToDb(this GroupEditModel model, Group group)
        {
            group.Name = model.Name;
            group.Course = model.Course;
            group.StartStudy = model.StartStudy;
            group.EndStudy = model.EndStudy;
            group.IndexItemToChanged = model.IndexItemToChanged;
            group.IsReleased = model.IsReleased;
            group.AdditionalInfo = model.AdditionalInfo;
            group.Email = model.Email;
            group.IsShowEmail = model.IsShowEmail;
            group.SpecialtyId = model.SpecialtyId;
            group.IsEdit = true;
            group.DateLastEdit = DateTime.Now;
            group.EditedByUserId = model.UserId;
            group.EditedFromIP = model.IP;
            return group;
        }

        public static Course GetCourseToDb(this CourseEditModel model, Course course)
        {
            course.Name = model.Name;
            course.ShortName = model.ShortName;
            course.OrientedOnCourse = model.OrientedOnCourse;
            course.Theme = model.Theme;
            course.Start = model.Start;
            course.End = model.End;
            course.WithExam = model.WithExam;
            course.MaxMarkOnExam = model.MaxMarkOnExam;
            course.MaxMarkUpToExam = model.MaxMarkUpToExam;
            course.CommonHours = model.CommonHours;
            course.HoursLectures = model.HoursLectures;
            course.HoursSeminarTasks = model.HoursSeminarTasks;
            course.HoursLectures = model.HoursLectures;
            course.TypeSubject = model.TypeSubject;
            course.Literature = model.Literature;
            course.FinalMark = model.FinalMark;
            course.Level = model.Level;
            course.TeacherId = model.TeacherId;
            course.IsEdit = true;
            course.DateLastEdit = DateTime.Now;
            course.EditedByUserId = model.UserId;
            course.EditedFromIP = model.IP;
            return course;
        }

        public static Email GetEmailToDb(this EmailEditModel model, Email email)
        {
            email.Title = model.Title;
            email.Address = model.Address;
            email.Password = model.Password;
            email.GroupId = model.GroupId;
            email.IsEdit = true;
            email.DateLastEdit = DateTime.Now;
            email.EditedByUserId = model.UserId;
            email.EditedFromIP = model.IP;
            return email;
        }

        public static Lesson GetLessonToDb(this LessonEditModel model, Lesson lesson)
        {
            lesson.Theme = model.Theme;
            lesson.Text = model.Text;
            lesson.Mark = model.Mark;
            lesson.DateLesson = model.DateLesson;
            lesson.TypeLesson = model.TypeLesson;
            lesson.IsEdit = true;
            lesson.DateLastEdit = DateTime.Now;
            lesson.EditedByUserId = model.UserId;
            lesson.EditedFromIP = model.IP;
            return lesson;
        }

        public static Homework GetHomeworkToDb(this HomeworkEditModel model, Homework homework)
        {
            homework.IsComplate = model.IsComplate;
            homework.Text = model.Text;
            homework.Links = model.Links;
            homework.IsEdit = true;
            homework.DateLastEdit = DateTime.Now;
            homework.EditedByUserId = model.UserId;
            homework.EditedFromIP = model.IP;
            return homework;
        }

        public static Homework GetHomeworkMarkToDb(this HomeworkMarkCreateModel model, Homework homework)
        {
            homework.Mark = model.Mark;
            homework.MarkSetAt = DateTime.Now;
            homework.UserSetMark = model.UserId;
            return homework;
        }
    }
}