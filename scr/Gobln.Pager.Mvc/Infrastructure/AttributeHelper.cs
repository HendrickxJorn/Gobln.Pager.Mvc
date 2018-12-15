using System;
using System.Linq;
using System.Reflection;

namespace Gobln.Pager.Mvc.Infrastructure
{
    internal static class AttributeHelper
    {
        /// <summary>
        /// Get the first attribute from Type
        /// </summary>
        /// <typeparam name="T">The attribute toget</typeparam>
        /// <param name="source">The Type</param>
        /// <param name="inherit">true to search this member's inheritance chain to find the attributes; otherwise, false. This parameter is ignored for properties and events; see Remarks.</param>
        /// <returns>The first attribute or empty</returns>
        internal static T GetAttribute<T>(this Type source, bool inherit = false) where T : Attribute
        {
            return source.GetCustomAttributes(typeof(T), inherit).FirstOrDefault() as T;
        }

        /// <summary>
        /// Get the first attribute from PropertyInfo
        /// </summary>
        /// <typeparam name="T">The attribute toget</typeparam>
        /// <param name="source">The PropertyInfo</param>
        /// <param name="inherit">true to search this member's inheritance chain to find the attributes; otherwise, false. This parameter is ignored for properties and events; see Remarks.</param>
        /// <returns>The first attribute or empty</returns>
        internal static T GetAttribute<T>(this PropertyInfo source, bool inherit = false) where T : Attribute
        {
            return source.GetCustomAttributes(typeof(T), inherit).FirstOrDefault() as T;
        }

        /// <summary>
        /// Get the first attribute from FieldInfo
        /// </summary>
        /// <typeparam name="T">The attribute toget</typeparam>
        /// <param name="source">The FieldInfo</param>
        /// <param name="inherit">true to search this member's inheritance chain to find the attributes; otherwise, false. This parameter is ignored for properties and events; see Remarks.</param>
        /// <returns>The first attribute or empty</returns>
        internal static T GetAttribute<T>(this FieldInfo source, bool inherit = false) where T : Attribute
        {
            return source.GetCustomAttributes(typeof(T), inherit).FirstOrDefault() as T;
        }
    }
}