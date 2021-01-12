using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using Tests.Utility.Extensions;
using Tests.Utility.Providers;
using Unicorn.FontTools.OpenType.Tests.Utility.Extensions;

namespace Unicorn.FontTools.OpenType.Tests.Unit
{
    [TestClass]
    public class PostScriptTableUnitTests
    {
        private static readonly Random _rnd = RandomProvider.Default;

#pragma warning disable CA5394 // Do not use insecure randomness

        private static PostScriptTableVersion GetTableVersionNumberForOverrideMapping()
        {
            return _rnd.NextBoolean() ? PostScriptTableVersion.Two : PostScriptTableVersion.TwoPointFive;
        }

        private static PostScriptTableVersion GetTableVersionNumberForStandardMapping()
        {
            PostScriptTableVersion[] versions = new[] { PostScriptTableVersion.One, PostScriptTableVersion.Three, PostScriptTableVersion.Four };
            return versions[_rnd.Next(versions.Length)];
        }

        private static PostScriptTable GetTestObject(IEnumerable<KeyValuePair<string, int>> mapping)
        {
            return new PostScriptTable(GetTableVersionNumberForOverrideMapping(), _rnd.NextDecimal() * 360, _rnd.NextShort(), _rnd.NextShort(), _rnd.NextBoolean(),
                _rnd.NextUInt(), _rnd.NextUInt(), _rnd.NextUInt(), _rnd.NextUInt(), mapping);
        }

        private static PostScriptTable GetTestObject()
        {
            return new PostScriptTable(GetTableVersionNumberForStandardMapping(), _rnd.NextDecimal() * 360, _rnd.NextShort(), _rnd.NextShort(), _rnd.NextBoolean(),
                _rnd.NextUInt(), _rnd.NextUInt(), _rnd.NextUInt(), _rnd.NextUInt());
        }

        private static List<KeyValuePair<string, int>> GetTestCharacterMap()
        {
            int count = _rnd.Next(256);
            List<KeyValuePair<string, int>> testData = new List<KeyValuePair<string, int>>(count);
            for (int i = 0; i < count; ++i)
            {
                string key;
                do
                {
                    key = _rnd.NextString(_rnd.Next(1, 24));
                } while (testData.Any(p => p.Key == key));
                testData.Add(new KeyValuePair<string, int>(key, _rnd.Next(ushort.MaxValue)));
            }
            return testData;
        }

        private static readonly string[] _standardCharacterMap = new[]
        {
            ".notdef",
            ".null",
            "nonmarkingreturn",
            "space",
            "exclam",
            "quotedbl",
            "numbersign",
            "dollar",
            "percent",
            "ampersand",
            "quotesingle",
            "parenleft",
            "parenright",
            "asterisk",
            "plus",
            "comma",
            "hyphen",
            "period",
            "slash",
            "zero", "one", "two", "three", "four", "five", "six", "seven", "eight",  "nine",
            "colon",
            "semicolon",
            "less",
            "equal",
            "greater",
            "question",
            "at",
            "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z",
            "bracketleft",
            "backslash",
            "bracketright",
            "asciicircum",
            "underscore",
            "grave",
            "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z",
            "braceleft",
            "bar",
            "braceright",
            "asciitilde",
            "Adieresis",
            "Aring",
            "Ccedilla",
            "Eacute",
            "Ntilde",
            "Odieresis",
            "Udieresis",
            "aacute",
            "agrave",
            "acircumflex",
            "adieresis",
            "atilde",
            "aring",
            "ccedilla",
            "eacute",
            "egrave",
            "ecircumflex",
            "edieresis",
            "iacute",
            "igrave",
            "icircumflex",
            "idieresis",
            "ntilde",
            "oacute",
            "ograve",
            "ocircumflex",
            "odieresis",
            "otilde",
            "uacute",
            "ugrave",
            "ucircumflex",
            "udieresis",
            "dagger",
            "degree",
            "cent",
            "sterling",
            "section",
            "bullet",
            "paragraph",
            "germandbls",
            "registered",
            "copyright",
            "trademark",
            "acute",
            "dieresis",
            "notequal",
            "AE",
            "Oslash",
            "infinity",
            "plusminus",
            "lessequal",
            "greaterequal",
            "yen",
            "mu",
            "partialdiff",
            "summation",
            "product",
            "pi",
            "integral",
            "ordfeminine",
            "ordmasculine",
            "Omega",
            "ae",
            "oslash",
            "questiondown",
            "exclamdown",
            "logicalnot",
            "radical",
            "florin",
            "approxequal",
            "Delta",
            "guillemotleft",
            "guillemotright",
            "ellipsis",
            "nonbreakingspace",
            "Agrave",
            "Atilde",
            "Otilde",
            "OE",
            "oe",
            "endash",
            "emdash",
            "quotedblleft",
            "quotedblright",
            "quoteleft",
            "quoteright",
            "divide",
            "lozenge",
            "ydieresis",
            "Ydieresis",
            "fraction",
            "currency",
            "guilsinglleft",
            "guilsinglright",
            "fi",
            "fl",
            "daggerdbl",
            "periodcentered",
            "quotesinglbase",
            "quotedblbase",
            "perthousand",
            "Acircumflex",
            "Ecircumflex",
            "Aacute",
            "Edieresis",
            "Egrave",
            "Iacute",
            "Icircumflex",
            "Idieresis",
            "Igrave",
            "Oacute",
            "Ocircumflex",
            "apple",
            "Ograve",
            "Uacute",
            "Ucircumflex",
            "Ugrave",
            "dotlessi",
            "circumflex",
            "tilde",
            "macron",
            "breve",
            "dotaccent",
            "ring",
            "cedilla",
            "hungarumlaut",
            "ogonek",
            "caron",
            "Lslash",
            "lslash",
            "Scaron",
            "scaron",
            "Zcaron",
            "zcaron",
            "brokenbar",
            "Eth",
            "eth",
            "Yacute",
            "yacute",
            "Thorn",
            "thorn",
            "minus",
            "multiply",
            "onesuperior",
            "twosuperior",
            "threesuperior",
            "onehalf",
            "onequarter",
            "threequarters",
            "franc",
            "Gbreve",
            "gbreve",
            "Idotaccent",
            "Scedilla",
            "scedilla",
            "Cacute",
            "cacute",
            "Ccaron",
            "ccaron",
            "dcroat",
        };

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void PostScriptTableClass_ConstructorWithNineParameters_SetsTableTagPropertyToPost()
        {
            PostScriptTableVersion testParam0 = _rnd.NextPostScriptTableVersion();
            decimal testParam1 = _rnd.NextDecimal() * 360;
            short testParam2 = _rnd.NextShort();
            short testParam3 = _rnd.NextShort();
            bool testParam4 = _rnd.NextBoolean();
            uint testParam5 = _rnd.NextUInt();
            uint testParam6 = _rnd.NextUInt();
            uint testParam7 = _rnd.NextUInt();
            uint testParam8 = _rnd.NextUInt();

            PostScriptTable testOutput = new PostScriptTable(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8);

            Assert.AreEqual("post", testOutput.TableTag.Value);
        }

        [TestMethod]
        public void PostScriptTableClass_ConstructorWithNineParameters_SetsVersionPropertyToValueOfFirstParameter()
        {
            PostScriptTableVersion testParam0 = _rnd.NextPostScriptTableVersion();
            decimal testParam1 = _rnd.NextDecimal() * 360;
            short testParam2 = _rnd.NextShort();
            short testParam3 = _rnd.NextShort();
            bool testParam4 = _rnd.NextBoolean();
            uint testParam5 = _rnd.NextUInt();
            uint testParam6 = _rnd.NextUInt();
            uint testParam7 = _rnd.NextUInt();
            uint testParam8 = _rnd.NextUInt();

            PostScriptTable testOutput = new PostScriptTable(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8);

            Assert.AreEqual(testParam0, testOutput.Version);
        }

        [TestMethod]
        public void PostScriptTableClass_ConstructorWithNineParameters_SetsItalicAnglePropertyToValueOfSecondParameter()
        {
            PostScriptTableVersion testParam0 = _rnd.NextPostScriptTableVersion();
            decimal testParam1 = _rnd.NextDecimal() * 360;
            short testParam2 = _rnd.NextShort();
            short testParam3 = _rnd.NextShort();
            bool testParam4 = _rnd.NextBoolean();
            uint testParam5 = _rnd.NextUInt();
            uint testParam6 = _rnd.NextUInt();
            uint testParam7 = _rnd.NextUInt();
            uint testParam8 = _rnd.NextUInt();

            PostScriptTable testOutput = new PostScriptTable(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8);

            Assert.AreEqual(testParam1, testOutput.ItalicAngle);
        }

        [TestMethod]
        public void PostScriptTableClass_ConstructorWithNineParameters_SetsUnderlinePositionPropertyToValueOfThirdParameter()
        {
            PostScriptTableVersion testParam0 = _rnd.NextPostScriptTableVersion();
            decimal testParam1 = _rnd.NextDecimal() * 360;
            short testParam2 = _rnd.NextShort();
            short testParam3 = _rnd.NextShort();
            bool testParam4 = _rnd.NextBoolean();
            uint testParam5 = _rnd.NextUInt();
            uint testParam6 = _rnd.NextUInt();
            uint testParam7 = _rnd.NextUInt();
            uint testParam8 = _rnd.NextUInt();

            PostScriptTable testOutput = new PostScriptTable(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8);

            Assert.AreEqual(testParam2, testOutput.UnderlinePosition);
        }

        [TestMethod]
        public void PostScriptTableClass_ConstructorWithNineParameters_SetsUnderlineThicknessPropertyToValueOfFourthParameter()
        {
            PostScriptTableVersion testParam0 = _rnd.NextPostScriptTableVersion();
            decimal testParam1 = _rnd.NextDecimal() * 360;
            short testParam2 = _rnd.NextShort();
            short testParam3 = _rnd.NextShort();
            bool testParam4 = _rnd.NextBoolean();
            uint testParam5 = _rnd.NextUInt();
            uint testParam6 = _rnd.NextUInt();
            uint testParam7 = _rnd.NextUInt();
            uint testParam8 = _rnd.NextUInt();

            PostScriptTable testOutput = new PostScriptTable(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8);

            Assert.AreEqual(testParam3, testOutput.UnderlineThickness);
        }

        [TestMethod]
        public void PostScriptTableClass_ConstructorWithNineParameters_SetsIsFixedPitchPropertyToValueOfFifthParameter()
        {
            PostScriptTableVersion testParam0 = _rnd.NextPostScriptTableVersion();
            decimal testParam1 = _rnd.NextDecimal() * 360;
            short testParam2 = _rnd.NextShort();
            short testParam3 = _rnd.NextShort();
            bool testParam4 = _rnd.NextBoolean();
            uint testParam5 = _rnd.NextUInt();
            uint testParam6 = _rnd.NextUInt();
            uint testParam7 = _rnd.NextUInt();
            uint testParam8 = _rnd.NextUInt();

            PostScriptTable testOutput = new PostScriptTable(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8);

            Assert.AreEqual(testParam4, testOutput.IsFixedPitch);
        }

        [TestMethod]
        public void PostScriptTableClass_ConstructorWithNineParameters_SetsMinMemoryType42PropertyToValueOfSixthParameter()
        {
            PostScriptTableVersion testParam0 = _rnd.NextPostScriptTableVersion();
            decimal testParam1 = _rnd.NextDecimal() * 360;
            short testParam2 = _rnd.NextShort();
            short testParam3 = _rnd.NextShort();
            bool testParam4 = _rnd.NextBoolean();
            uint testParam5 = _rnd.NextUInt();
            uint testParam6 = _rnd.NextUInt();
            uint testParam7 = _rnd.NextUInt();
            uint testParam8 = _rnd.NextUInt();

            PostScriptTable testOutput = new PostScriptTable(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8);

            Assert.AreEqual(testParam5, testOutput.MinMemoryType42);
        }

        [TestMethod]
        public void PostScriptTableClass_ConstructorWithNineParameters_SetsMaxMemoryType42PropertyToValueOfSeventhParameter()
        {
            PostScriptTableVersion testParam0 = _rnd.NextPostScriptTableVersion();
            decimal testParam1 = _rnd.NextDecimal() * 360;
            short testParam2 = _rnd.NextShort();
            short testParam3 = _rnd.NextShort();
            bool testParam4 = _rnd.NextBoolean();
            uint testParam5 = _rnd.NextUInt();
            uint testParam6 = _rnd.NextUInt();
            uint testParam7 = _rnd.NextUInt();
            uint testParam8 = _rnd.NextUInt();

            PostScriptTable testOutput = new PostScriptTable(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8);

            Assert.AreEqual(testParam6, testOutput.MaxMemoryType42);
        }

        [TestMethod]
        public void PostScriptTableClass_ConstructorWithNineParameters_SetsMinMemoryType1PropertyToValueOfEighthParameter()
        {
            PostScriptTableVersion testParam0 = _rnd.NextPostScriptTableVersion();
            decimal testParam1 = _rnd.NextDecimal() * 360;
            short testParam2 = _rnd.NextShort();
            short testParam3 = _rnd.NextShort();
            bool testParam4 = _rnd.NextBoolean();
            uint testParam5 = _rnd.NextUInt();
            uint testParam6 = _rnd.NextUInt();
            uint testParam7 = _rnd.NextUInt();
            uint testParam8 = _rnd.NextUInt();

            PostScriptTable testOutput = new PostScriptTable(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8);

            Assert.AreEqual(testParam7, testOutput.MinMemoryType1);
        }

        [TestMethod]
        public void PostScriptTableClass_ConstructorWithNineParameters_SetsMaxMemoryType1PropertyToValueOfNinthParameter()
        {
            PostScriptTableVersion testParam0 = _rnd.NextPostScriptTableVersion();
            decimal testParam1 = _rnd.NextDecimal() * 360;
            short testParam2 = _rnd.NextShort();
            short testParam3 = _rnd.NextShort();
            bool testParam4 = _rnd.NextBoolean();
            uint testParam5 = _rnd.NextUInt();
            uint testParam6 = _rnd.NextUInt();
            uint testParam7 = _rnd.NextUInt();
            uint testParam8 = _rnd.NextUInt();

            PostScriptTable testOutput = new PostScriptTable(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8);

            Assert.AreEqual(testParam8, testOutput.MaxMemoryType1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PostScriptTableClass_ConstructorWithTenParameters_ThrowsArgumentNullException_IfTenthParameterIsNull()
        {
            PostScriptTableVersion testParam0 = _rnd.NextPostScriptTableVersion();
            decimal testParam1 = _rnd.NextDecimal() * 360;
            short testParam2 = _rnd.NextShort();
            short testParam3 = _rnd.NextShort();
            bool testParam4 = _rnd.NextBoolean();
            uint testParam5 = _rnd.NextUInt();
            uint testParam6 = _rnd.NextUInt();
            uint testParam7 = _rnd.NextUInt();
            uint testParam8 = _rnd.NextUInt();
            IEnumerable<KeyValuePair<string, int>> testParam9 = null;

            _ = new PostScriptTable(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8, testParam9);

            Assert.Fail();
        }

        [TestMethod]
        [ExpectedException(typeof(OpenTypeFormatException))]
        public void PostScriptTableClass_ConstructorWithTenParameters_ThrowsOpenTypeFormatException_IfTenthParameterContainsDuplicateKeys()
        {
            PostScriptTableVersion testParam0 = _rnd.NextPostScriptTableVersion();
            decimal testParam1 = _rnd.NextDecimal() * 360;
            short testParam2 = _rnd.NextShort();
            short testParam3 = _rnd.NextShort();
            bool testParam4 = _rnd.NextBoolean();
            uint testParam5 = _rnd.NextUInt();
            uint testParam6 = _rnd.NextUInt();
            uint testParam7 = _rnd.NextUInt();
            uint testParam8 = _rnd.NextUInt();
            List<KeyValuePair<string, int>> testParam9;
            do
            {
                testParam9 = GetTestCharacterMap();
            } while (!testParam9.Any());
            testParam9.Add(new KeyValuePair<string, int>(testParam9[_rnd.Next(testParam9.Count)].Key, _rnd.Next(ushort.MaxValue)));

            _ = new PostScriptTable(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8, testParam9);

            Assert.Fail();
        }

        [TestMethod]
        public void PostScriptTableClass_ConstructorWithTenParameters_SetsTableTagPropertyToPost_IfTenthParameterIsValid()
        {
            PostScriptTableVersion testParam0 = _rnd.NextPostScriptTableVersion();
            decimal testParam1 = _rnd.NextDecimal() * 360;
            short testParam2 = _rnd.NextShort();
            short testParam3 = _rnd.NextShort();
            bool testParam4 = _rnd.NextBoolean();
            uint testParam5 = _rnd.NextUInt();
            uint testParam6 = _rnd.NextUInt();
            uint testParam7 = _rnd.NextUInt();
            uint testParam8 = _rnd.NextUInt();
            IEnumerable<KeyValuePair<string, int>> testParam9 = GetTestCharacterMap();

            PostScriptTable testOutput = new PostScriptTable(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8,
                testParam9);

            Assert.AreEqual("post", testOutput.TableTag.Value);
        }

        [TestMethod]
        public void PostScriptTableClass_ConstructorWithTenParameters_SetsVersionPropertyToValueOfFirstParameter_IfTenthParameterIsValid()
        {
            PostScriptTableVersion testParam0 = _rnd.NextPostScriptTableVersion();
            decimal testParam1 = _rnd.NextDecimal() * 360;
            short testParam2 = _rnd.NextShort();
            short testParam3 = _rnd.NextShort();
            bool testParam4 = _rnd.NextBoolean();
            uint testParam5 = _rnd.NextUInt();
            uint testParam6 = _rnd.NextUInt();
            uint testParam7 = _rnd.NextUInt();
            uint testParam8 = _rnd.NextUInt();
            IEnumerable<KeyValuePair<string, int>> testParam9 = GetTestCharacterMap();

            PostScriptTable testOutput = new PostScriptTable(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8,
                testParam9);

            Assert.AreEqual(testParam0, testOutput.Version);
        }

        [TestMethod]
        public void PostScriptTableClass_ConstructorWithTenParameters_SetsItalicAnglePropertyToValueOfSecondParameter_IfTenthParameterIsValid()
        {
            PostScriptTableVersion testParam0 = _rnd.NextPostScriptTableVersion();
            decimal testParam1 = _rnd.NextDecimal() * 360;
            short testParam2 = _rnd.NextShort();
            short testParam3 = _rnd.NextShort();
            bool testParam4 = _rnd.NextBoolean();
            uint testParam5 = _rnd.NextUInt();
            uint testParam6 = _rnd.NextUInt();
            uint testParam7 = _rnd.NextUInt();
            uint testParam8 = _rnd.NextUInt();
            IEnumerable<KeyValuePair<string, int>> testParam9 = GetTestCharacterMap();

            PostScriptTable testOutput = new PostScriptTable(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8,
                testParam9);

            Assert.AreEqual(testParam1, testOutput.ItalicAngle);
        }

        [TestMethod]
        public void PostScriptTableClass_ConstructorWithTenParameters_SetsUnderlinePositionPropertyToValueOfThirdParameter_IfTenthParameterIsValid()
        {
            PostScriptTableVersion testParam0 = _rnd.NextPostScriptTableVersion();
            decimal testParam1 = _rnd.NextDecimal() * 360;
            short testParam2 = _rnd.NextShort();
            short testParam3 = _rnd.NextShort();
            bool testParam4 = _rnd.NextBoolean();
            uint testParam5 = _rnd.NextUInt();
            uint testParam6 = _rnd.NextUInt();
            uint testParam7 = _rnd.NextUInt();
            uint testParam8 = _rnd.NextUInt();
            IEnumerable<KeyValuePair<string, int>> testParam9 = GetTestCharacterMap();

            PostScriptTable testOutput = new PostScriptTable(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8,
                testParam9);

            Assert.AreEqual(testParam2, testOutput.UnderlinePosition);
        }

        [TestMethod]
        public void PostScriptTableClass_ConstructorWithTenParameters_SetsUnderlineThicknessPropertyToValueOfFourthParameter_IfTenthParameterIsValid()
        {
            PostScriptTableVersion testParam0 = _rnd.NextPostScriptTableVersion();
            decimal testParam1 = _rnd.NextDecimal() * 360;
            short testParam2 = _rnd.NextShort();
            short testParam3 = _rnd.NextShort();
            bool testParam4 = _rnd.NextBoolean();
            uint testParam5 = _rnd.NextUInt();
            uint testParam6 = _rnd.NextUInt();
            uint testParam7 = _rnd.NextUInt();
            uint testParam8 = _rnd.NextUInt();
            IEnumerable<KeyValuePair<string, int>> testParam9 = GetTestCharacterMap();

            PostScriptTable testOutput = new PostScriptTable(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8,
                testParam9);

            Assert.AreEqual(testParam3, testOutput.UnderlineThickness);
        }

        [TestMethod]
        public void PostScriptTableClass_ConstructorWithTenParameters_SetsIsFixedPitchPropertyToValueOfFifthParameter_IfTenthParameterIsValid()
        {
            PostScriptTableVersion testParam0 = _rnd.NextPostScriptTableVersion();
            decimal testParam1 = _rnd.NextDecimal() * 360;
            short testParam2 = _rnd.NextShort();
            short testParam3 = _rnd.NextShort();
            bool testParam4 = _rnd.NextBoolean();
            uint testParam5 = _rnd.NextUInt();
            uint testParam6 = _rnd.NextUInt();
            uint testParam7 = _rnd.NextUInt();
            uint testParam8 = _rnd.NextUInt();
            IEnumerable<KeyValuePair<string, int>> testParam9 = GetTestCharacterMap();

            PostScriptTable testOutput = new PostScriptTable(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8,
                testParam9);

            Assert.AreEqual(testParam4, testOutput.IsFixedPitch);
        }

        [TestMethod]
        public void PostScriptTableClass_ConstructorWithTenParameters_SetsMinMemoryType42PropertyToValueOfSixthParameter_IfTenthParameterIsValid()
        {
            PostScriptTableVersion testParam0 = _rnd.NextPostScriptTableVersion();
            decimal testParam1 = _rnd.NextDecimal() * 360;
            short testParam2 = _rnd.NextShort();
            short testParam3 = _rnd.NextShort();
            bool testParam4 = _rnd.NextBoolean();
            uint testParam5 = _rnd.NextUInt();
            uint testParam6 = _rnd.NextUInt();
            uint testParam7 = _rnd.NextUInt();
            uint testParam8 = _rnd.NextUInt();
            IEnumerable<KeyValuePair<string, int>> testParam9 = GetTestCharacterMap();

            PostScriptTable testOutput = new PostScriptTable(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8,
                testParam9);

            Assert.AreEqual(testParam5, testOutput.MinMemoryType42);
        }

        [TestMethod]
        public void PostScriptTableClass_ConstructorWithTenParameters_SetsMaxMemoryType42PropertyToValueOfSeventhParameter_IfTenthParameterIsValid()
        {
            PostScriptTableVersion testParam0 = _rnd.NextPostScriptTableVersion();
            decimal testParam1 = _rnd.NextDecimal() * 360;
            short testParam2 = _rnd.NextShort();
            short testParam3 = _rnd.NextShort();
            bool testParam4 = _rnd.NextBoolean();
            uint testParam5 = _rnd.NextUInt();
            uint testParam6 = _rnd.NextUInt();
            uint testParam7 = _rnd.NextUInt();
            uint testParam8 = _rnd.NextUInt();
            IEnumerable<KeyValuePair<string, int>> testParam9 = GetTestCharacterMap();

            PostScriptTable testOutput = new PostScriptTable(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8,
                testParam9);

            Assert.AreEqual(testParam6, testOutput.MaxMemoryType42);
        }

        [TestMethod]
        public void PostScriptTableClass_ConstructorWithTenParameters_SetsMinMemoryType1PropertyToValueOfEighthParameter_IfTenthParameterIsValid()
        {
            PostScriptTableVersion testParam0 = _rnd.NextPostScriptTableVersion();
            decimal testParam1 = _rnd.NextDecimal() * 360;
            short testParam2 = _rnd.NextShort();
            short testParam3 = _rnd.NextShort();
            bool testParam4 = _rnd.NextBoolean();
            uint testParam5 = _rnd.NextUInt();
            uint testParam6 = _rnd.NextUInt();
            uint testParam7 = _rnd.NextUInt();
            uint testParam8 = _rnd.NextUInt();
            IEnumerable<KeyValuePair<string, int>> testParam9 = GetTestCharacterMap();

            PostScriptTable testOutput = new PostScriptTable(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8,
                testParam9);

            Assert.AreEqual(testParam7, testOutput.MinMemoryType1);
        }

        [TestMethod]
        public void PostScriptTableClass_ConstructorWithTenParameters_SetsMaxMemoryType1PropertyToValueOfNinthParameter_IfTenthParameterIsValid()
        {
            PostScriptTableVersion testParam0 = _rnd.NextPostScriptTableVersion();
            decimal testParam1 = _rnd.NextDecimal() * 360;
            short testParam2 = _rnd.NextShort();
            short testParam3 = _rnd.NextShort();
            bool testParam4 = _rnd.NextBoolean();
            uint testParam5 = _rnd.NextUInt();
            uint testParam6 = _rnd.NextUInt();
            uint testParam7 = _rnd.NextUInt();
            uint testParam8 = _rnd.NextUInt();
            IEnumerable<KeyValuePair<string, int>> testParam9 = GetTestCharacterMap();

            PostScriptTable testOutput = new PostScriptTable(testParam0, testParam1, testParam2, testParam3, testParam4, testParam5, testParam6, testParam7, testParam8,
                testParam9);

            Assert.AreEqual(testParam8, testOutput.MaxMemoryType1);
        }

        [TestMethod]
        public void PostScriptTableClass_GetGlyphByNameMethod_ReturnsCorrectResult_IfVersionPropertyIsTwoOrTwoPointFiveAndParameterIsPresentInOverrideGlyphMapping()
        {
            List<KeyValuePair<string, int>> glyphMapping = GetTestCharacterMap();
            string testParam = glyphMapping[_rnd.Next(glyphMapping.Count)].Key;
            int expectedResult = glyphMapping.First(m => m.Key == testParam).Value;
            PostScriptTable testObject = GetTestObject(glyphMapping);

            int? testOutput = testObject.GetGlyphByName(testParam);

            Assert.IsTrue(testOutput.HasValue);
            Assert.AreEqual(expectedResult, testOutput.Value);
        }

        [TestMethod]
        public void PostScriptTableClass_GetGlyphByNameMethod_ReturnsNull_IfVersionPropertyIsTwoOrTwoPointFiveAndParameterIsNotPresentInOverrideGlyphMapping()
        {
            List<KeyValuePair<string, int>> glyphMapping = GetTestCharacterMap();
            string testParam;
            do
            {
                testParam = _rnd.NextString(_rnd.Next(1, 25));
            } while (glyphMapping.Any(m => m.Key == testParam));
            PostScriptTable testObject = GetTestObject(glyphMapping);

            int? testOutput = testObject.GetGlyphByName(testParam);

            Assert.IsFalse(testOutput.HasValue);
        }

        [TestMethod]
        public void PostScriptTableClass_GetGlyphByNameMethod_ReturnsCorrectResult_IfVersionPropertyIsOneThreeOrFourAndParameterIsAStandardGlyphName()
        {
            int expectedResult = _rnd.Next(_standardCharacterMap.Length);
            string testParam = _standardCharacterMap[expectedResult];
            PostScriptTable testObject = GetTestObject();

            int? testOutput = testObject.GetGlyphByName(testParam);

            Assert.IsTrue(testOutput.HasValue);
            Assert.AreEqual(expectedResult, testOutput.Value);
        }

        [TestMethod]
        public void PostScriptTableClass_GetGlyphByNameMethod_ReturnsNull_IfVersionPropertyIsOneThreeOrFourAndParameterIsNotAStandardGlyphName()
        {
            string testParam;
            do
            {
                testParam = _rnd.NextString(_rnd.Next(1, 25));
            } while (_standardCharacterMap.Contains(testParam));
            PostScriptTable testObject = GetTestObject();

            int? testOutput = testObject.GetGlyphByName(testParam);

            Assert.IsFalse(testOutput.HasValue);
        }

#pragma warning restore CA5394 // Do not use insecure randomness
#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
