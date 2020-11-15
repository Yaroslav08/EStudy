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
        #endregion
    }
}