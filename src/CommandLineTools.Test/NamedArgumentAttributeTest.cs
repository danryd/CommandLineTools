using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace CommandLineTools.Test
{
    public class NamedArgumentAttributeTest
    {
        [Fact]
        public void ArgumentMapsToProperty()
        {
            var args = new[] { "/arg:text" };
            var target = Parse.Args<ArgTarget>(args);
            Assert.Equal("text", target.AProp);
        }
        [Fact]
        public void ArgumentMapsToIntProperty()
        {
            var args = new[] { "/arg:1" };
            var target = Parse.Args<IntTarget>(args);
            Assert.Equal(1, target.AProp);
        }
    }

    public class ArgTarget
    {
        [NamedArgument("arg")]
        public string AProp { get; set; }
    }
    public class IntTarget
    {
        [NamedArgument("arg")]
        public int AProp { get; set; }

    }
}
