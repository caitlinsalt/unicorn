using CommandLine;

namespace Unicorn.ImageConvert
{
    public class Options
    {
        [Option('o', "out", Required = true, HelpText = "Output file name.")]
        public string Out { get; set; }

        [Option("verbose", Required = false, Default = false, HelpText = "Output progress information.")]
        public bool Verbose { get; set; }

        [Option('w', "wireframe", Required = false, Default = false, HelpText = "Produce wireframe file without actual images")]
        public bool Wireframe { get; set; }

        [Option('m', "mock", Required = false, Default = false, HelpText = "Produce wireframe with mocked blocks of colour rather than actual images.")]
        public bool Mock { get; set; }

        [Option('r', "recursive", Required = false, Default = false, HelpText = "Recurse into subfolders")]
        public bool Recursive { get; set; }

        [Value(0)]
        public IEnumerable<string> InputFiles { get; set; }
    }
}
