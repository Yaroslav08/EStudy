using System;
using System.Collections.Generic;
using System.Text;

namespace Classroom.Constants.WebApiResponses
{
    public class APIResponse
    {
        public bool OK { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }
        public DateTime TimeSpan { get; set; } = DateTime.Now;
        public object Data { get; set; }

        public APIResponse(bool ok, int statuscode, string message, string errormessage, object data)
        {
            OK = ok;
            StatusCode = statuscode;
            Message = message;
            ErrorMessage = errormessage;
            Data = data;
        }
    }
}