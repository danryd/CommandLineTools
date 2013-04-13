using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace System.Reflection
{
    public static class PropertyExtensions
    {
        public static bool HasAttribute(this PropertyInfo property, Type[] attributeTypes)
        {
            var attributes = property.GetCustomAttributes(false);
            return attributes.Any(a => attributeTypes.Contains(a.GetType()));
        }
    }
}