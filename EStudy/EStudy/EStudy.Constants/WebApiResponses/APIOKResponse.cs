using System;
using System.Collections.Generic;
using System.Text;

namespace Classroom.Constants.WebApiResponses
{
    public class APIOKResponse : APIResponse
    {
        public APIOKResponse(object Data = null, string Message = "Success") : base(true, 200, Message, null, Data)
        { }
    }
}