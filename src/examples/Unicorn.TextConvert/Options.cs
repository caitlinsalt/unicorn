using CommandLine;

namespace Unicorn.TextConvert
{
    public class Options
    {
        [Option('i', "in", Required = true, HelpText = "Input file name.")]
        public string In { get; set; }

        [Option('o', "out", Required = true, HelpText = "Output file name.")]
        public string Out { get; set; }
    }
}
