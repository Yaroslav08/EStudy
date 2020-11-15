using System;
using System.Collections.Generic;
using System.Text;

namespace Classroom.Constants.WebApiResponses
{
    public class APIInternalServerErrorResponse : APIResponse
    {
        public APIInternalServerErrorResponse() : base(false, 500, null, "Internal erver error", null)
        { }
    }
}