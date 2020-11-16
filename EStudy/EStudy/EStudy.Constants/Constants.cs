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
        public const string UserNotExist = "Користувача з таким логіном не існує";
        public const string NotConfirmed = "Користувач не підтвердив акаунт";
        public const string PasswordNotComapre = "Пароль не правильний";
        #endregion



        #region IHE
        public const string IHENotFound = "ВНЗ не знайдено";
        #endregion
    }
}