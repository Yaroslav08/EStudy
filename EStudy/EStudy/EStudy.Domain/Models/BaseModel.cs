using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Domain.Models
{
    public class BaseModel<TypeId>
    {
        [Key]
        public TypeId Id{ get; set; }
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [MinLength(3), MaxLength(50)]
        public string CreatedFromIP { get; set; }
        public int CreatedByUserId { get; set; }




        [Required]
        public bool IsEdit { get; set; } = false;
        public DateTime? DateLastEdit { get; set; }
        [MinLength(3), MaxLength(50)]
        public string EditedFromIP { get; set; }
        public int? EditedByUserId { get; set; }
        public string History { get; set; }
    }
}