#if NETCOREAPP2_0 || NETCOREAPP3_0

using System;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Gobln.Pager.Mvc
{
    /// <summary>
    /// Provides a mechanism to get display names for Page
    /// </summary>
    public static class HtmlDisplayNameExtension
    {
        /// <summary>
        /// Gets the display name for the model.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="expression">An expression that identifies the object that contains the display name.</param>
        /// <returns>The display name for the model.</returns>
        public static string DisplayNameFor<TModel, TValue>(this IHtmlHelper<Page<TModel>> htmlHelper, Expression<Func<TModel, TValue>> expression)
        {
            if (htmlHelper == null)
            {
                throw new ArgumentNullException(nameof(htmlHelper));
            }

            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }

            return htmlHelper.DisplayNameForInnerType(expression);
        }

        /// <summary>
        /// Gets the display name for the model.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="expression">An expression that identifies the object that contains the display name.</param>
        /// <returns>The display name for the model.</returns>
        public static string DisplayNameFor<TModel, TValue>(this IHtmlHelper<PagedList<TModel>> htmlHelper, Expression<Func<TModel, TValue>> expression)
        {
            if (htmlHelper == null)
            {
                throw new ArgumentNullException(nameof(htmlHelper));
            }

            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }

            return htmlHelper.DisplayNameForInnerType(expression);
        }
    }
}

#endif