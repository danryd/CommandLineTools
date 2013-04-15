A toolkit to help building command line stuff.
Currently  maps string[] (ie args) to an object, mapped by attributes, ex:

	public class Options
    {
        [DefaultArgument]
        public string AString { get; set; }
        [Argument("arg", "A general argument")]
        public string AProp { get; set; }
    }
	
	Would map a commandline of some.exe amazing /arg:stuff using 
	
	var opts = Parse.Args<Options>(args) to an instance where AString == amazing and AProp == stuff 