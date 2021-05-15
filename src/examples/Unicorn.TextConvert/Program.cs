using CommandLine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Unicorn.Base;
using Unicorn.FontTools.StandardFonts;
using Unicorn.Writer;

namespace Unicorn.TextConvert
{
    class Program
    {
        static void Main(string[] args)
        {
            Features.SelectedStreamFeatures &= ~Features.StreamFeatures.CompressPageContentStreams;
            Parser.Default.ParseArguments<Options>(args).WithParsedAsync(RunToolAsync).Wait();
        }

        static async Task RunToolAsync(Options options)
        {
            var font = PdfStandardFontDescriptor.GetByName("Times-Roman", 12);
            PdfDocument document = new();
            var page = document.AppendPage();
            page.CurrentVerticalCursor = page.TopMarginPosition;
            using StreamReader inputReader = new(options.In);
            await using StreamedParagraphProvider inputProvider = new(inputReader);
            await foreach (var para in inputProvider.GetParagraphsAsync())
            {
                Console.Out.WriteLine($"At {page.CurrentVerticalCursor}: {para.Content}");
                Paragraph outputPara = new(page.PageAvailableWidth, page.BottomMarginPosition - page.CurrentVerticalCursor, Orientation.Normal, para.Alignment, 
                    VerticalAlignment.Top);
                outputPara.AddText(para.Content, font, page.PageGraphics);
                outputPara.DrawAt(page.PageGraphics, page.LeftMarginPosition, page.CurrentVerticalCursor);
                page.CurrentVerticalCursor += outputPara.ContentHeight;
            }
            using FileStream outputStream = new(options.Out, FileMode.Create, FileAccess.Write);
            document.Write(outputStream);
        }
    }
}
