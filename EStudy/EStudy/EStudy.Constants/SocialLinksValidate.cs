using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Constants
{
    public class SocialLinksValidate
    {
        private bool BaseUrlIsValid(string url)
        {
            if (url.StartsWith("https://") || url.StartsWith("http://"))
                return true;
            return false;
        }

        public bool TwitterIsValid(string url)
        {
            if (!BaseUrlIsValid(url))
                return false;

            if (url.StartsWith("https://twitter.com") || url.StartsWith("https://api.twitter.com"))
                return true;
            return false;
        }
    }
}