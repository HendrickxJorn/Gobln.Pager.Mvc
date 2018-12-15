#if !NETCOREAPP2_0

using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

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
        /// <param name="html">The HTML helper instance that this method extends.</param>
        /// <param name="expression">An expression that identifies the object that contains the display name.</param>
        /// <returns>The display name for the model.</returns>
        public static MvcHtmlString DisplayNameFor<TModel, TValue>(this HtmlHelper<Page<TModel>> html, Expression<Func<TModel, TValue>> expression)
        {
            return DisplayNameForInternal(html, expression, metadataProvider: null);
        }

        internal static MvcHtmlString DisplayNameForInternal<TModel, TValue>(this HtmlHelper<Page<TModel>> html, Expression<Func<TModel, TValue>> expression, ModelMetadataProvider metadataProvider)
        {
            return
                DisplayNameHelper(
                    ModelMetadata.FromLambdaExpression(expression, new ViewDataDictionary<TModel>()),
                    ExpressionHelper.GetExpressionText(expression));
        }

        internal static MvcHtmlString DisplayNameHelper(ModelMetadata metadata, string htmlFieldName)
        {
            var resolvedDisplayName = metadata.DisplayName ??
                                         metadata.PropertyName ??
                                            htmlFieldName.Split('.').Last();

            return new MvcHtmlString(HttpUtility.HtmlEncode(resolvedDisplayName));
        }
    }
}

#endif