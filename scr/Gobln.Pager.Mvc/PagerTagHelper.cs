#if NETCOREAPP2_0

using Gobln.Pager.Mvc.Builder;
using Gobln.Pager.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gobln.Pager.Mvc.TagHelpers
{
    /// <summary>
    /// Create pager
    /// </summary>
    [HtmlTargetElement("pager", Attributes = "page")]
    [HtmlTargetElement("pager", Attributes = "page, pager-options")]
    public class PagerTagHelper : TagHelper
    {
        /// <summary>
        /// Page that will be converted to an page
        /// </summary>
        [HtmlAttributeName("page")]
        public IPage Page { get; set; }

        /// <summary>
        /// The options of the pager
        /// </summary>
        [HtmlAttributeName("pager-options")]
        public PagerOptions PagerOptions { get; set; }

        /// <summary>
        /// ViewContext
        /// </summary>
        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        /// <summary>
        /// Synchronously executes the Gobln.Pager.Mvc.TagHelpers.PagerTagHelper with the given context and output.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="output"></param>
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            BuildPager(context, output);
        }

        /// <summary>
        /// Asynchronously executes the Gobln.Pager.Mvc.TagHelpers.PagerTagHelper with the given context and output.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="output"></param>
        /// <returns></returns>
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var child = await output.GetChildContentAsync();
            if (child.IsEmptyOrWhiteSpace)
                BuildPager(context, output);
        }

        private void BuildPager(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = null;
            output.TagMode = TagMode.StartTagAndEndTag;

            if (Page.HasPaging)
            {
                if (PagerOptions == null)
                    PagerOptions = new PagerOptions();

                if (!PagerOptions.UrlDisable)
                {
                    if (string.IsNullOrWhiteSpace(PagerOptions.Url))
                    {
                        PagerOptions.Url = Helper.GetCurrentUrlString(ViewContext);
                    }
                    else if (!Uri.TryCreate(PagerOptions.Url, UriKind.Absolute, out Uri uriResult))
                        throw new ArgumentException("Invalid Url. The Url does not start with http or https, or is invallid.", "pagerOptions.Url");
                }

                output.PostContent.SetHtmlContent(new PagerBuilder(Page, PagerOptions).Render().GetHtmlAsString());
            }
        }

        private static IEnumerable<T> ConvertToEnumEnumerable<T>(string value)
        {
            foreach (var item in value.Split(',').Where(c => !string.IsNullOrWhiteSpace(c)))
            {
                if (Enum.TryParse(typeof(T), item.Trim(), true, out object tempItemShow))
                    yield return (T)tempItemShow;
            }
        }

        private static T ConvertToEnum<T>(string value, T defaultVal)
        {
            if (Enum.TryParse(typeof(T), value.Trim(), true, out object tempItemShow))
                return (T)tempItemShow;

            return defaultVal;
        }
    }
}

#endif