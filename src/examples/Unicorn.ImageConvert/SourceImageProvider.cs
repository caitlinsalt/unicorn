﻿using Unicorn.Images;

namespace Unicorn.ImageConvert
{
    public class SourceImageProvider : IDisposable
    {
        private bool _disposed;

        private readonly List<BaseSourceImage> _images = new();

        private readonly string _sourcePath;
        private readonly bool _recursive;

        public SourceImageProvider(string sourcePath, bool recursive)
        {
            _sourcePath = sourcePath;
            _recursive = recursive;
        }

        public async Task<IEnumerable<BaseSourceImage>> GetImagesAsync()
        {
            if (!_images.Any())
            {
                await PopulateImagesAsync().ConfigureAwait(false);
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
                await AddImagesFromDirectory(_sourcePath).ConfigureAwait(false);
            }
            else if (File.Exists(_sourcePath))
            {
                await AddImageFromFile(_sourcePath).ConfigureAwait(false);
            }

            // Work around a CommandLineParser issue where filenames containing spaces have a spurious
            // double-quote character appened
            else if (_sourcePath.EndsWith('"') && Directory.Exists(_sourcePath.TrimEnd('"')))
            {
                await AddImagesFromDirectory(_sourcePath.TrimEnd('"')).ConfigureAwait(false);
            }
        }

        private async Task AddImagesFromDirectory(string dirPath)
        {
            foreach (string file in Directory.GetFiles(dirPath))
            {
                await AddImageFromFile(file).ConfigureAwait(false);
            }
            if (_recursive)
            {
                foreach (string dir in Directory.GetDirectories(dirPath))
                {
                    await AddImagesFromDirectory(dir).ConfigureAwait(false);
                }
            }
        }

        private async Task AddImageFromFile(string filePath)
        {
            BaseSourceImage image = ConstructSource(filePath);
            if (image != null)
            {
                using FileStream stream = new(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
                await image.LoadFromAsync(stream).ConfigureAwait(false);
                _images.Add(image);
            }
        }

        private static BaseSourceImage ConstructSource(string filePath)
        {
            string[] jpegExtensions = { ".jpg", ".jpeg", ".jpe", ".jif", ".jfif" };
            string fileExtension = Path.GetExtension(filePath);
            if (jpegExtensions.Any(e => e.Equals(fileExtension, StringComparison.OrdinalIgnoreCase)))
            {
                return new JpegSourceImage();
            }
            return null;
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
