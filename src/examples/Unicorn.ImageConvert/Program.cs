using CommandLine;
using Unicorn.Base;
using Unicorn.Images;
using Unicorn.Writer;

namespace Unicorn.ImageConvert
{
    class Program
    {
        static void Main(string [] args)
        {
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
            if (!options.Wireframe)
            {
                await Console.Error.WriteLineAsync(Resources.Program_WireframeOnlyError).ConfigureAwait(false);
                return;
            }
            using SourceImageProviderCollection providers = new();
            foreach (string path in options.InputFiles)
            {
                providers.Add(new SourceImageProvider(path, options.Recursive));
            }
            PdfDocument document = new();
            IPageDescriptor currentPage = document.AppendPage();
            MarginSet margins = new(0, 0, 36, 0);
            foreach (SourceImageProvider provider in providers)
            {
                IEnumerable<BaseSourceImage> images = await provider.GetImagesAsync().ConfigureAwait(false);
                foreach (BaseSourceImage sourceImage in images)
                {
                    ImageWireframe wf = new(currentPage.PageAvailableWidth, currentPage.PageAvailableWidth / sourceImage.AspectRatio, margins);
                    if (currentPage.PageAvailableHeight > wf.Height)
                    {
                        currentPage.LayOut(wf);
                    }
                    else
                    {
                        currentPage = document.AppendPage();
                        if (currentPage.PageAvailableHeight > wf.Height)
                        {
                            currentPage.LayOut(wf);
                        }
                        else
                        {
                            currentPage.LayOut(new ImageWireframe(currentPage.PageAvailableWidth, currentPage.PageAvailableWidth * sourceImage.AspectRatio, margins));
                        }
                    }
                }
            }

            using FileStream outputStream = new(options.Out, FileMode.Create, FileAccess.Write);
            await document.WriteAsync(outputStream).ConfigureAwait(true);
        }
    }
}