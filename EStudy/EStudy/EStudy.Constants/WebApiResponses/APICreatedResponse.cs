using System;
using System.Collections.Generic;
using System.Text;

namespace Classroom.Constants.WebApiResponses
{
    public class APICreatedResponse : APIResponse
    {
        public APICreatedResponse(string message = "Success created") : base(true, 201, message, null, null)
        { }
    }
}