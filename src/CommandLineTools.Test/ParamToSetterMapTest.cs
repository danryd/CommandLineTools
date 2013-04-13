using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace CommandLineTools.Test
{
    public class ParamToSetterMapTest
    {
        [Fact]
        public void CanMapDefaultAttrib()
        {
            var toSet = "";
            var setterMap = new ParameterToSetterMap {ParameterName = "Default", Setter = s => toSet = s};
                setterMap.MatchAndSetParameter(new[]{"AString"});
            Assert.Equal("AString",toSet);

        }

        [Fact]
        public void CanMapAttrib()
        {
            var toSet = "";
            var setterMap = new ParameterToSetterMap { ParameterName = "map", Setter = s => toSet = s };
            setterMap.MatchAndSetParameter(new[]{"/map:me"});
            Assert.Equal("me", toSet);

        }
    }
}
