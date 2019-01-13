#if NETCOREAPP2_0

using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Gobln.Pager.Mvc.Infrastructure
{
    internal static class Helper
    {
        public static string GetCurrentUrlString(ViewContext viewContext, string[] excludeParms = null)
        {
            var absoluteUri = new Uri($"{viewContext.HttpContext.Request.Scheme}://{viewContext.HttpContext.Request.Host}{viewContext.HttpContext.Request.Path}{viewContext.HttpContext.Request.QueryString}");

            var uriBuilder = new UriBuilder(absoluteUri);

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
                if (queryValues != null)
                {
                    foreach (var param in queryValues.Select(c => c.Key))
                    {
                        parseQueryString.Remove(param);
                    }
                }
            }

            if (queryValues != null)
            {
                foreach (var param in queryValues)
                {
                    parseQueryString.Add(param.Key, param.Value);
                }
            }

            uriBuilder.Query = parseQueryString.ToString();

            return uriBuilder.Uri.AbsoluteUri;
        }
    }
}

#endif