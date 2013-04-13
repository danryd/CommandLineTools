using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace CommandLineTools.Test
{
    public class ApiTest
    {
        [Fact]
        public void CanMapMultiple()
        {
            var result = Parse.Args<ApiTarget>(new[] { "text", "/arg:something" });
            Assert.Equal(result.AProp, "something");
            Assert.Equal(result.AString, "text");

        }

        [Fact]
        public void CanGetHelp()
        {
            var help = Parse.HelpFor<ApiTarget>();
            foreach (var row in help)
            {
                Console.WriteLine(row);
            }
            Assert.Equal(4,help.Count());
        }
    }

    public class ApiTarget
    {
        [DefaultArgument]
        public string AString { get; set; }
        [Argument("arg", "A general argument")]
        public string AProp { get; set; }
    }
}
