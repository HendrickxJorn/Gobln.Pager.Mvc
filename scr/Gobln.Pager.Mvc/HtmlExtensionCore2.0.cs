#if NETCOREAPP2_0

using Gobln.Pager.Mvc.Builder;
using Gobln.Pager.Mvc.Infrastructure;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Gobln.Pager.Mvc
{
    /// <summary>
    /// Provides a mechanism to get the Pager
    /// </summary>
    public static class HtmlExtension
    {
        /// <summary>
        /// Create pager with default <see cref="PagerOptions"/>
        /// </summary>
        /// <param name="html">The HTML helper instance that this method extends.</param>
        /// <param name="page">Page that will be converted to an page</param>
        /// <returns></returns>
        public static IHtmlContent Pager(this IHtmlHelper html, IPage page)
        {
            return Pager(html, page, new PagerOptions());
        }

        /// <summary>
        /// Create pager
        /// </summary>
        /// <param name="html">The HTML helper instance that this method extends.</param>
        /// <param name="page">Page that will be converted to an page</param>
        /// <param name="pagerOptions">PageOptions</param>
        /// <returns></returns>
        public static IHtmlContent Pager(this IHtmlHelper html, IPage page, PagerOptions pagerOptions)
        {
            if (pagerOptions == null)
                throw new ArgumentNullException("pagerOptions");

            if (pagerOptions.ItemShowOrder == null)
                throw new ArgumentNullException("pagerOptions.ItemShowOrder");

            if (page == null || (!page.HasPaging && pagerOptions.HideIfNotPaged))
                return new HtmlContentBuilder();

            if (!pagerOptions.UrlDisable)
            {
                if (string.IsNullOrWhiteSpace(pagerOptions.Url))
                {
                    pagerOptions.Url = Helper.GetCurrentUrlString(html.ViewContext);
                }
                else
                {
                    if (!Uri.TryCreate(pagerOptions.Url, UriKind.Absolute, out Uri uriResult))
                        throw new ArgumentException("Invalid Url. The Url does not start with http or https, or is invallid.", "pagerOptions.Url");
                }
            }

            return new PagerBuilder(page, pagerOptions).Render();
        }
    }
}

#endif