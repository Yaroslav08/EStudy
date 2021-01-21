using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace EStudy.Constants
{
    public class SocialLinksValidate
    {
        private static bool BaseUrlIsValid(string url)
        {
            if (url.StartsWith("https://") || url.StartsWith("http://"))
                return true;
            return false;
        }

        public static bool TwitterIsValid(string url)
        {
            if (!BaseUrlIsValid(url))
                return false;
            if (url.StartsWith("https://twitter.com") || url.StartsWith("https://www.twitter.com"))
                return true;
            return false;
        }

        public static bool InstagramIsValid(string url)
        {
            if (!BaseUrlIsValid(url))
                return false;
            if (url.StartsWith("https://instagram.com") || url.StartsWith("https://www.instagram.com"))
                return true;
            return false;
        }

        public static bool FacebookIsValid(string url)
        {
            if (!BaseUrlIsValid(url))
                return false;
            if (url.StartsWith("https://facebook.com") || url.StartsWith("https://www.facebook.com"))
                return true;
            return false;
        }

        public static bool GitHubIsValid(string url)
        {
            if (!BaseUrlIsValid(url))
                return false;
            if (url.StartsWith("https://github.com") || url.StartsWith("https://www.github.com"))
                return true;
            return false;
        }
    }
}