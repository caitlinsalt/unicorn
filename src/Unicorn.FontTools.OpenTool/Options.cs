using CommandLine;

namespace Unicorn.FontTools.OpenTool
{
    public class Options
    {
        [Option('t', "list-tables", Required = false, Default = false, HelpText = "List the tables present in the font.")]
        public bool ListTables { get; set; }

        [Option('d', "dump-table", Required = false, Default = "", HelpText = "Dump the contents of a named font table.")]
        public string DumpTable { get; set; }

        [Value(0, Required = true, HelpText = "Font file to open.")]
        public string Path { get; set; }
    }
}
