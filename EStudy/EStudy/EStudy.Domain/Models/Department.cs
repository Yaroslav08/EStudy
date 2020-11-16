using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Domain.Models
{
    public class Department : BaseModel<int>
    {
        [Required, MinLength(4), MaxLength(60)]
        public string Name { get; set; }
        [MinLength(2), MaxLength(100)]
        public string Shifr { get; set; }
        public int? HeadById { get; set; }
        [Required, Phone]
        public string Phone { get; set; }
        [MinLength(15), MaxLength(3000)]
        public string ContactInformation { get; set; }
        [MinLength(10), MaxLength(300)]
        public string Description { get; set; }
        public int IHEId { get; set; }
        public IHE IHE { get; set; }
    }
}