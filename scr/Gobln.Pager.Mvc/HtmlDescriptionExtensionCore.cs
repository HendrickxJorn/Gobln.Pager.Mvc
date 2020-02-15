#if NETCOREAPP2_0 || NETCOREAPP3_0

using System.Reflection;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace Gobln.Pager.Mvc
{
    /// <summary>
    /// Provides a mechanism to get display names for Page
    /// </summary>
    public static class HtmlDescriptionExtension
    {
        /// <summary>
        /// Gets the description name for the model.
        /// If DescriptionAttribute is not found than will look for DisplayAttribute to get the description from.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="expression">An expression that identifies the object that contains the description name.</param>
        /// <returns>The description name for the model.</returns>
        public static string DescriptionFor<TModel, TValue>(this IHtmlHelper<Page<TModel>> htmlHelper, Expression<Func<TModel, TValue>> expression)
        {
            if (htmlHelper == null)
            {
                throw new ArgumentNullException(nameof(htmlHelper));
            }

            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }

            var m = (expression.Body as MemberExpression).Member;

            return m.GetCustomAttribute<DescriptionAttribute>(false)?.Description ?? m.GetCustomAttribute<DisplayAttribute>(false)?.Description;
        }

        /// <summary>
        /// Gets the description name for the model.
        /// If DescriptionAttribute is not found than will look for DisplayAttribute to get the description from.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="expression">An expression that identifies the object that contains the description name.</param>
        /// <returns>The description name for the model.</returns>
        public static string DescriptionFor<TModel, TValue>(this IHtmlHelper<PagedList<TModel>> htmlHelper, Expression<Func<TModel, TValue>> expression)
        {
            if (htmlHelper == null)
            {
                throw new ArgumentNullException(nameof(htmlHelper));
            }

            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }

            var m = (expression.Body as MemberExpression).Member;

            return m.GetCustomAttribute<DescriptionAttribute>(false)?.Description ?? m.GetCustomAttribute<DisplayAttribute>(false)?.Description;
        }
    }
}
#endif