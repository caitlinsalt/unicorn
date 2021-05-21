using CommandLine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Unicorn.Base;
using Unicorn.FontTools.StandardFonts;
using Unicorn.Writer;
using Unicorn.Writer.Structural;

namespace Unicorn.TextConvert
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args).WithParsedAsync(RunToolAsync).Wait();
        }

        static async Task RunToolAsync(Options options)
        {
            if (options.NoCompression)
            {
                Features.SelectedStreamFeatures &= ~Features.StreamFeatures.CompressPageContentStreams;
            }

            var font = PdfStandardFontDescriptor.GetByName("Times-Roman", 12);
            PdfDocument document = new();
            var page = document.AppendPage();
            page.CurrentVerticalCursor = page.TopMarginPosition;
            MarginSet margins = new(0, 0, 12, 0);
            using StreamReader inputReader = new(options.In);
            await using StreamedParagraphProvider inputProvider = new(inputReader);
            int pageCount = 0;
            int paraCount = 0;
            await foreach (var para in inputProvider.GetParagraphsAsync())
            {
                Paragraph outputPara = new(page.PageAvailableWidth, page.BottomMarginPosition - page.CurrentVerticalCursor, Orientation.Normal, para.Alignment, 
                    VerticalAlignment.Top, margins);
                outputPara.AddText(para.Content, font, page.PageGraphics);
                if (outputPara.OverspillHeight)
                {
                    if (options.Verbose)
                    {
                        Console.Out.WriteLine($"Adding page {pageCount++} (paragraph {paraCount})");
                    }
                    page = document.AppendPage();
                    page.CurrentVerticalCursor = page.TopMarginPosition;
                }
                outputPara.DrawAt(page.PageGraphics, page.LeftMarginPosition, page.CurrentVerticalCursor);
                page.CurrentVerticalCursor += outputPara.ContentHeight;
                paraCount++;
            }
            using FileStream outputStream = new(options.Out, FileMode.Create, FileAccess.Write);
            document.Write(outputStream);
        }
    }
}
