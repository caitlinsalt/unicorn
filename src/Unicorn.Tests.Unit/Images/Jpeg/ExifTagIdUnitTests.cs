using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unicorn.Images.Jpeg;

namespace Unicorn.Tests.Unit.Images.Jpeg
{
    /// <summary>
    /// These test are included because the enumeration values are defined in the EXIF specification,
    /// so any change to them is probably in error and should be flagged.
    /// </summary>
    [TestClass]
    public class ExifTagIdUnitTests
    {

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void ExifTagIdEnum_GpsVersionIdValue_Equals0()
        {
            int testOutput = (int)ExifTagId.GpsVersionId;

            Assert.AreEqual(0, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_GpsLatitudeRefValue_Equals1()
        {
            int testOutput = (int)ExifTagId.GpsLatitudeRef;

            Assert.AreEqual(1, testOutput);
        }


        [TestMethod]
        public void ExifTagIdEnum_GpsLatitudeValue_Equals2()
        {
            int testOutput = (int)ExifTagId.GpsLatitude;

            Assert.AreEqual(2, testOutput);
        }


        [TestMethod]
        public void ExifTagIdEnum_GpsLongitudeRefValue_Equals3()
        {
            int testOutput = (int)ExifTagId.GpsLongitudeRef;

            Assert.AreEqual(3, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_GpsLongitudeValue_Equals4()
        {
            int testOutput = (int)ExifTagId.GpsLongitude;

            Assert.AreEqual(4, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_GpsAltitudeRefValue_Equals5()
        {
            int testOutput = (int)ExifTagId.GpsAltitudeRef;

            Assert.AreEqual(5, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_GpsAltitudeValue_Equals6()
        {
            int testOutput = (int)ExifTagId.GpsAltitude;

            Assert.AreEqual(6, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_GpsTimeStampValue_Equals7()
        {
            int testOutput = (int)ExifTagId.GpsTimeStamp;

            Assert.AreEqual(7, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_GpsSatellitesValue_Equals8()
        {
            int testOutput = (int)ExifTagId.GpsSatellites;

            Assert.AreEqual(8, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_GpsStatusValue_Equals0()
        {
            int testOutput = (int)ExifTagId.GpsStatus;

            Assert.AreEqual(9, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_GpsMeasureModeValue_Equals10()
        {
            int testOutput = (int)ExifTagId.GpsMeasureMode;

            Assert.AreEqual(10, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_GpsDOPValue_Equals11()
        {
            int testOutput = (int)ExifTagId.GpsDOP;

            Assert.AreEqual(11, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_GpsSpeedRefValue_Equals12()
        {
            int testOutput = (int)ExifTagId.GpsSpeedRef;

            Assert.AreEqual(12, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_GpsSpeedValue_Equals13()
        {
            int testOutput = (int)ExifTagId.GpsSpeed;

            Assert.AreEqual(13, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_GpsTrackRefValue_Equals14()
        {
            int testOutput = (int)ExifTagId.GpsTrackRef;

            Assert.AreEqual(14, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_GpsTrackValue_Equals15()
        {
            int testOutput = (int)ExifTagId.GpsTrack;

            Assert.AreEqual(15, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_GpsImgDirectionRefValue_Equals16()
        {
            int testOutput = (int)ExifTagId.GpsImgDirectionRef;

            Assert.AreEqual(16, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_GpsImgDirectionValue_Equals17()
        {
            int testOutput = (int)ExifTagId.GpsImgDirection;

            Assert.AreEqual(17, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_GpsMapDatumValue_Equals18()
        {
            int testOutput = (int)ExifTagId.GpsMapDatum;

            Assert.AreEqual(18, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_GpsDestLatitudeRefValue_Equals19()
        {
            int testOutput = (int)ExifTagId.GpsDestLatitudeRef;

            Assert.AreEqual(19, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_GpsDestLatitudeValue_Equals20()
        {
            int testOutput = (int)ExifTagId.GpsDestLatitude;

            Assert.AreEqual(20, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_GpsDestLongitudeRefValue_Equals21()
        {
            int testOutput = (int)ExifTagId.GpsDestLongitudeRef;

            Assert.AreEqual(21, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_GpsDestLongitudeValue_Equals22()
        {
            int testOutput = (int)ExifTagId.GpsDestLongitude;

            Assert.AreEqual(22, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_GpsDestBearingRefValue_Equals23()
        {
            int testOutput = (int)ExifTagId.GpsDestBearingRef;

            Assert.AreEqual(23, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_GpsDestBearingValue_Equals24()
        {
            int testOutput = (int)ExifTagId.GpsDestBearing;

            Assert.AreEqual(24, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_GpsDestDistanceRefValue_Equals25()
        {
            int testOutput = (int)ExifTagId.GpsDestDistanceRef;

            Assert.AreEqual(25, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_GpsDestDistanceValue_Equals26()
        {
            int testOutput = (int)ExifTagId.GpsDestDistance;

            Assert.AreEqual(26, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_GpsProcessingMethodValue_Equals27()
        {
            int testOutput = (int)ExifTagId.GpsProcessingMethod;

            Assert.AreEqual(27, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_GpsAreaInformationValue_Equals28()
        {
            int testOutput = (int)ExifTagId.GpsAreaInformation;

            Assert.AreEqual(28, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_GpsDateStampValue_Equals29()
        {
            int testOutput = (int)ExifTagId.GpsDateStamp;

            Assert.AreEqual(29, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_GpsDifferentialValue_Equals30()
        {
            int testOutput = (int)ExifTagId.GpsDifferential;

            Assert.AreEqual(30, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_ImageWidthValue_Equals256()
        {
            int testOutput = (int)ExifTagId.ImageWidth;

            Assert.AreEqual(256, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_ImageLengthValue_Equals257()
        {
            int testOutput = (int)ExifTagId.ImageLength;

            Assert.AreEqual(257, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_BitsPerSampleValue_Equals258()
        {
            int testOutput = (int)ExifTagId.BitsPerSample;

            Assert.AreEqual(258, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_CompressionValue_Equals259()
        {
            int testOutput = (int)ExifTagId.Compression;

            Assert.AreEqual(259, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_PhotometricInterpretationValue_Equals262()
        {
            int testOutput = (int)ExifTagId.PhotometricInterpretation;

            Assert.AreEqual(262, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_ImageDescriptionValue_Equals270()
        {
            int testOutput = (int)ExifTagId.ImageDescription;

            Assert.AreEqual(270, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_MakeValue_Equals217()
        {
            int testOutput = (int)ExifTagId.Make;

            Assert.AreEqual(271, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_ModelValue_Equals272()
        {
            int testOutput = (int)ExifTagId.Model;

            Assert.AreEqual(272, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_StripOffsetsValue_Equals273()
        {
            int testOutput = (int)ExifTagId.StripOffsets;

            Assert.AreEqual(273, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_OrientationValue_Equals274()
        {
            int testOutput = (int)ExifTagId.Orientation;

            Assert.AreEqual(274, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_SamplesPerPixelValue_Equals277()
        {
            int testOutput = (int)ExifTagId.SamplesPerPixel;

            Assert.AreEqual(277, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_RowsPerStripValue_Equals278()
        {
            int testOutput = (int)ExifTagId.RowsPerStrip;

            Assert.AreEqual(278, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_StripByteCountsValue_Equals279()
        {
            int testOutput = (int)ExifTagId.StripByteCounts;

            Assert.AreEqual(279, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_XResolutionValue_Equals282()
        {
            int testOutput = (int)ExifTagId.XResolution;

            Assert.AreEqual(282, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_YResolutionValue_Equals283()
        {
            int testOutput = (int)ExifTagId.YResolution;

            Assert.AreEqual(283, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_PlanarConfigurationValue_Equals284()
        {
            int testOutput = (int)ExifTagId.PlanarConfiguration;

            Assert.AreEqual(284, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_ResolutionUnitValue_Equals296()
        {
            int testOutput = (int)ExifTagId.ResolutionUnit;

            Assert.AreEqual(296, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_TransferFunctionValue_Equals301()
        {
            int testOutput = (int)ExifTagId.TransferFunction;

            Assert.AreEqual(301, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_SoftwareValue_Equals305()
        {
            int testOutput = (int)ExifTagId.Software;

            Assert.AreEqual(305, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_DateTimeValue_Equals306()
        {
            int testOutput = (int)ExifTagId.DateTime;

            Assert.AreEqual(306, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_ArtistValue_Equals315()
        {
            int testOutput = (int)ExifTagId.Artist;

            Assert.AreEqual(315, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_WhitePointValue_Equals318()
        {
            int testOutput = (int)ExifTagId.WhitePoint;

            Assert.AreEqual(318, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_PrimaryChromaticitiesValue_Equals319()
        {
            int testOutput = (int)ExifTagId.PrimaryChromaticities;

            Assert.AreEqual(319, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_JPEGInterchangeFormatValue_Equals513()
        {
            int testOutput = (int)ExifTagId.JPEGInterchangeFormat;

            Assert.AreEqual(513, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_JPEGInterchangeFormatLengthValue_Equals514()
        {
            int testOutput = (int)ExifTagId.JPEGInterchangeFormatLength;

            Assert.AreEqual(514, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_YCbCrCoefficientsValue_Equals529()
        {
            int testOutput = (int)ExifTagId.YCbCrCoefficients;

            Assert.AreEqual(529, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_YCbCrSubSamplingValue_Equals530()
        {
            int testOutput = (int)ExifTagId.YCbCrSubSampling;

            Assert.AreEqual(530, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_YCbCrPositioningValue_Equals531()
        {
            int testOutput = (int)ExifTagId.YCbCrPositioning;

            Assert.AreEqual(531, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_ReferenceBlackWhiteValue_Equals532()
        {
            int testOutput = (int)ExifTagId.ReferenceBlackWhite;

            Assert.AreEqual(532, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_CopyrightValue_Equals33432()
        {
            int testOutput = (int)ExifTagId.Copyright;

            Assert.AreEqual(33432, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_ExposureTimeValue_Equals33434()
        {
            int testOutput = (int)ExifTagId.ExposureTime;

            Assert.AreEqual(33434, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_FNumberValue_Equals33437()
        {
            int testOutput = (int)ExifTagId.FNumber;

            Assert.AreEqual(33437, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_ExifPointerValue_Equals34665()
        {
            int testOutput = (int)ExifTagId.ExifPointer;

            Assert.AreEqual(34665, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_ExposureProgramValue_Equals34850()
        {
            int testOutput = (int)ExifTagId.ExposureProgram;

            Assert.AreEqual(34850, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_SpectralSensitivityValue_Equals34852()
        {
            int testOutput = (int)ExifTagId.SpectralSensitivity;

            Assert.AreEqual(34852, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_GpsPointerValue_Equals34853()
        {
            int testOutput = (int)ExifTagId.GpsPointer;

            Assert.AreEqual(34853, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_ISOSpeedRatingsValue_Equals34855()
        {
            int testOutput = (int)ExifTagId.ISOSpeedRatings;

            Assert.AreEqual(34855, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_OECFValue_Equals34856()
        {
            int testOutput = (int)ExifTagId.OECF;

            Assert.AreEqual(34856, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_ExifVersionValue_Equals36864()
        {
            int testOutput = (int)ExifTagId.ExifVersion;

            Assert.AreEqual(36864, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_DateTimeOriginalValue_Equals36867()
        {
            int testOutput = (int)ExifTagId.DateTimeOriginal;

            Assert.AreEqual(36867, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_DateTimeDigitizedValue_Equals36868()
        {
            int testOutput = (int)ExifTagId.DateTimeDigitized;

            Assert.AreEqual(36868, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_ComponentConfigurationValue_Equals37121()
        {
            int testOutput = (int)ExifTagId.ComponentsConfiguration;

            Assert.AreEqual(37121, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_CompressedBitsPerPixelValue_Equals37122()
        {
            int testOutput = (int)ExifTagId.CompressedBitsPerPixel;

            Assert.AreEqual(37122, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_ShutterSpeedValueValue_Equals37377()
        {
            int testOutput = (int)ExifTagId.ShutterSpeedValue;

            Assert.AreEqual(37377, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_ApetureValueValue_Equals37378()
        {
            int testOutput = (int)ExifTagId.ApertureValue;

            Assert.AreEqual(37378, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_BrightnessValueValue_Equals37379()
        {
            int testOutput = (int)ExifTagId.BrightnessValue;

            Assert.AreEqual(37379, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_ExposureBiasValueValue_Equals37380()
        {
            int testOutput = (int)ExifTagId.ExposureBiasValue;

            Assert.AreEqual(37380, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_MaxApertureValueValue_Equals37381()
        {
            int testOutput = (int)ExifTagId.MaxApertureValue;

            Assert.AreEqual(37381, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_SubjectDistanceValue_Equals37382()
        {
            int testOutput = (int)ExifTagId.SubjectDistance;

            Assert.AreEqual(37382, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_MeteringModeValue_Equals37383()
        {
            int testOutput = (int)ExifTagId.MeteringMode;

            Assert.AreEqual(37383, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_LightSourceValue_Equals37384()
        {
            int testOutput = (int)ExifTagId.LightSource;

            Assert.AreEqual(37384, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_FlashValue_Equals37385()
        {
            int testOutput = (int)ExifTagId.Flash;

            Assert.AreEqual(37385, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_FocalLengthValue_Equals37386()
        {
            int testOutput = (int)ExifTagId.FocalLength;

            Assert.AreEqual(37386, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_SubjectAreaValue_Equals37396()
        {
            int testOutput = (int)ExifTagId.SubjectArea;

            Assert.AreEqual(37396, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_MakerNoteValue_Equals37500()
        {
            int testOutput = (int)ExifTagId.MakerNote;

            Assert.AreEqual(37500, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_UserCommentValue_Equals37510()
        {
            int testOutput = (int)ExifTagId.UserComment;

            Assert.AreEqual(37510, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_SubSecTimeValue_Equals37520()
        {
            int testOutput = (int)ExifTagId.SubSecTime;

            Assert.AreEqual(37520, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_SubSecTimeOriginalValue_Equals37521()
        {
            int testOutput = (int)ExifTagId.SubSecTimeOriginal;

            Assert.AreEqual(37521, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_SubSecTimeDigitizedValue_Equals37522()
        {
            int testOutput = (int)ExifTagId.SubSecTimeDigitized;

            Assert.AreEqual(37522, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_FLashpixVersionValue_Equals40960()
        {
            int testOutput = (int)ExifTagId.FlashpixVersion;

            Assert.AreEqual(40960, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_ColorSpaceValue_Equals40961()
        {
            int testOutput = (int)ExifTagId.ColorSpace;

            Assert.AreEqual(40961, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_PixelXDimensionValue_Equals40962()
        {
            int testOutput = (int)ExifTagId.PixelXDimension;

            Assert.AreEqual(40962, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_PixelYDimensionValue_Equals40963()
        {
            int testOutput = (int)ExifTagId.PixelYDimension;

            Assert.AreEqual(40963, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_RelatedSoundFileValue_Equals40964()
        {
            int testOutput = (int)ExifTagId.RelatedSoundFile;

            Assert.AreEqual(40964, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_InteroperabilityPointerValue_Equals40965()
        {
            int testOutput = (int)ExifTagId.InteroperabilityPointer;

            Assert.AreEqual(40965, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_FlashEnergyValue_Equals41483()
        {
            int testOutput = (int)ExifTagId.FlashEnergy;

            Assert.AreEqual(41483, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_SpatialFrequencyResponseValue_Equals41484()
        {
            int testOutput = (int)ExifTagId.SpatialFrequencyResponse;

            Assert.AreEqual(41484, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_FocalPlaneXResolutionValue_Equals41486()
        {
            int testOutput = (int)ExifTagId.FocalPlaneXResolution;

            Assert.AreEqual(41486, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_FocalPlaneYResolutionValue_Equals41487()
        {
            int testOutput = (int)ExifTagId.FocalPlaneYResolution;

            Assert.AreEqual(41487, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_FocalPlaneResolutionUnitValue_Equals41488()
        {
            int testOutput = (int)ExifTagId.FocalPlaneResolutionUnit;

            Assert.AreEqual(41488, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_SubjectLocationValue_Equals41492()
        {
            int testOutput = (int)ExifTagId.SubjectLocation;

            Assert.AreEqual(41492, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_ExposureIndexValue_Equals41493()
        {
            int testOutput = (int)ExifTagId.ExposureIndex;

            Assert.AreEqual(41493, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_SensingMethodValue_Equals41495()
        {
            int testOutput = (int)ExifTagId.SensingMethod;

            Assert.AreEqual(41495, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_FileSourceValue_Equals41728()
        {
            int testOutput = (int)ExifTagId.FileSource;

            Assert.AreEqual(41728, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_SceneTypeValue_Equals41729()
        {
            int testOutput = (int)ExifTagId.SceneType;

            Assert.AreEqual(41729, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_CFAPatternValue_Equals41730()
        {
            int testOutput = (int)ExifTagId.CFAPattern;

            Assert.AreEqual(41730, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_CustomRenderedValue_Equals41985()
        {
            int testOutput = (int)ExifTagId.CustomRendered;

            Assert.AreEqual(41985, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_ExposureModeValue_Equals41986()
        {
            int testOutput = (int)ExifTagId.ExposureMode;

            Assert.AreEqual(41986, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_WhiteBalanceValue_Equals41987()
        {
            int testOutput = (int)ExifTagId.WhiteBalance;

            Assert.AreEqual(41987, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_DigitalZoomRatioValue_Equals41988()
        {
            int testOutput = (int)ExifTagId.DigitalZoomRatio;

            Assert.AreEqual(41988, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_FocalLengthIn35mmFIlmValue_Equals41989()
        {
            int testOutput = (int)ExifTagId.FocalLengthIn35mmFilm;

            Assert.AreEqual(41989, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_SceneCaptureTypeValue_Equals41990()
        {
            int testOutput = (int)ExifTagId.SceneCaptureType;

            Assert.AreEqual(41990, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_GainControlValue_Equals41991()
        {
            int testOutput = (int)ExifTagId.GainControl;

            Assert.AreEqual(41991, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_ContrastValue_Equals41992()
        {
            int testOutput = (int)ExifTagId.Contrast;

            Assert.AreEqual(41992, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_SaturationValue_Equals41993()
        {
            int testOutput = (int)ExifTagId.Saturation;

            Assert.AreEqual(41993, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_SharpnessValue_Equals41994()
        {
            int testOutput = (int)ExifTagId.Sharpness;

            Assert.AreEqual(41994, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_DeviceSettingDescriptionValue_Equals41995()
        {
            int testOutput = (int)ExifTagId.DeviceSettingDescription;

            Assert.AreEqual(41995, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_SubjectDistanceRangeValue_Equals41996()
        {
            int testOutput = (int)ExifTagId.SubjectDistanceRange;

            Assert.AreEqual(41996, testOutput);
        }

        [TestMethod]
        public void ExifTagIdEnum_ImageUniqueIdValue_Equals42016()
        {
            int testOutput = (int)ExifTagId.ImageUniqueId;

            Assert.AreEqual(42016, testOutput);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
