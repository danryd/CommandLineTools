using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace CommandLineTools.Test
{
    public class ArgumentAttributeTest
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
        [Fact]
        public void ArgumentMapsToBoolProperty()
        {
            var args = new[] { "/arg:true" };
            var target = Parse.Args<BoolTarget>(args);
            Assert.Equal(true, target.AProp);
        }
        [Fact]
        public void ValuelessArgumentMapsToBoolProperty()
        {
            var args = new[] { "/arg" };
            var target = Parse.Args<ValuelessTarget>(args);
            Assert.Equal(true, target.AProp);
        }

    }

    public class ArgTarget
    {
        [Argument("arg")]
        public string AProp { get; set; }
    }
    public class IntTarget
    {
        [Argument("arg")]
        public int AProp { get; set; }

    }
    public class BoolTarget {
        [Argument("arg")]
        public bool AProp{get;set;}
    }
    public class ValuelessTarget
    {
        [Argument("arg","","true")]
        public bool AProp { get; set; }
    }
}
