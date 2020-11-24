using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Application.ViewModels.Group
{
    public class GroupCreateModel : RequestModel
    {
        [Required, MinLength(2), MaxLength(25)]
        public string Name { get; set; }
        [Required]
        public byte Course { get; set; }
        [Required]
        public DateTime StartStudy { get; set; }
        [Required]
        public DateTime EndStudy { get; set; }
        public byte? IndexItemToChanged { get; set; }
        [Required]
        public bool IsReleased { get; set; }
        [Required]
        public byte CountStudents { get; set; }
        [MinLength(5), MaxLength(500)]
        public string AdditionalInfo { get; set; }
        [MinLength(7), MaxLength(100), EmailAddress]
        public string Email { get; set; }
        [Required]
        public bool IsShowEmail { get; set; }
        public int SpecialtyId { get; set; }
    }
}