#if !(NETCOREAPP2_0 || NETCOREAPP3_0)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gobln.Pager.Mvc.Infrastructure
{
    internal static class Helper
    {
        public static string GetCurrentUrlString(HtmlHelper html, string[] excludeParms = null)
        {
            var uriBuilder = new UriBuilder(html.ViewContext.HttpContext.Request.Url.AbsoluteUri);

            var parseQueryString = HttpUtility.ParseQueryString(uriBuilder.Query);

            if (parseQueryString.HasKeys())
            {
                foreach (var param in new string[] { "x-requested-with", "xmlhttprequest" })
                {
                    parseQueryString.Remove(param);
                }

                if (excludeParms != null)
                {
                    foreach (var param in excludeParms)
                    {
                        parseQueryString.Remove(param);
                    }
                }
            }

            uriBuilder.Query = parseQueryString.ToString();

            return uriBuilder.Uri.AbsoluteUri;
        }

        public static string AddQueryValuesToUrlString(string url, Dictionary<string, string> queryValues)
        {
            var uriBuilder = new UriBuilder(url);

            var parseQueryString = HttpUtility.ParseQueryString(uriBuilder.Query);

            if (parseQueryString.HasKeys())
            {
                foreach (var param in queryValues.Select(c => c.Key))
                {
                    parseQueryString.Remove(param);
                }
            }

            foreach (var param in queryValues)
            {
                parseQueryString.Add(param.Key, param.Value);
            }

            uriBuilder.Query = parseQueryString.ToString();

            return uriBuilder.Uri.AbsoluteUri;
        }
    }
}

#endif