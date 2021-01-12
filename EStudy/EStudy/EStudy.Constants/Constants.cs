using System;
using System.Collections.Generic;
using System.Text;

namespace EStudy.Constants
{
    public static class Constants
    {
        public const string OK = "OK";
        public const string NotFound = "Not found";
        public const string AccessDenited = "Access denited";
        public const string Error = "Custom error";

        #region User
        public const string UserNotFoundById = "Користувача не знайдено";
        public const string TokenExpired = "Життя токену вичерпано";
        public const string TokenNotValid = "Токен не валідний";
        public const string AlreadyConfirmed = "Користувач вже підтверджений";
        public const string LoginBusy = "Логін вже зайнятий";
        public const string CodeNotValid = "Код не є валідним";
        public const string TeacherCodeNotValid = "Код для викладача не є валідним";
        public const string StudentCodeNotValid = "Код для студента не є валідним";
        public const string UserNotExist = "Користувача з таким логіном не існує";
        public const string NotConfirmed = "Користувач не підтвердив акаунт";
        public const string PasswordNotComapre = "Пароль не правильний";
        public const string UsernameExist = "Нікнейм вже зайнятий";
        #endregion



        #region University
        public const string UniversityNotFound = "ВНЗ не знайдено";
        public const string UniversityIsExist = "Неможливо створити другий університет";
        #endregion

        #region Departmemt
        public const string DepartmentNotFound = "Віділення не знайдено";
        #endregion

        #region Specialty
        public const string SpecialtyNotFound = "Спеціальність не знайдено";
        #endregion

        #region Group
        public const string GroupNotFound = "Групу не знайдено";
        public const string GroupMemberNotFound = "Учасника групи не знайдено";
        public const string GroupByCodeNotFound = "Групу по коду не знайдено";
        #endregion

        #region Email
        public const string EmailNotFound = "Електронна адреса не знайдена";
        #endregion

        #region Course
        public const string CourseNotFound = "Курс не знайдено";
        #endregion

        #region Lesson
        public const string LessonNotFound = "Урок не знайдено";
        #endregion

        #region Homework
        public const string HomeworkNotFound = "Домашнє завдання не знайдено";
        #endregion

        #region File
        public const string FileNotFound = "Файл не знайдено";
        #endregion
    }
}