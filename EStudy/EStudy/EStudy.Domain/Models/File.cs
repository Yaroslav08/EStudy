using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Domain.Models
{
    public class File
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; } = Guid.NewGuid().ToString("N");
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int CreatedByUserId { get; set; }
        [MinLength(3), MaxLength(50)]
        public string CreatedFromIP { get; set; }
        [Required]
        public bool IsPrivate { get; set; } = false;
        [Required, MinLength(5), MaxLength(250)]
        public string Path { get; set; }
        [MinLength(2), MaxLength(50)]
        public string Assigned { get; set; }
        public long Size { get; set; } // in bytes
        [Required, MinLength(1), MaxLength(50)]
        public string Extension { get; set; }
    }
}