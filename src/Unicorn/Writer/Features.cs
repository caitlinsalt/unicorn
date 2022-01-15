using System;

namespace Unicorn.Writer
{
    /// <summary>
    /// PDf-writing feature toggles.
    /// </summary>
    public static class Features
    {
        /// <summary>
        /// Possible feature settings for writing PDF streams.
        /// </summary>
        [Flags]
        public enum StreamFeatures
        {
            /// <summary>
            /// ASCII-encode uncompressed binary streams usiing the <c>/ASCII85Decode</c> filter.  This can produce files that do not render correctly on legacy 
            /// versions of Microsoft Edge that use the EdgeHTML rendering engine, as it does not appear to recognise TrueType fonts encoded solely with this filter.
            /// "Binary streams" consist of any streams that are embedded binary data (such as embedded fonts and images), or any streams that have been compressed.
            /// </summary>
            AsciiEncodeBinaryStreams = 1,

            /// <summary>
            /// Compress binary streams (such as embedded fonts and images) using the <c>/FlateDecode</c> filter.  If both this flag and 
            /// <see cref="AsciiEncodeBinaryStreams"/> are set, the stream will be compressed before encoding.
            /// </summary>
            CompressBinaryStreams = 2,

            /// <summary>
            /// Compress page content streams using the <c>/FlateDecode</c> filter.  If both this flag and <see cref="AsciiEncodeBinaryStreams" /> are set, the stream
            /// will be compressed and then encoded.
            /// </summary>
            CompressPageContentStreams = 4,
        }

        /// <summary>
        /// Feature toggles for writing PDF streams.
        /// </summary>
        public static StreamFeatures SelectedStreamFeatures { get; set; } = 
            StreamFeatures.AsciiEncodeBinaryStreams | StreamFeatures.CompressBinaryStreams | StreamFeatures.CompressPageContentStreams;
    }
}
