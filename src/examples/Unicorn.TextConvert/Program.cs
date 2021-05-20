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
            await foreach (var para in inputProvider.GetParagraphsAsync())
            {
                Paragraph outputPara = new(page.PageAvailableWidth, page.BottomMarginPosition - page.CurrentVerticalCursor, Orientation.Normal, para.Alignment, 
                    VerticalAlignment.Top, margins);
                outputPara.AddText(para.Content, font, page.PageGraphics);
                outputPara.DrawAt(page.PageGraphics, page.LeftMarginPosition, page.CurrentVerticalCursor);
                page.CurrentVerticalCursor += outputPara.ContentHeight;
            }
            using FileStream outputStream = new(options.Out, FileMode.Create, FileAccess.Write);
            document.Write(outputStream);
        }
    }
}
