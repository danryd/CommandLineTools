using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandLineTools
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class ArgumentAttribute : Attribute
    {
        private readonly string parameterName;
        private readonly string description;
        private readonly string defaultValue;
        public ArgumentAttribute(string parameterName, string description = "", string defaultValue = "")
        {
            this.parameterName = parameterName;
            this.description = description;
            this.defaultValue = defaultValue;
        }

        public string ParameterName
        {
            get { return parameterName; }
        }
        public string Description
        {
            get { return description; }
        }
        public string DefaultValue
        {
            get { return defaultValue; }
        }
    }
}

