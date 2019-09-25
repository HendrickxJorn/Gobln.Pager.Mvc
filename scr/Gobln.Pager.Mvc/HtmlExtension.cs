#if !(NETCOREAPP2_0 || NETCOREAPP3_0)

using Gobln.Pager.Mvc.Builder;
using Gobln.Pager.Mvc.Infrastructure;
using System;
using System.Web.Mvc;

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
        public static MvcHtmlString Pager(this HtmlHelper html, IPage page)
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
        public static MvcHtmlString Pager(this HtmlHelper html, IPage page, IPagerOptions pagerOptions)
        {
            if (pagerOptions == null)
                throw new ArgumentNullException("pagerOptions");

            if (pagerOptions.ItemShowOrder == null)
                throw new ArgumentNullException("pagerOptions.ItemShowOrder");

            if (page == null || (!page.HasPaging && pagerOptions.HideIfNotPaged))
                return MvcHtmlString.Create(string.Empty);

            if (!pagerOptions.UrlDisable)
            {
                if (string.IsNullOrWhiteSpace(pagerOptions.Url))
                {
                    pagerOptions.Url = Helper.GetCurrentUrlString(html);
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