using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Application.ViewModels.Group
{
    public class GroupMemberModel : RequestModel
    {
        [Range(0, 2147483647)]
        public int Id { get; set; }
        [Range(0, 2147483647)]
        public int GroupId { get; set; }
        [Range(0, 2147483647)]
        public int MemberId { get; set; }
        [MinLength(2), MaxLength(25)]
        public string Title { get; set; }
        public GroupMemberRoleModel MemberRole { get; set; }
    }
    public enum GroupMemberRoleModel
    {
        ClassTeacher,
        Headman,
        Student
    }

}