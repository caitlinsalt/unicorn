using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Tests.Utility.Extensions;
using Unicorn.FontTools.Afm;
using Unicorn.FontTools.OpenType;
using Unicorn.FontTools.OpenType.Utility;

namespace Unicorn.FontTools.Tests.Utility
{
    /// <summary>
    /// Extension methods for <see cref="System.Random" />, for generating random examples of types from the <see cref="Unicorn.FontTools" /> namespace.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class RandomExtensions
    {
        private static readonly PlatformId[] _platformIds = new[] { PlatformId.Unicode, PlatformId.Macintosh, PlatformId.Windows, PlatformId.Custom };

#pragma warning disable CA5394 // Do not use insecure randomness

        /// <summary>
        /// Returns a random <see cref="PlatformId" /> value.
        /// </summary>
        /// <param name="random">The random generator.</param>
        /// <returns>A random <see cref="PlatformId" /> value.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the <c>random</c> parameter is <c>null</c>.</exception>
        public static PlatformId NextPlatformId(this Random random) 
            => random is null ? throw new ArgumentNullException(nameof(random)) : _platformIds[random.Next(_platformIds.Length)];

        /// <summary>
        /// Returns a random <see cref="FontProperties" /> value.
        /// </summary>
        /// <param name="random">The random generator.</param>
        /// <returns>A random <see cref="FontProperties" /> value.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the <c>random</c> parameter is <c>null</c>.</exception>
        public static FontProperties NextFontProperties(this Random random) 
            => random is null ? 
                throw new ArgumentNullException(nameof(random)) : 
                (FontProperties)(random.Next(32) | (random.NextBoolean() ? 2048 : 0) | (random.NextBoolean() ? 4096 : 0) | (random.NextBoolean() ? 8192 : 0) | 
                    (random.NextBoolean() ? 16384 : 0));

        /// <summary>
        /// Returns a random <see cref="MacStyleProperties" /> value.
        /// </summary>
        /// <param name="random">The random generator.</param>
        /// <returns>A random <see cref="MacStyleProperties" /> value.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the <c>random</c> parameter is <c>null</c>.</exception>
        public static MacStyleProperties NextMacStyleProperties(this Random random) 
            => random is null ? throw new ArgumentNullException(nameof(random)) : (MacStyleProperties)random.Next(128);

        /// <summary>
        /// Returns a random <see cref="FontDirectionHint" /> value.
        /// </summary>
        /// <param name="random">The random generator.</param>
        /// <returns>A random <see cref="FontDirectionHint" /> value.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the <c>random</c> parameter is <c>null</c>.</exception>
        public static FontDirectionHint NextFontDirectionHint(this Random random) 
            => random is null ? throw new ArgumentNullException(nameof(random)) : (FontDirectionHint)random.Next(-2, 3);

        /// <summary>
        /// Returns a random <see cref="HighByteSubheaderRecord" /> value.
        /// </summary>
        /// <param name="random">The random generator.</param>
        /// <returns>A random <see cref="HighByteSubheaderRecord" /> value.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the <c>random</c> parameter is <c>null</c>.</exception>
        public static HighByteSubheaderRecord NextHighByteSubheaderRecord(this Random random) 
            => random is null ? throw new ArgumentNullException(nameof(random)) : new HighByteSubheaderRecord(random.NextByte(), random.NextByte(), random.NextShort(), random.NextUShort());

        /// <summary>
        /// Returns a rnadom <see cref="HorizontalMetricRecord" /> value.
        /// </summary>
        /// <param name="random">The random generator.</param>
        /// <returns>A random <see cref="HorizontalMetricRecord" /> value.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the <c>random</c> parameter is <c>null</c>.</exception>
        public static HorizontalMetricRecord NextHorizontalMetricRecord(this Random random) 
            => random is null ? throw new ArgumentNullException(nameof(random)) : new HorizontalMetricRecord(random.NextUShort(), random.NextShort());
        
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

        /// <summary>
        /// Returns a random <see cref="NameField" /> value.
        /// </summary>
        /// <param name="random">The random generator.</param>
        /// <returns>A random valid <see cref="NameField" /> value.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the <c>random</c> parameter is <c>null</c>.</exception>
        public static NameField NextNameField(this Random random) 
            => random is null ? throw new ArgumentNullException(nameof(random)) : _nameFields[random.Next(_nameFields.Length)];

        /// <summary>
        /// Return a random <see cref="NameRecord" /> value.
        /// </summary>
        /// <param name="random">The random generator.</param>
        /// <returns>A random <see cref="NameRecord" /> value.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the <c>random</c> parameter is <c>null</c>.</exception>
        public static NameRecord NextNameRecord(this Random random) 
            => random is null ? 
                throw new ArgumentNullException(nameof(random)) : 
                new NameRecord(NextPlatformId(random), random.NextUShort(), random.NextUShort(), NextNameField(random), random.NextString(random.Next(128)), 
                    random.NextBoolean());

        private static readonly FontKind[] _validFontKindValues = new[] { FontKind.Cff, FontKind.TrueType };

        /// <summary>
        /// Return a random <see cref="FontKind" /> value.
        /// </summary>
        /// <param name="random">The random generator.</param>
        /// <returns>A valid random <see cref="FontKind" /> value.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the <c>random</c> parameter is <c>null</c>.</exception>
        public static FontKind NextFontKind(this Random random) 
            => random is null ? throw new ArgumentNullException(nameof(random)) : _validFontKindValues[random.Next(_validFontKindValues.Length)];

        private static readonly PostScriptTableVersion[] _validPostScriptTableVersions = new[]
        {
            PostScriptTableVersion.One,
            PostScriptTableVersion.Two,
            PostScriptTableVersion.TwoPointFive,
            PostScriptTableVersion.Three,
            PostScriptTableVersion.Four
        };

        /// <summary>
        /// Return a random <see cref="PostScriptTableVersion" /> value.
        /// </summary>
        /// <param name="random">The random generator.</param>
        /// <returns>A valid random <see cref="PostScriptTableVersion" /> value.</returns>
        public static PostScriptTableVersion NextPostScriptTableVersion(this Random random)
            => random is null ? throw new ArgumentNullException(nameof(random)) : _validPostScriptTableVersions[random.Next(_validPostScriptTableVersions.Length)];

        /// <summary>
        /// Return a random <see cref="SegmentSubheaderRecord" /> value.
        /// </summary>
        /// <param name="random">The random generator.</param>
        /// <returns>A random <see cref="SegmentSubheaderRecord" /> value.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the <c>random</c> parameter is <c>null</c>.</exception>
        public static SegmentSubheaderRecord NextSegmentSubheaderRecord(this Random random)
            => random is null ? 
                throw new ArgumentNullException(nameof(random)) : 
                new SegmentSubheaderRecord(random.NextUShort(), random.NextUShort(), random.NextShort(), random.Next());

        /// <summary>
        /// Returns a random <see cref="Tag" /> value, with a random name.
        /// </summary>
        /// <param name="random">The random generator.</param>
        /// <returns>A random <see cref="Tag" /> value.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the <c>random</c> parameter is <c>null</c>.</exception>
        public static Tag NextTag(this Random random)
            => random is null ? throw new ArgumentNullException(nameof(random)) : new Tag(Encoding.ASCII.GetBytes(random.NextString(4)));

        /// <summary>
        /// Returns a random <see cref="WidthSet" /> value.
        /// </summary>
        /// <param name="random">The random generator.</param>
        /// <returns>A random <see cref="WidthSet" /> value.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the <c>random</c> parameter is <c>null</c>.</exception>
        public static WidthSet NextAfmWidthSet(this Random random)
            => random is null ? 
                throw new ArgumentNullException(nameof(random)) : 
                new WidthSet(random.NextNullableDecimal(), random.NextNullableDecimal(), random.NextNullableDecimal());

        /// <summary>
        /// Returns a random <see cref="Vector" /> value.
        /// </summary>
        /// <param name="random">The random generator.</param>
        /// <returns>A random <see cref="Vector" /> value.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the <c>random</c> parameter is <c>null</c>.</exception>
        public static Vector NextAfmVector(this Random random) 
            => random is null ? throw new ArgumentNullException(nameof(random)) : new Vector(random.NextDecimal(), random.NextDecimal());

        /// <summary>
        /// Returns a random <see cref="Vector" />, or <c>null</c>.
        /// </summary>
        /// <param name="random">The random generator.</param>
        /// <returns>A random <see cref="Vector" /> value, or <c>null</c> approximately 1 time in 10.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the <c>random</c> parameter is <c>null</c>.</exception>
        public static Vector? NextNullableAfmVector(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            if (random.Next(10) == 0)
            {
                return null;
            }
            return NextAfmVector(random);
        }

        /// <summary>
        /// Returns a random <see cref="BoundingBox" /> value.
        /// </summary>
        /// <param name="random">The random generator.</param>
        /// <returns>A random <see cref="BoundingBox" /> value.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the <c>random</c> parameter is <c>null</c>.</exception>
        public static BoundingBox NextAfmBoundingBox(this Random random)
            => random is null ? 
                throw new ArgumentNullException(nameof(random)) : 
                new BoundingBox(random.NextDecimal(), random.NextDecimal(), random.NextDecimal(), random.NextDecimal());
        
        /// <summary>
        /// Returns a random <see cref="BoundingBox" />, or <c>null</c>.
        /// </summary>
        /// <param name="random">The random generator.</param>
        /// <returns>A random <see cref="BoundingBox" /> value, or <c>null</c> about 1 time in 10.</returns>
        public static BoundingBox? NextNullableAfmBoundingBox(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            if (random.Next(10) == 0)
            {
                return null;
            }
            return NextAfmBoundingBox(random);
        }

        /// <summary>
        /// Returns a random <see cref="Character" /> that (optionally) is not already present in a list of existing character names.  The list of existing character
        /// names is also used to generate random ligatures.
        /// </summary>
        /// <param name="random">The random generator.</param>
        /// <param name="existingCharacters">A list of existing character names.  This routine will not reproduce any character names in this list.</param>
        /// <returns>A randomly-generated <see cref="Character" /> value.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the <c>random</c> parameter is <c>null</c>.</exception>
        public static Character NextAfmCharacter(this Random random, IList<string> existingCharacters = null)
            => NextAfmCharacter(random, random.NextNullableShort(), existingCharacters);

        /// <summary>
        /// Returns a <see cref="Character" /> with a given name, whose data is otherwise random.
        /// </summary>
        /// <param name="random">The random generator.</param>
        /// <param name="name">The name of the new character to generate.</param>
        /// <param name="existingCharacters">A set of existing character names, to generate random valid ligature data for the new character.</param>
        /// <returns>A <see cref="Character" /> value with the given name.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the <c>random</c> parameter is <c>null</c>.</exception>
        public static Character NextAfmCharacter(this Random random, string name, IList<string> existingCharacters = null)
            => NextAfmCharacter(random, name, random.NextNullableShort(), existingCharacters);

        /// <summary>
        /// Returns a <see cref="Character" /> with the given codepoint, whose data is otherwise random.  The character's name will not duplicate any present in the 
        /// set of existing character names (if provided).
        /// </summary>
        /// <param name="random">The random generator.</param>
        /// <param name="code">The codepoint of the new character.</param>
        /// <param name="existingCharacters">A set of existing character names, which the new character will not duplicate, and which is used to generate
        /// random valid ligature data for the new character.</param>
        /// <returns>A randomly-generated <see cref="Character" /> value for the given codepoint.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the <c>random</c> parameter is <c>null</c>.</exception>
        public static Character NextAfmCharacter(this Random random, short? code, IList<string> existingCharacters = null)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            if (existingCharacters is null)
            {
                existingCharacters = Array.Empty<string>();
            }
            string name;
            if (random.Next(10) == 0)
            {
                name = null;
            }
            else
            {
                do
                {
                    name = random.NextString(random.Next(1, 16));
                } while (existingCharacters.Contains(name));
            }
            return NextAfmCharacter(random, name, code, existingCharacters);
        }

        /// <summary>
        /// Generate a <see cref="Character" /> value that has the given name and codepoint but whose data is otherwise random.
        /// </summary>
        /// <param name="random">The random generator.</param>
        /// <param name="name">The character name.</param>
        /// <param name="code">The character's codepoint.</param>
        /// <param name="existingCharacters">A set of existing character names, used to generate valid random ligature data for the new character.</param>
        /// <returns>A partially-random <see cref="Character" /> with the given name and codepoint.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the <c>random</c> parameter is <c>null</c>.</exception>
        public static Character NextAfmCharacter(this Random random, string name, short? code, IList<string> existingCharacters = null)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            if (existingCharacters is null)
            {
                existingCharacters = Array.Empty<string>();
            }
            int ligCount = random.Next(3);
            InitialLigatureSet[] ligatures = new InitialLigatureSet[ligCount];
            for (int i = 0; i < ligCount; ++i)
            {
                if (existingCharacters.Count == 0)
                {
                    ligatures[i] = new InitialLigatureSet(random.NextString(random.Next(1, 16)), random.NextString(random.Next(1, 16)));
                }
                else
                {
                    ligatures[i] = new InitialLigatureSet(existingCharacters[random.Next(existingCharacters.Count)],
                        existingCharacters[random.Next(existingCharacters.Count)]);
                }
            }
            return new Character(code, name, random.NextAfmWidthSet(), random.NextAfmWidthSet(), random.NextNullableAfmVector(),
                random.NextNullableAfmBoundingBox(), ligatures);
        }

        /// <summary>
        /// Generate a random <see cref="LigatureSet" /> of three <see cref="Character" /> values.
        /// </summary>
        /// <param name="random">The random generator.</param>
        /// <param name="doNotUseAsSecondCharacterName">If non null or empty, the name of the second character in the ligature set will not conflict with any
        /// of the entries in this list.</param>
        /// <returns>A random <see cref="LigatureSet" /> of three newly-generated random <see cref="Character" /> values.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the <c>random</c> parameter is <c>null</c>.</exception>
        public static LigatureSet NextAfmLigatureSet(this Random random, IList<string> doNotUseAsSecondCharacterName)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            if (doNotUseAsSecondCharacterName is null)
            {
                doNotUseAsSecondCharacterName = Array.Empty<string>();
            }
            string secondName;
            do
            {
                secondName = random.NextString(random.Next(1, 20));
            } while (doNotUseAsSecondCharacterName.Contains(secondName));

            return new LigatureSet(NextAfmCharacter(random, random.NextString(random.Next(1, 16))), NextAfmCharacter(random, secondName),
                NextAfmCharacter(random, random.NextString(random.Next(1, 16))));
        }

        /// <summary>
        /// Generate a random <see cref="KerningPair" /> value, consisting of two <see cref="Character" /> values and a kerning <see cref="Vector" />.
        /// </summary>
        /// <param name="random">The random generator.</param>
        /// <param name="doNotUseAsSecondCharacterName">If this list is not null or empty, the name of the second character of the kerning pair will not
        /// conflict with any entry in this list.</param>
        /// <returns>A <see cref="KerningPair" /> consisting of two randomly-generated <see cref="Character" /> values and a random <see cref="Vector" />.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the <c>random</c> parameter is <c>null</c>.</exception>
        public static KerningPair NextAfmKerningPair(this Random random, IList<string> doNotUseAsSecondCharacterName)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            if (doNotUseAsSecondCharacterName is null)
            {
                doNotUseAsSecondCharacterName = Array.Empty<string>();
            }
            string secondName;
            do
            {
                secondName = random.NextString(random.Next(1, 20));
            } while (doNotUseAsSecondCharacterName.Contains(secondName));

            return new KerningPair(NextAfmCharacter(random, random.NextString(random.Next(1, 16))), NextAfmCharacter(random, secondName), NextAfmVector(random));
        }

        /// <summary>
        /// Generate a random <see cref="DirectionMetrics" /> value.
        /// </summary>
        /// <param name="random">The random generator.</param>
        /// <returns>A randomly-generated <see cref="DirectionMetrics" /> value.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the <c>random</c> parameter is <c>null</c>.</exception>
        public static DirectionMetrics NextAfmDirectionMetrics(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            bool? fixedPitch = random.NextNullableBoolean();
            Vector? width = null;
            if (!fixedPitch.HasValue || fixedPitch.Value)
            {
                width = NextNullableAfmVector(random);
            }
            return new DirectionMetrics(random.NextNullableDecimal(), random.NextNullableDecimal(), random.NextNullableDecimal(), width, fixedPitch);
        }

        /// <summary>
        /// Generate a random <see cref="DirectionMetrics" /> value, or <c>null</c>.
        /// </summary>
        /// <param name="random">The random generator.</param>
        /// <returns>A randomly-generated <see cref="DirectionMetrics" /> value, or <c>null</c> approximately one time in ten.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the <c>random</c> parameter is <c>null</c>.</exception>
        public static DirectionMetrics? NextNullableAfmDirectionMetrics(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            if (random.Next(10) == 0)
            {
                return null;
            }
            return NextAfmDirectionMetrics(random);
        }

        private static readonly EmbeddingPermissions[] _exclusiveEmbeddingPermissionsFlags = new[]
        {
            EmbeddingPermissions.Installable,
            EmbeddingPermissions.Restricted,
            EmbeddingPermissions.Printing,
            EmbeddingPermissions.Editable,
        };

        /// <summary>
        /// Generate a random <see cref="EmbeddingPermissions" /> value.
        /// </summary>
        /// <param name="random">The random generator.</param>
        /// <returns>A randomly-generated <see cref="EmbeddingPermissions" /> value.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the <c>random</c> parameter is <c>null</c>.</exception>
        public static EmbeddingPermissions NextOpenTypeEmbeddingPermissionsFlags(this Random random)
            => random is null ? 
                throw new ArgumentNullException(nameof(random)) : 
                _exclusiveEmbeddingPermissionsFlags[random.Next(_exclusiveEmbeddingPermissionsFlags.Length)] | 
                    (random.NextBoolean() ? EmbeddingPermissions.BitmapOnly : 0) | (random.NextBoolean() ? EmbeddingPermissions.NoSubsetting : 0);
        

        private static readonly IBMFamily[] _validIBMFamilyValues = new[]
        {
            IBMFamily.None,
            IBMFamily.OldstyleSerif_None,
            IBMFamily.OldstyleSerif_IBMRoundedLegibility,
            IBMFamily.OldstyleSerif_Garalde,
            IBMFamily.OldstyleSerif_Venetian,
            IBMFamily.OldstyleSerif_ModifiedVenetian,
            IBMFamily.OldstyleSerif_DutchTraditional,
            IBMFamily.OldstyleSerif_DutchModern,
            IBMFamily.OldstyleSerif_Contemporary,
            IBMFamily.OldstyleSerif_Calligraphic,
            IBMFamily.OldstyleSerif_Miscellaneous,
            IBMFamily.TransitionalSerif_None,
            IBMFamily.TransitionalSerif_DirectLine,
            IBMFamily.TransitionalSerif_Script,
            IBMFamily.TransitionalSerif_Miscellaneous,
            IBMFamily.ModernSerif_None,
            IBMFamily.ModernSerif_Italian,
            IBMFamily.ModernSerif_Script,
            IBMFamily.ModernSerif_Miscellaneous,
            IBMFamily.ClarendonSerif_None,
            IBMFamily.ClarendonSerif_Clarendon,
            IBMFamily.ClarendonSerif_Modern,
            IBMFamily.ClarendonSerif_Traditional,
            IBMFamily.ClarendonSerif_Newspaper,
            IBMFamily.ClarendonSerif_StubSerif,
            IBMFamily.ClarendonSerif_Monotone,
            IBMFamily.ClarendonSerif_Typewriter,
            IBMFamily.ClarendonSerif_Miscellaneous,
            IBMFamily.SlabSerif_None,
            IBMFamily.SlabSerif_Monotone,
            IBMFamily.SlabSerif_Humanist,
            IBMFamily.SlabSerif_Geometric,
            IBMFamily.SlabSerif_Swiss,
            IBMFamily.SlabSerif_Typewriter,
            IBMFamily.SlabSerif_Miscellaneous,
            IBMFamily.FreeformSerif_None,
            IBMFamily.FreeformSerif_Modern,
            IBMFamily.FreeformSerif_Miscellaneous,
            IBMFamily.SansSerif_None,
            IBMFamily.SansSerif_IBMNeoGrotesqueGothic,
            IBMFamily.SansSerif_Humanist,
            IBMFamily.SansSerif_LowXRoundGeometric,
            IBMFamily.SansSerif_HighXRoundGeometric,
            IBMFamily.SansSerif_NeoGrotesqueGothic,
            IBMFamily.SansSerif_ModifiedNeoGrotesqueGothic,
            IBMFamily.SansSerif_TypewriterGothic,
            IBMFamily.SansSerif_Matrix,
            IBMFamily.SansSerif_Miscellaneous,
            IBMFamily.Ornamentals_None,
            IBMFamily.Ornamentals_Engraver,
            IBMFamily.Ornamentals_BlackLetter,
            IBMFamily.Ornamentals_Decorative,
            IBMFamily.Ornamentals_ThreeDimensional,
            IBMFamily.Ornamentals_Miscellaneous,
            IBMFamily.Scripts_None,
            IBMFamily.Scripts_Uncials,
            IBMFamily.Scripts_BrushJoined,
            IBMFamily.Scripts_FormalJoined,
            IBMFamily.Scripts_MonotoneJoined,
            IBMFamily.Scripts_Calligraphic,
            IBMFamily.Scripts_BrushUnjoined,
            IBMFamily.Scripts_FormalUnjoined,
            IBMFamily.Scripts_MonotoneUnjoined,
            IBMFamily.Scripts_Miscellaneous,
            IBMFamily.Symbolic_None,
            IBMFamily.Symbolic_MixedSerif,
            IBMFamily.Symbolic_OldStyleSerif,
            IBMFamily.Symbolic_NeoGrotesqueSansSerif,
            IBMFamily.Symbolic_Miscellaneous,
        };

        /// <summary>
        /// Generate a random <see cref="IBMFamily" /> value.
        /// </summary>
        /// <param name="random">The random generator.</param>
        /// <returns>A randomly-generated <see cref="IBMFamily" /> value.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the <c>random</c> parameter is <c>null</c>.</exception>
        public static IBMFamily NextOpenTypeIBMFamily(this Random random)
            => random is null ? throw new ArgumentNullException(nameof(random)) : _validIBMFamilyValues[random.Next(_validIBMFamilyValues.Length)];

        /// <summary>
        /// Generate a random <see cref="PanoseFamily" /> value.
        /// </summary>
        /// <param name="random">The random generator.</param>
        /// <returns>A randomly-generated <see cref="PanoseFamily" /> value.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the <c>random</c> parameter is <c>null</c>.</exception>
        public static PanoseFamily NextOpenTypePanoseFamily(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            byte[] data = new byte[10];
            random.NextBytes(data);
            return new PanoseFamily(data, 0);
        }

        /// <summary>
        /// Generate a random <see cref="OS2StyleProperties" /> value.
        /// </summary>
        /// <param name="random">The random generator.</param>
        /// <returns>A randomly-generated <see cref="OS2StyleProperties" /> value.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the <c>random</c> parameter is <c>null</c>.</exception>
        public static OS2StyleProperties NextOpenTypeOS2StyleProperties(this Random random)
            => random is null ? throw new ArgumentNullException(nameof(random)) : (OS2StyleProperties)random.Next(1024);

        /// <summary>
        /// Generate a random <see cref="CalculationStyle" /> value.
        /// </summary>
        /// <param name="random">The random generator.</param>
        /// <returns>A randomly-generated <see cref="CalculationStyle" /> value.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the <c>random</c> parameter is <c>null</c>.</exception>
        public static CalculationStyle NextOpenTypeCalculationStyle(this Random random) => random.NextBoolean() ? CalculationStyle.Windows : CalculationStyle.Macintosh;
        
        /// <summary>
        /// Generate a random <see cref="UnicodeRanges" /> instance.
        /// </summary>
        /// <param name="random">The random generator.</param>
        /// <returns>A randomly-generated <see cref="UnicodeRanges" /> instance.</returns>
        public static UnicodeRanges NextOpenTypeUnicodeRanges(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            byte[] data = new byte[16];
            random.NextBytes(data);
            return UnicodeRanges.FromBytes(data, 0);
        }

        /// <summary>
        /// Generate a random <see cref="SupportedCodePages" /> instance.
        /// </summary>
        /// <param name="random">The random generator.</param>
        /// <returns>A randomly-generated <see cref="SupportedCodePages" /> instance.</returns>
        /// <exception cref="ArgumentNullException">Thrown if the <c>random</c> parameter is <c>null</c>.</exception>
        public static SupportedCodePages NextOpenTypeSupportedCodePages(this Random random)
        {
            if (random is null)
            {
                throw new ArgumentNullException(nameof(random));
            }
            byte[] data = new byte[8];
            random.NextBytes(data);
            return SupportedCodePages.FromBytes(data, 0);
        }

        private static readonly DumpAlignment[] _validDumpAlignments = new[] { DumpAlignment.Left, DumpAlignment.Right };

        /// <summary>
        /// Generate a random <see cref="DumpAlignment" /> value.
        /// </summary>
        /// <param name="random">Random generator.</param>
        /// <returns>A randomly-selected valid <see cref="DumpAlignment" /> value.</returns>
        /// <exception cref="ArgumentNullException"><c>random</c> is <c>null</c>.</exception>
        public static DumpAlignment NextDumpAlignment(this Random random)
            => random is null ? throw new ArgumentNullException(nameof(random)) : _validDumpAlignments[random.Next(_validDumpAlignments.Length)];

        /// <summary>
        /// Generate a random <see cref="DumpColumn" /> instance.
        /// </summary>
        /// <param name="random">Random generator.</param>
        /// <returns>A <see cref="DumpColumn" /> instance with randomly-generated properties.</returns>
        /// <exception cref="ArgumentNullException"><c>random</c> is <c>null</c>.</exception>
        public static DumpColumn NextDumpColumn(this Random random)
            => random is null ? throw new ArgumentNullException(nameof(random)) : new DumpColumn(random.NextString(random.Next(1, 20)), random.NextDumpAlignment());

        /// <summary>
        /// Generate a random <see cref="SequentialMapGroupRecord" /> value.
        /// </summary>
        /// <param name="random">Random generator.</param>
        /// <returns>A randomly-generated <see cref="SequentialMapGroupRecord" /> value.</returns>
        /// <exception cref="ArgumentNullException"><c>random</c> is <c>null</c>.</exception>
        public static SequentialMapGroupRecord NextOpenTypeSequentialMapGroupRecord(this Random random)
            => random is null ? throw new ArgumentNullException(nameof(random)) : new SequentialMapGroupRecord(random.NextUInt(), random.NextUInt(), random.NextUShort());

#pragma warning restore CA5394 // Do not use insecure randomness

    }
}
