using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Domain.Models
{
    public class Group : BaseModel<int>
    {
        [Required, MinLength(2), MaxLength(25)]
        public string Name { get; set; }
        public byte IndexItemToChanged { get; set; }
        [Required]
        public bool Released { get; set; } = false;
        [Required, MinLength(6), MaxLength(12)]
        public string CodeForConnect { get; set; }
        [MinLength(5), MaxLength(500)]
        public string AdditionalInfo { get; set; }
        [MinLength(7), MaxLength(100), EmailAddress]
        public string PublicEmail { get; set; }
        [Required]
        public bool IsShowEmail { get; set; } = true;
        public List<Email> Emails { get; set; }
        public int SpecialtyId { get; set; }
        public Specialty Specialty { get; set; }
    }
}