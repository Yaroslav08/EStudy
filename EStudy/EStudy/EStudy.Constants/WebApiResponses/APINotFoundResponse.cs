using System;
using System.Collections.Generic;
using System.Text;

namespace Classroom.Constants.WebApiResponses
{
    public class APINotFoundResponse : APIResponse
    {
        public APINotFoundResponse(string errormessage = "Resource not found") : base(false, 404, null, errormessage, null)
        { }
    }
}