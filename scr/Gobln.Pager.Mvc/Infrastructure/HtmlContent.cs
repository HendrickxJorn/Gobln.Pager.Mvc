#if NETCOREAPP2_0

using Microsoft.AspNetCore.Html;
using System.Text.Encodings.Web;

namespace Gobln.Pager.Mvc.Infrastructure
{
    internal static class HtmlContentExtension
    {
        internal static string GetHtmlAsString(this IHtmlContent content)
        {
            var writer = new System.IO.StringWriter();
            content.WriteTo(writer, HtmlEncoder.Default);
            return writer.ToString();
        }
    }
}

#endif