using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandLineTools
{
    class ArgumentFinder
    {
        private static readonly Type[] attributesInAssembly;

        static ArgumentFinder()
        {
            attributesInAssembly = typeof(ArgumentFinder).Assembly.GetTypes().Where(t => t == typeof(NamedArgumentAttribute)
             || t.BaseType == typeof(NamedArgumentAttribute)).ToArray();
        }

        public IEnumerable<ParameterToSetterMap> GetParameterSettersFor(object o)
        {
            foreach (var property in o.GetType().GetProperties())
            {
                if (property.HasAttribute(attributesInAssembly))
                {
                    var first =
                       (NamedArgumentAttribute)property.GetCustomAttributes(false).First(a => attributesInAssembly.Contains(a.GetType()));
                    var setter = GetSetMethod(property, o);
                    yield return
                      new ParameterToSetterMap { ParameterName = first.ParameterName, HelpMessage = first.Description, TypeName = property.GetGetMethod(true).ReturnType.Name, Setter = setter };
                }
            }
        }

        private Action<string> GetSetMethod(PropertyInfo property, object o)
        {
            var type = property.GetGetMethod(true).ReturnType;
            var parser = typeParser[type];
            Action<string> method = s => property.SetValue(o, parser(s), null);
            return method;
        }
        private readonly IDictionary<Type, Func<string, object>> typeParser = new Dictionary<Type, Func<string, object>>
                                                         {
                                                             {typeof(string), s=> s},
                                                             {typeof(int), s=>int.Parse(s)}
                                                         };

    }
}

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