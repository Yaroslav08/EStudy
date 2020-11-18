using EStudy.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Domain.Models
{
    public class GroupMember : BaseModel<int>
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; }

        public GroupMemberRole MemberRole { get; set; }
        [MinLength(2), MaxLength(25)]
        public string Title { get; set; }
    }
}