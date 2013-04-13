using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandLineTools
{
    public static class Parse
    {
        private static ArgumentFinder argFinder = new ArgumentFinder();

        public static object Args(Type type, string[] args)
        {
            var errorList = new List<Exception>();
            try
            {
                var instance = Activator.CreateInstance(type);
                var setterMaps = argFinder.GetParameterSettersFor(instance);
                foreach (var parameterToSetterMap in setterMaps)
                {
                    try
                    {
                        parameterToSetterMap.MatchAndSetParameter(args);
                    }
                    catch (Exception ex)
                    {
                        errorList.Add(ex);
                    }

                }
                return instance;
            }
            catch (Exception ex)
            {
                errorList.Add(ex);

            }

            throw new ParsingException { Exceptions = errorList };

        }
        public static IEnumerable<string> HelpFor(Type type)
        {
            yield return "Help for " + type;
            yield return "Available switches:";
            foreach (var parametermap in  argFinder.GetParameterSettersFor(Activator.CreateInstance(type)))
            {
                var msg = parametermap.ParameterName == "Default"
                              ? "Default"
                              : string.Format("{0}{1}{2}[{3}] ({4})", Settings.Switch, parametermap.ParameterName,
                                              Settings.Separator,parametermap.TypeName, parametermap.HelpMessage);
                yield return msg;
            }

        }
        public static IEnumerable<string> HelpFor<T>()
        {
            return HelpFor(typeof(T));

        }
        public static T Args<T>(string[] args)
        {
            return (T)Args(typeof(T), args);
        }
    }
    public class ParsingException : Exception
    {
        public IEnumerable<Exception> Exceptions { get; set; }
    }
    public class Settings
    {
        public const string Switch = "/";
        public const string Separator = ":";
    }
}
