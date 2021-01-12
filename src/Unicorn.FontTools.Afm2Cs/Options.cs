using CommandLine;
using System.Collections.Generic;

namespace Unicorn.FontTools.Afm2Cs
{
    public class Options
    {
        [Option('o', "output", Required = false, Default = "", HelpText = "Name of output file.")]
        public string Output { get; set; }

        [Option('n', "namespace", Required = false, Default = "Unicorn.FontTools.Afm", HelpText = "Namespace of generated code.")]
        public string NameSpace { get; set; }

        [Option('c', "class", Required = false, Default = "StandardFontMetrics", HelpText = "Class name of generated code.")]
        public string ClassName { get; set; }

        [Value(0, HelpText = "Input AFM file paths.")]
        public IEnumerable<string> Paths { get; set; }
    }
}
