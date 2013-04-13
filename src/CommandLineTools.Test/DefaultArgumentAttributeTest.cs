using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Xunit;

namespace CommandLineTools.Test
{
    public class DefaultArgumentAttributeTest
    {

        [Fact]
        public void DefaultArgumentMapsToProperty()
        {
            var args = new[] {"text"};
            var target = Parse.Args<DefaultTarget>(args);
            Assert.Equal("text",target.AString);
        }
        [Fact]
        public void CanGetDefaultArgumentFromProperty()
        {
            var prop = typeof (DefaultTarget).GetProperty("AString");
            var result = prop.HasAttribute(new Type[] {typeof (DefaultArgumentAttribute)});
            Assert.True(result);
        }

    }

    public class DefaultTarget
    {
        [DefaultArgument]
        public string AString { get; set; }
    }
}
