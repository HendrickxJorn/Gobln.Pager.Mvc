#if !(NETCOREAPP2_0 || NETCOREAPP3_0)

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace Gobln.Pager.Mvc
{
    /// <summary>
    /// Provides a mechanism to get description names for Page
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
        public static MvcHtmlString DescriptionFor<TModel, TValue>(this HtmlHelper<Page<TModel>> htmlHelper, Expression<Func<TModel, TValue>> expression)
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

            return new MvcHtmlString(HttpUtility.HtmlEncode(((DescriptionAttribute)Attribute.GetCustomAttribute(m, typeof(DescriptionAttribute), false))?.Description
                        ?? ((DisplayAttribute)Attribute.GetCustomAttribute(m, typeof(DisplayAttribute), false))?.Description));
        }
    }
}

#endif