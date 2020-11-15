using System;
using System.Collections.Generic;
using System.Text;

namespace Classroom.Constants.WebApiResponses
{
    public class APIBadRequestResponse : APIResponse
    {
        public APIBadRequestResponse(string errormessage) : base(false, 400, null, errormessage, null)
        { }
    }
}