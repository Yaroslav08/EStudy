using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Application.ViewModels.IHE
{
    public class IHECreateModel : RequestModel
    {
        [Required, MinLength(3), MaxLength(200)]
        public string Name { get; set; }
        [MinLength(3), MaxLength(200)]
        public string EnglishName { get; set; }
        [MinLength(2), MaxLength(50)]
        public string ShortName { get; set; }
        public int CodeEDEBO { get; set; }
    }
}