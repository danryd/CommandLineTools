using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandLineTools
{
    [AttributeUsage( AttributeTargets.Property, AllowMultiple = false,Inherited = true)]
    public class NamedArgumentAttribute : Attribute
    {
        private readonly string parameterName;
        private readonly string description;
        public NamedArgumentAttribute(string parameterName, string description="" )
        {
            this.parameterName = parameterName;
            this.description = description;
        }

        public string ParameterName
        {
            get { return parameterName; }
        }
        public string Description
        {
            get { return description; }
        }
    }
}

