﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Application.ViewModels.Auth
{
    public class ConfirmViewModel : RequestModel
    {
        [MinLength(20), MaxLength(40)]
        public string Code { get; set; }
        public string GroupCode { get; set; }
    }
}