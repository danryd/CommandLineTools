using System;

namespace CommandLineTools
{
    public  class ParameterToSetterMap
    {
        public string ParameterName { get; set; }
        public Action<string> Setter { get; set; }
        public string TypeName { get; set; }
        public string HelpMessage { get; set; }
        public string DefaultValue { get; set; }

        public void MatchAndSetParameter(string[] args)
        {
            foreach (var arg in args)
            {
                var inner = "";
                if (arg.StartsWith(Settings.Switch))
                    inner = arg.Substring(1);
                else
                    inner = "Default:" + arg;
                var param = inner.Split(Settings.Separator.ToCharArray());

                if (param[0] == ParameterName)
                {
                    var value = param.Length == 1 ? DefaultValue : param[1];
                    Setter(value);
                    return;
                }   
            }
        }
    }
}