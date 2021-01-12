using CommandLine;
using System;
using System.IO;
using System.IO.MemoryMappedFiles;
using Unicorn.FontTools.OpenType;

namespace Unicorn.FontTools.OpenTool
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(o => RunTool(o))
                .WithNotParsed(o => Environment.Exit(1));    
        }

        private static void RunTool(Options options)
        {
            using MemoryMappedFile file = MemoryMappedFile.CreateFromFile(options.Path, FileMode.Open, null, 0, MemoryMappedFileAccess.Read);
            using OpenTypeFont font = new OpenTypeFont(file, options.Path);
            Console.WriteLine($"File {options.Path} is a {font.OffsetHeader.FontKind} font.");
            if (options.ListTables)
            {
                ListTables(font);
            }
            if (!string.IsNullOrWhiteSpace(options.DumpTable))
            {
                DumpTable(font, options.DumpTable);
            }
        }

        private static void ListTables(OpenTypeFont font)
        {
            Console.WriteLine(Resources.TableListHeader);
            foreach (TableIndexRecord indexRecord in font.TableIndex.Values)
            {
                Console.WriteLine($"{indexRecord.TableTag} | {indexRecord.Offset,10} | {indexRecord.Length,10}");
            }
        }

        private static void DumpTable(OpenTypeFont font, string table)
        {
            Table t = font.GetTableData(new Tag(table));
            if (t is null)
            {
                Console.WriteLine($"Table {table} cannot be loaded.");
            }
            else
            {
                t.Dump(Console.Out);
            }
        }
    }
}
