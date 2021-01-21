using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Constants
{
    public class SocialLinksValidate
    {
        public static bool IsValidUrl(string url, params string[] startFromTemplate)
        {
            bool isValid = false;
            startFromTemplate.ToList().ForEach(d =>
            {
                if (url.StartsWith(d))
                {
                    isValid = true;
                    return;
                }
            });
            return isValid;
        }
    }
}