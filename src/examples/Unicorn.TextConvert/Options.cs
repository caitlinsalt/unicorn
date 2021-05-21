using CommandLine;

namespace Unicorn.TextConvert
{
    public class Options
    {
        [Option('i', "in", Required = true, HelpText = "Input file name.")]
        public string In { get; set; }

        [Option('o', "out", Required = true, HelpText = "Output file name.")]
        public string Out { get; set; }

        [Option("no-compression", Required = false, Default = false, HelpText = "Do not compress the output file's contents.")]
        public bool NoCompression { get; set; }

        [Option("verbose", Required = false, Default = false, HelpText = "Output progress information.")]
        public bool Verbose { get; set; }
    }
}
