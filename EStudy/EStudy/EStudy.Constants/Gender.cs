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

    public static class Genders
    {
        private static List<Gender> genders;

        public static List<Gender> GetGenders()
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
                    },
                    new Gender
                    {
                        Value = 2,
                        UkrName = "Інша"
                    }
                };
            }
            return genders;
        }
    }
}