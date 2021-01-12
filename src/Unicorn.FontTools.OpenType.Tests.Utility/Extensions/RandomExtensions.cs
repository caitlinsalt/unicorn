using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Tests.Utility.Extensions;

namespace Unicorn.FontTools.OpenType.Tests.Utility.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class RandomExtensions
    {
        private static readonly PlatformId[] _platformIds = new[] { PlatformId.Unicode, PlatformId.Macintosh, PlatformId.Windows, PlatformId.Custom };

#pragma warning disable CA5394 // Do not use insecure randomness

        public static PlatformId NextPlatformId(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            return _platformIds[random.Next(_platformIds.Length)];
        }

        public static FontProperties NextFontFlags(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            return (FontProperties)(random.Next(32) | (random.NextBoolean() ? 2048 : 0) | (random.NextBoolean() ? 4096 : 0) | (random.NextBoolean() ? 8192 : 0) |
                (random.NextBoolean() ? 16384 : 0));
        }

        public static MacStyleProperties NextMacStyleFlags(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            return (MacStyleProperties)random.Next(128);
        }

        public static FontDirectionHint NextFontDirectionHint(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            return (FontDirectionHint)random.Next(-2, 3);
        }

        public static HighByteSubheaderRecord NextHighByteSubheaderRecord(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            return new HighByteSubheaderRecord(random.NextByte(), random.NextByte(), random.NextShort(), random.NextUShort());
        }

        public static HorizontalMetricRecord NextHorizontalMetricRecord(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            return new HorizontalMetricRecord(random.NextUShort(), random.NextShort());
        }

        private static readonly NameField[] _nameFields = new[]
        {
            NameField.CopyrightNotice,
            NameField.Family,
            NameField.Subfamily,
            NameField.UniqueID,
            NameField.FullName,
            NameField.Version,
            NameField.PostScriptName,
            NameField.TrademarkNotice,
            NameField.Manufacturer,
            NameField.Description,
            NameField.Description,
            NameField.VendorURI,
            NameField.DesignerURI,
            NameField.LicenceDescription,
            NameField.LicenceURI,
            NameField.TypographicFamily,
            NameField.TypographicSubfamily,
            NameField.MacintoshMenuName,
            NameField.SampleText,
            NameField.PostScriptCIDName,
            NameField.WWSFamilyName,
            NameField.WWSSubfamilyName,
            NameField.LightBackgroundPalette,
            NameField.DarkBackgroundPalette,
            NameField.PostScriptFamilyPrefix,
        };

        public static NameField NextNameField(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            return _nameFields[random.Next(_nameFields.Length)];
        }

        public static NameRecord NextNameRecord(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            return new NameRecord(NextPlatformId(random), random.NextUShort(), random.NextUShort(), NextNameField(random), random.NextString(random.Next(128)),
                random.NextBoolean());
        }

        private static readonly FontKind[] _validFontKindValues = new[] { FontKind.Cff, FontKind.TrueType };

        public static FontKind NextFontKind(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            return _validFontKindValues[random.Next(_validFontKindValues.Length)];
        }

        private static readonly PostScriptTableVersion[] _validPostScriptTableVersions = new[]
        {
            PostScriptTableVersion.One,
            PostScriptTableVersion.Two,
            PostScriptTableVersion.TwoPointFive,
            PostScriptTableVersion.Three,
            PostScriptTableVersion.Four
        };

        public static PostScriptTableVersion NextPostScriptTableVersion(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            return _validPostScriptTableVersions[random.Next(_validPostScriptTableVersions.Length)];
        }

        public static SegmentSubheaderRecord NextSegmentSubheaderRecord(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            return new SegmentSubheaderRecord(random.NextUShort(), random.NextUShort(), random.NextShort(), random.Next());
        }

        public static Tag NextTag(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            return new Tag(Encoding.ASCII.GetBytes(random.NextString(4)));
        }

#pragma warning restore CA5394 // Do not use insecure randomness

    }
}
