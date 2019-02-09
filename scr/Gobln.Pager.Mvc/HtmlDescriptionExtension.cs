﻿#if !NETCOREAPP2_0

using Gobln.Pager.Mvc.Infrastructure;
using System;
using System.ComponentModel;
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
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TValue">The type of the value.</typeparam>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="expression">An expression that identifies the object that contains the description name.</param>
        /// <returns>The description name for the model.</returns>
        public static MvcHtmlString DescriptionFor<TModel, TValue>(this HtmlHelper<Page<TModel>> htmlHelper, Expression<Func<TModel, TValue>> expression)
        {
            ////if (htmlHelper == null)
            ////{
            ////    throw new ArgumentNullException(nameof(htmlHelper));
            ////}

            ////if (expression == null)
            ////{
            ////    throw new ArgumentNullException(nameof(expression));
            ////}

            ////string desc;

            ////var name = ExpressionHelper.GetExpressionText(expression);

            ////var item = typeof(TModel).GetProperty(name).GetAttribute<DescriptionAttribute>(true);

            ////if (item != null)
            ////    desc = item.Description;
            ////else
            ////{
            ////    name = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            ////    desc = ModelMetadataProviders.Current.GetMetadataForProperty(() => Activator.CreateInstance<TModel>(), typeof(TModel), name).Description;
            ////}

            ////return new MvcHtmlString(desc);


            if (htmlHelper == null)
            {
                throw new ArgumentNullException(nameof(htmlHelper));
            }

            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }

            var metadata = ModelMetadata.FromLambdaExpression(expression, new ViewDataDictionary<TModel>());

            return new MvcHtmlString(HttpUtility.HtmlEncode(metadata.Description ?? string.Empty));
        }
    }
}

#endif