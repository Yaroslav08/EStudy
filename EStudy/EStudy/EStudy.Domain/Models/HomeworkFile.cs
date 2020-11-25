using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Domain.Models
{
    public class HomeworkFile
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Id { get; set; } = Guid.NewGuid().ToString("N");
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int LoadByUserId { get; set; }
        [Required, MinLength(5), MaxLength(250)]
        public string Path { get; set; }
        public string OriginalName { get; set; }
        public long HomeworkId { get; set; }
        public Homework Homework { get; set; }
    }
}