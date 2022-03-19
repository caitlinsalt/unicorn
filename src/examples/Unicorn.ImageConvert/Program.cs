using CommandLine;
using Unicorn.Base;
using Unicorn.Images;
using Unicorn.Writer;
using Unicorn.Writer.Interfaces;

namespace Unicorn.ImageConvert
{
    class Program
    {
        static void Main(string [] args)
        {
            Features.SelectedStreamFeatures &= ~Features.StreamFeatures.CompressPageContentStreams;
            Features.SelectedStreamFeatures &= ~Features.StreamFeatures.CompressBinaryStreams;
            Parser.Default.ParseArguments<Options>(args).WithParsedAsync(RunToolAsync).Wait();
        }

        private static async Task RunToolAsync(Options options)
        {
            if (options.InputFiles is null)
            {
                return;
            }
            if (options.Out is null)
            {
                await Console.Error.WriteLineAsync(Resources.Program_OutputNameNotSpecifiedError).ConfigureAwait(false);
            }
            using SourceImageProviderCollection providers = new();
            foreach (string path in options.InputFiles)
            {
                providers.Add(new SourceImageProvider(path, options.Recursive));
            }
            PdfDocument document = new();
            List<IPdfReference> imageReferences = new();
            if (!options.Wireframe)
            {
                imageReferences.Add(document.UseImage(new SingleColourSourceImage(new RgbColour(0.3569, 0.8078, 0.9804))));
                imageReferences.Add(document.UseImage(new SingleColourSourceImage(new RgbColour(0.9608, 0.6627, 0.7216))));
            }
            PrimitiveFactory factory = new PrimitiveFactory(options.Wireframe, imageReferences);
            IPageDescriptor currentPage = document.AppendPage();
            MarginSet margins = new(0, 0, 36, 0);
            foreach (SourceImageProvider provider in providers)
            {
                IEnumerable<BaseSourceImage> images = await provider.GetImagesAsync().ConfigureAwait(false);
                foreach (BaseSourceImage sourceImage in images)
                {
                    var wf = factory.CreatePrimitive(currentPage.PageAvailableWidth, currentPage.PageAvailableWidth / sourceImage.AspectRatio, margins);
                    if (currentPage.PageAvailableHeight > wf.Height)
                    {
                        factory.LayOutOnPage(currentPage, wf);
                    }
                    else
                    {
                        currentPage = document.AppendPage();
                        factory.LayOutOnPage(currentPage, wf);
                    }
                }
            }

            using FileStream outputStream = new(options.Out, FileMode.Create, FileAccess.Write);
            await document.WriteAsync(outputStream).ConfigureAwait(true);
        }
    }
}