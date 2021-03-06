﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Application.ViewModels.Group
{
    public class EmailViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string Password { get; set; }
        public GroupViewModel Group { get; set; }
    }
}