#if NETCOREAPP2_0

using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Internal;
using System;
using System.Linq.Expressions;

namespace Gobln.Pager.Mvc
{
    /// <summary>
    /// Provides a mechanism to get display names for Page
    /// </summary>
    public static class HtmlDescriptionExtension
    {
        /// <summary>
        /// Gets the description name for the model.
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

            var modelExplorer = ExpressionMetadataProvider.FromLambdaExpression(expression
                                , new ViewDataDictionary<TModel>(new EmptyModelMetadataProvider(), new ModelStateDictionary())
                                , htmlHelper.MetadataProvider);

            return modelExplorer?.Metadata?.Description;
        }
    }
}

#endif