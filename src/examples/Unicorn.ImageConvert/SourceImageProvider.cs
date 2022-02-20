using Unicorn.Images;

namespace Unicorn.ImageConvert
{
    public class SourceImageProvider : IDisposable
    {
        private bool _disposed;

        private readonly List<BaseSourceImage> _images = new();

        private readonly string _sourcePath;

        public SourceImageProvider(string sourcePath)
        {
            _sourcePath = sourcePath;
        }

        public async Task<IEnumerable<BaseSourceImage>> GetImagesAsync()
        {
            if (!_images.Any())
            {
                await PopulateImagesAsync();
            }
            return _images.ToArray();
        }

        private async Task PopulateImagesAsync()
        {
            if (string.IsNullOrWhiteSpace(_sourcePath))
            {
                return;
            }
            if (Directory.Exists(_sourcePath))
            {
                foreach (string file in Directory.GetFiles(_sourcePath))
                {
                    await AddImageFromFile(file);
                }
            }
            else if (File.Exists(_sourcePath))
            {
                await AddImageFromFile(_sourcePath);
            }
        }

        private async Task AddImageFromFile(string filePath)
        {
            JpegSourceImage image = new();
            using FileStream stream = new(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            await image.LoadFromAsync(stream);
            _images.Add(image);
        }

        #region Dispose pattern

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    foreach (BaseSourceImage image in _images)
                    {
                        image.Dispose();
                    }
                    _images.Clear();
                }

                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion

    }
}
