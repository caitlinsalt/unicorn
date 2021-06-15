using CommandLine;
using System;
using System.IO;
using System.Threading.Tasks;
using Unicorn.Base;
using Unicorn.Writer;

namespace Unicorn.TextConvert
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args).WithParsedAsync(RunToolAsync).Wait();
        }

        private const string _defaultFontName = "Times-Roman";

        private static async Task RunToolAsync(Options options)
        {
            if (options.NoCompression)
            {
                Features.SelectedStreamFeatures &= ~Features.StreamFeatures.CompressPageContentStreams;
            }

            using CollectiveFontFinder fontFinder = new(Environment.GetFolderPath(Environment.SpecialFolder.Fonts));
            var font = fontFinder.FindFont(string.IsNullOrWhiteSpace(options.FontName) ? _defaultFontName : options.FontName, options.FontSize);
            if (font is null)
            {
                Console.Error.WriteLine($"Font {options.FontName} not found.");
                return;
            }
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
