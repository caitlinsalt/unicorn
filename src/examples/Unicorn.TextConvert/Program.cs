using CommandLine;
using System;
using System.Globalization;
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
                await Console.Error.WriteLineAsync(string.Format(CultureInfo.CurrentCulture, Resources.Program_FontNotFoundError, options.FontName)).ConfigureAwait(false);
                return;
            }
            PdfDocument document = new();
            var page = document.AppendPage();
            page.CurrentVerticalCursor = page.TopMarginPosition;
            MarginSet margins = new(0, 0, 12, 0);
            using StreamReader inputReader = new(options.In);
#pragma warning disable CA2007 // Consider calling ConfigureAwait on the awaited task
            await using StreamedParagraphProvider inputProvider = new(inputReader);
#pragma warning restore CA2007 // Consider calling ConfigureAwait on the awaited task
            int pageCount = 0;
            int paraCount = 0;
            await foreach (var para in inputProvider.GetParagraphsAsync())
            {
                Paragraph outputPara = new(page.PageAvailableWidth, page.PageAvailableHeight, Orientation.Normal, para.Alignment, 
                    VerticalAlignment.Top, margins);
                outputPara.AddText(para.Content, font, page.PageGraphics);
                var oldPage = page;
                page = page.LayOut(para as ISplittable<Paragraph>, document);
                if (page != oldPage && options.Verbose)
                {
                    await Console.Out.WriteLineAsync(string.Format(CultureInfo.CurrentCulture, Resources.Program_NewPageMessage, pageCount++, paraCount)).ConfigureAwait(false);
                }
                paraCount++;
            }
            using FileStream outputStream = new(options.Out, FileMode.Create, FileAccess.Write);
            await document.WriteAsync(outputStream).ConfigureAwait(true);
        }
    }
}
