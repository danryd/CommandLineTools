using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandLineTools
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DefaultArgumentAttribute :ArgumentAttribute
    {
        public DefaultArgumentAttribute(string description = "") : base("Default",description)
        {
        }
    }


}
