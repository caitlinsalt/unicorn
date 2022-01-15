using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Unicorn.Base;

namespace Unicorn.TextConvert
{
    public class StreamedParagraphProvider : ISourceParagraphProvider, IAsyncDisposable, IDisposable
    {
        private StreamReader _reader;
        private bool _disposed;

        public StreamedParagraphProvider(StreamReader reader)
        {
            _reader = reader;
        }

        public async IAsyncEnumerable<SourceParagraph> GetParagraphsAsync()
        {
            StringBuilder builder = null;
            string line;
            bool buildingPara = false;
            bool centredPara = false;
            while ((line = await _reader.ReadLineAsync().ConfigureAwait(false)) != null)
            {
                if (buildingPara)
                {
                    if (line.Length == 0)
                    {
                        yield return new SourceParagraph(GetAlignment(centredPara), builder.ToString());
                        buildingPara = false;
                    }
                    else
                    {
                        builder.Append(' ');
                        builder.Append(line.Trim());
                        centredPara &= line.StartsWith(' ');
                    }
                }
                else
                {
                    if (line.Length > 0)
                    {
                        builder = new(line.Trim());
                        buildingPara = true;
                        centredPara = line.StartsWith(' ');
                    }
                }
            }
            if (buildingPara && builder.Length > 0)
            {
                yield return new SourceParagraph(GetAlignment(centredPara), builder.ToString());
            }
        }

        private static HorizontalAlignment GetAlignment(bool isCentred) => isCentred ? HorizontalAlignment.Centred : HorizontalAlignment.Justified;

        #region Async dispose pattern implementation

        public async ValueTask DisposeAsync()
        {
            await DisposeAsyncCore().ConfigureAwait(false);
            Dispose(false);
#pragma warning disable CA1816 // Dispose methods should call SuppressFinalize
            GC.SuppressFinalize(this);
#pragma warning restore CA1816 // Dispose methods should call SuppressFinalize
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        protected virtual async ValueTask DisposeAsyncCore()
        {
            _reader?.Dispose();
            _reader = null;
        }
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _reader?.Dispose();
                    _reader = null;
                }

                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}
