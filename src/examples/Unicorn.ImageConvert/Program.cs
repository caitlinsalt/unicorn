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
                Console.Error.WriteLine(Resources.Program_OutputNameNotSpecifiedError);
            }
            if (!options.Wireframe)
            {
                Console.Error.WriteLine(Resources.Program_WireframeOnlyError);
                return;
            }
            using SourceImageProviderCollection providers = new();
            foreach (string path in options.InputFiles)
            {
                providers.Add(new SourceImageProvider(path));
            }
            PdfDocument document = new();
            IPageDescriptor currentPage = document.AppendPage();
            foreach (SourceImageProvider provider in providers)
            {
                IEnumerable<BaseSourceImage> images = await provider.GetImagesAsync();
                foreach (BaseSourceImage sourceImage in images)
                {
                    ImageWireframe wf = new ImageWireframe(currentPage.PageAvailableWidth, currentPage.PageAvailableWidth / sourceImage.AspectRatio);
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
                            currentPage.LayOut(new ImageWireframe(currentPage.PageAvailableWidth, currentPage.PageAvailableWidth * sourceImage.AspectRatio));
                        }
                    }
                }
            }

            using FileStream outputStream = new(options.Out, FileMode.Create, FileAccess.Write);
            await document.WriteAsync(outputStream).ConfigureAwait(true);
        }
    }
}