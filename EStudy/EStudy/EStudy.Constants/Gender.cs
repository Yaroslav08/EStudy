using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Constants
{
    public class Gender
    {
        public int Value { get; set; }
        public string UkrName { get; set; }
    }

    public class Genders
    {
        private List<Gender> genders;

        public List<Gender> GetGenders()
        {
            if (genders == null || genders.Count == 0)
            {
                genders = new List<Gender>
                {
                    new Gender
                    {
                        Value = 0,
                        UkrName = "Жінка"
                    },
                    new Gender
                    {
                        Value = 1,
                        UkrName = "Чоловік"
                    }
                };
            }
            return genders;
        }
    }
}