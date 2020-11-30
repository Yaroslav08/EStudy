using EStudy.Application.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Application.ViewModels.Group
{
    public class GroupMemberViewModel
    {
        public int Id { get; set; }
        public GroupViewModel Group { get; set; }
        public UserShortViewModel User { get; set; }
        public string Role { get; set; }
        public string Title { get; set; }
    }
}