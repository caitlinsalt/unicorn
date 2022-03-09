using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Unicorn.Images.Jpeg;

namespace Unicorn.Tests.Unit.Images.Jpeg
{
    [TestClass]
    public class ExifTagIdExtensionsUnitTests
    {

#pragma warning disable CA1707 // Identifiers should not contain underscores

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsReadFromFile_IfParameterEqualsImageWidth()
        {
            ExifTagId testParam = ExifTagId.ImageWidth;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.ReadFromFile, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsReadFromFile_IfParameterEqualsImageLength()
        {
            ExifTagId testParam = ExifTagId.ImageLength;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.ReadFromFile, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsReadFromFile_IfParameterEqualsStripOffsets()
        {
            ExifTagId testParam = ExifTagId.StripOffsets;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.ReadFromFile, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsReadFromFile_IfParameterEqualsRowsPerStrip()
        {
            ExifTagId testParam = ExifTagId.RowsPerStrip;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.ReadFromFile, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsReadFromFile_IfParameterEqualsStripByteCounts()
        {
            ExifTagId testParam = ExifTagId.StripByteCounts;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.ReadFromFile, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsReadFromFile_IfParameterEqualsPixelXDimension()
        {
            ExifTagId testParam = ExifTagId.PixelXDimension;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.ReadFromFile, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsReadFromFile_IfParameterEqualsPixelYDimension()
        {
            ExifTagId testParam = ExifTagId.PixelYDimension;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.ReadFromFile, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsUndefined_IfParameterEqualsExifVersion()
        {
            ExifTagId testParam = ExifTagId.ExifVersion;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Undefined, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsUndefined_IfParameterEqualsFlashpixVersion()
        {
            ExifTagId testParam = ExifTagId.FlashpixVersion;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Undefined, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsUndefined_IfParameterEqualsComponentsConfiguration()
        {
            ExifTagId testParam = ExifTagId.ComponentsConfiguration;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Undefined, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsUndefined_IfParameterEqualsMakerNote()
        {
            ExifTagId testParam = ExifTagId.MakerNote;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Undefined, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsUndefined_IfParameterEqualsUserComment()
        {
            ExifTagId testParam = ExifTagId.UserComment;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Undefined, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsUndefined_IfParameterEqualsOECF()
        {
            ExifTagId testParam = ExifTagId.OECF;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Undefined, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsUndefined_IfParameterEqualsSpatialFrequencyResponse()
        {
            ExifTagId testParam = ExifTagId.SpatialFrequencyResponse;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Undefined, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsUndefined_IfParameterEqualsFileSource()
        {
            ExifTagId testParam = ExifTagId.FileSource;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Undefined, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsUndefined_IfParameterEqualsSceneType()
        {
            ExifTagId testParam = ExifTagId.SceneType;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Undefined, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsUndefined_IfParameterEqualsCFAPattern()
        {
            ExifTagId testParam = ExifTagId.CFAPattern;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Undefined, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsUndefined_IfParameterEqualsDeviceSettingDescriptiob()
        {
            ExifTagId testParam = ExifTagId.DeviceSettingDescription;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Undefined, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsUndefined_IfParameterEqualsGpsProcessingMethod()
        {
            ExifTagId testParam = ExifTagId.GpsProcessingMethod;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Undefined, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsUndefined_IfParameterEqualsGpsAreaInformation()
        {
            ExifTagId testParam = ExifTagId.GpsAreaInformation;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Undefined, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsShort_IfParameterEqualsBitsPerSample()
        {
            ExifTagId testParam = ExifTagId.BitsPerSample;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Short, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsShort_IfParameterEqualsCompression()
        {
            ExifTagId testParam = ExifTagId.Compression;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Short, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsShort_IfParameterEqualsPhotometricInterpretation()
        {
            ExifTagId testParam = ExifTagId.PhotometricInterpretation;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Short, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsShort_IfParameterEqualsOrientation()
        {
            ExifTagId testParam = ExifTagId.Orientation;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Short, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsShort_IfParameterEqualsSamplesPerPixel()
        {
            ExifTagId testParam = ExifTagId.SamplesPerPixel;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Short, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsShort_IfParameterEqualsPlanarConfiguration()
        {
            ExifTagId testParam = ExifTagId.PlanarConfiguration;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Short, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsShort_IfParameterEqualsYCbCrPositioning()
        {
            ExifTagId testParam = ExifTagId.YCbCrPositioning;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Short, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsShort_IfParameterEqualsYCbCrSubSampling()
        {
            ExifTagId testParam = ExifTagId.YCbCrSubSampling;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Short, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsShort_IfParameterEqualsResolutionUnit()
        {
            ExifTagId testParam = ExifTagId.ResolutionUnit;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Short, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsShort_IfParameterEqualsTransferFunction()
        {
            ExifTagId testParam = ExifTagId.TransferFunction;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Short, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsShort_IfParameterEqualsColorSpace()
        {
            ExifTagId testParam = ExifTagId.ColorSpace;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Short, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsShort_IfParameterEqualsExposureProgram()
        {
            ExifTagId testParam = ExifTagId.ExposureProgram;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Short, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsShort_IfParameterEqualsISOSpeedRatings()
        {
            ExifTagId testParam = ExifTagId.ISOSpeedRatings;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Short, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsShort_IfParameterEqualsMeteringMode()
        {
            ExifTagId testParam = ExifTagId.MeteringMode;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Short, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsShort_IfParameterEqualsLightSource()
        {
            ExifTagId testParam = ExifTagId.LightSource;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Short, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsShort_IfParameterEqualsFlash()
        {
            ExifTagId testParam = ExifTagId.Flash;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Short, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsShort_IfParameterEqualsSubjectArea()
        {
            ExifTagId testParam = ExifTagId.SubjectArea;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Short, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsShort_IfParameterEqualsFocalPlaneResolutionUnit()
        {
            ExifTagId testParam = ExifTagId.FocalPlaneResolutionUnit;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Short, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsShort_IfParameterEqualsSubjectLocation()
        {
            ExifTagId testParam = ExifTagId.SubjectLocation;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Short, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsShort_IfParameterEqualsSensingMethod()
        {
            ExifTagId testParam = ExifTagId.SensingMethod;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Short, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsShort_IfParameterEqualsCustomRendered()
        {
            ExifTagId testParam = ExifTagId.CustomRendered;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Short, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsShort_IfParameterEqualsExposureMode()
        {
            ExifTagId testParam = ExifTagId.ExposureMode;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Short, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsShort_IfParameterEqualsWhiteBalance()
        {
            ExifTagId testParam = ExifTagId.WhiteBalance;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Short, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsShort_IfParameterEqualsFocalLengthIn35mmFilm()
        {
            ExifTagId testParam = ExifTagId.FocalLengthIn35mmFilm;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Short, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsShort_IfParameterEqualsSceneCaptureType()
        {
            ExifTagId testParam = ExifTagId.SceneCaptureType;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Short, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsShort_IfParameterEqualsContrast()
        {
            ExifTagId testParam = ExifTagId.Contrast;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Short, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsShort_IfParameterEqualsSaturation()
        {
            ExifTagId testParam = ExifTagId.Saturation;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Short, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsShort_IfParameterEqualsSharpness()
        {
            ExifTagId testParam = ExifTagId.Sharpness;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Short, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsShort_IfParameterEqualsSubjectDistanceRange()
        {
            ExifTagId testParam = ExifTagId.SubjectDistanceRange;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Short, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsShort_IfParameterEqualsGpsDifferential()
        {
            ExifTagId testParam = ExifTagId.GpsDifferential;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Short, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsLong_IfParameterEqualsExifPointer()
        {
            ExifTagId testParam = ExifTagId.ExifPointer;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Long, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsLong_IfParameterEqualsGpsPointer()
        {
            ExifTagId testParam = ExifTagId.GpsPointer;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Long, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsLong_IfParameterEqualsInteroperabilityPointer()
        {
            ExifTagId testParam = ExifTagId.InteroperabilityPointer;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Long, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsLong_IfParameterEqualsJPEGInterchangeFormatPointer()
        {
            ExifTagId testParam = ExifTagId.JPEGInterchangeFormat;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Long, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsLong_IfParameterEqualsJPEGInterchangeFormatLengthPointer()
        {
            ExifTagId testParam = ExifTagId.JPEGInterchangeFormatLength;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Long, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsRational_IfParameterEqualsXResolution()
        {
            ExifTagId testParam = ExifTagId.XResolution;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Rational, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsRational_IfParameterEqualsYResolution()
        {
            ExifTagId testParam = ExifTagId.YResolution;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Rational, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsRational_IfParameterEqualsWhitePoint()
        {
            ExifTagId testParam = ExifTagId.WhitePoint;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Rational, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsRational_IfParameterEqualsPrimaryChromaticities()
        {
            ExifTagId testParam = ExifTagId.PrimaryChromaticities;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Rational, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsRational_IfParameterEqualsYCbCrCoefficients()
        {
            ExifTagId testParam = ExifTagId.YCbCrCoefficients;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Rational, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsRational_IfParameterEqualsReferenceBlackWhite()
        {
            ExifTagId testParam = ExifTagId.ReferenceBlackWhite;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Rational, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsRational_IfParameterEqualsCompressedBitsPerPixel()
        {
            ExifTagId testParam = ExifTagId.CompressedBitsPerPixel;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Rational, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsRational_IfParameterEqualsExposureTime()
        {
            ExifTagId testParam = ExifTagId.ExposureTime;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Rational, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsRational_IfParameterEqualsFNumber()
        {
            ExifTagId testParam = ExifTagId.FNumber;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Rational, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsRational_IfParameterEqualsApertureValue()
        {
            ExifTagId testParam = ExifTagId.ApertureValue;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Rational, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsRational_IfParameterEqualsMaxApertureValue()
        {
            ExifTagId testParam = ExifTagId.MaxApertureValue;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Rational, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsRational_IfParameterEqualsSubjectDistance()
        {
            ExifTagId testParam = ExifTagId.SubjectDistance;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Rational, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsRational_IfParameterEqualsFocalLength()
        {
            ExifTagId testParam = ExifTagId.FocalLength;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Rational, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsRational_IfParameterEqualsFlashEnergy()
        {
            ExifTagId testParam = ExifTagId.FlashEnergy;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Rational, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsRational_IfParameterEqualsFocalPlaneXResolution()
        {
            ExifTagId testParam = ExifTagId.FocalPlaneXResolution;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Rational, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsRational_IfParameterEqualsFocalPlaneYResolution()
        {
            ExifTagId testParam = ExifTagId.FocalPlaneYResolution;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Rational, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsRational_IfParameterEqualsExposureIndex()
        {
            ExifTagId testParam = ExifTagId.ExposureIndex;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Rational, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsRational_IfParameterEqualsDigitalZoomRatio()
        {
            ExifTagId testParam = ExifTagId.DigitalZoomRatio;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Rational, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsRational_IfParameterEqualsGpsLatitude()
        {
            ExifTagId testParam = ExifTagId.GpsLatitude;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Rational, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsRational_IfParameterEqualsGpsLongitude()
        {
            ExifTagId testParam = ExifTagId.GpsLongitude;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Rational, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsRational_IfParameterEqualsGpsAltitude()
        {
            ExifTagId testParam = ExifTagId.GpsAltitude;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Rational, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsRational_IfParameterEqualsGpsTimeStamp()
        {
            ExifTagId testParam = ExifTagId.GpsTimeStamp;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Rational, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsRational_IfParameterEqualsGpsDOP()
        {
            ExifTagId testParam = ExifTagId.GpsDOP;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Rational, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsRational_IfParameterEqualsGpsSpeed()
        {
            ExifTagId testParam = ExifTagId.GpsSpeed;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Rational, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsRational_IfParameterEqualsGpsTrack()
        {
            ExifTagId testParam = ExifTagId.GpsTrack;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Rational, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsRational_IfParameterEqualsGpsImgDirection()
        {
            ExifTagId testParam = ExifTagId.GpsImgDirection;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Rational, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsRational_IfParameterEqualsGpsDestLatitude()
        {
            ExifTagId testParam = ExifTagId.GpsDestLatitude;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Rational, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsRational_IfParameterEqualsGpsDestLongitude()
        {
            ExifTagId testParam = ExifTagId.GpsDestLongitude;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Rational, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsRational_IfParameterEqualsGpsDestBearing()
        {
            ExifTagId testParam = ExifTagId.GpsDestBearing;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Rational, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsRational_IfParameterEqualsGpsDestDistance()
        {
            ExifTagId testParam = ExifTagId.GpsDestDistance;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Rational, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsAscii_IfParameterEqualsDateTime()
        {
            ExifTagId testParam = ExifTagId.DateTime;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Ascii, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsAscii_IfParameterEqualsImageDescription()
        {
            ExifTagId testParam = ExifTagId.ImageDescription;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Ascii, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsAscii_IfParameterEqualsMake()
        {
            ExifTagId testParam = ExifTagId.Make;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Ascii, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsAscii_IfParameterEqualsModel()
        {
            ExifTagId testParam = ExifTagId.Model;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Ascii, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsAscii_IfParameterEqualsSoftware()
        {
            ExifTagId testParam = ExifTagId.Software;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Ascii, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsAscii_IfParameterEqualsArtist()
        {
            ExifTagId testParam = ExifTagId.Artist;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Ascii, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsAscii_IfParameterEqualsCopyright()
        {
            ExifTagId testParam = ExifTagId.Copyright;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Ascii, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsAscii_IfParameterEqualsRelatedSoundFile()
        {
            ExifTagId testParam = ExifTagId.RelatedSoundFile;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Ascii, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsAscii_IfParameterEqualsDateTimeOriginal()
        {
            ExifTagId testParam = ExifTagId.DateTimeOriginal;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Ascii, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsAscii_IfParameterEqualsDateTimeDigitized()
        {
            ExifTagId testParam = ExifTagId.DateTimeDigitized;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Ascii, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsAscii_IfParameterEqualsSubSecTime()
        {
            ExifTagId testParam = ExifTagId.SubSecTime;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Ascii, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsAscii_IfParameterEqualsSubSecTimeOriginal()
        {
            ExifTagId testParam = ExifTagId.SubSecTimeOriginal;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Ascii, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsAscii_IfParameterEqualsSubSecTimeDigitized()
        {
            ExifTagId testParam = ExifTagId.SubSecTimeDigitized;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Ascii, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsAscii_IfParameterEqualsImageUniqueId()
        {
            ExifTagId testParam = ExifTagId.ImageUniqueId;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Ascii, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsAscii_IfParameterEqualsSpectralSensitivity()
        {
            ExifTagId testParam = ExifTagId.SpectralSensitivity;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Ascii, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsAscii_IfParameterEqualsGainControl()
        {
            ExifTagId testParam = ExifTagId.GainControl;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Ascii, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsAscii_IfParameterEqualsGpsLatitudeRef()
        {
            ExifTagId testParam = ExifTagId.GpsLatitudeRef;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Ascii, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsAscii_IfParameterEqualsGPsLongitudeRef()
        {
            ExifTagId testParam = ExifTagId.GpsLongitudeRef;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Ascii, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsAscii_IfParameterEqualsGPsSatellites()
        {
            ExifTagId testParam = ExifTagId.GpsSatellites;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Ascii, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsAscii_IfParameterEqualsGpsStatus()
        {
            ExifTagId testParam = ExifTagId.GpsStatus;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Ascii, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsAscii_IfParameterEqualsGpsMeasureMode()
        {
            ExifTagId testParam = ExifTagId.GpsMeasureMode;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Ascii, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsAscii_IfParameterEqualsGpsSpeedRef()
        {
            ExifTagId testParam = ExifTagId.GpsSpeedRef;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Ascii, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsAscii_IfParameterEqualsGpsTrackRef()
        {
            ExifTagId testParam = ExifTagId.GpsTrackRef;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Ascii, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsAscii_IfParameterEqualsGPsImgDirectionRef()
        {
            ExifTagId testParam = ExifTagId.GpsImgDirectionRef;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Ascii, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsAscii_IfParameterEqualsGpsMapDatum()
        {
            ExifTagId testParam = ExifTagId.GpsMapDatum;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Ascii, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsAscii_IfParameterEqualsGpsDestLatitudeRef()
        {
            ExifTagId testParam = ExifTagId.GpsDestLatitudeRef;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Ascii, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsAscii_IfParameterEqualsGpsDestLongitudeRef()
        {
            ExifTagId testParam = ExifTagId.GpsDestLongitudeRef;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Ascii, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsAscii_IfParameterEqualsGpsDestBearingRef()
        {
            ExifTagId testParam = ExifTagId.GpsDestBearingRef;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Ascii, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsAscii_IfParameterEqualsGpsDestDistanceRef()
        {
            ExifTagId testParam = ExifTagId.GpsDestDistanceRef;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Ascii, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsAscii_IfParameterEqualsGpsDateStamp()
        {
            ExifTagId testParam = ExifTagId.GpsDateStamp;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Ascii, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsSRational_IfParameterEqualsShutterSpeedValue()
        {
            ExifTagId testParam = ExifTagId.ShutterSpeedValue;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Srational, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsSRational_IfParameterEqualsBrightnessValue()
        {
            ExifTagId testParam = ExifTagId.BrightnessValue;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Srational, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsSRational_IfParameterEqualsExposureBiasValue()
        {
            ExifTagId testParam = ExifTagId.ExposureBiasValue;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Srational, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsByte_IfParameterEqualsGpsVersionId()
        {
            ExifTagId testParam = ExifTagId.GpsVersionId;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Byte, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_StorageTypeMethod_ReturnsByte_IfParameterEqualsGpsAltitudeRef()
        {
            ExifTagId testParam = ExifTagId.GpsAltitudeRef;

            ExifStorageType testOutput = testParam.StorageType();

            Assert.AreEqual(ExifStorageType.Byte, testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsByte_IfParameterEqualsFileSource()
        {
            ExifTagId testParam = ExifTagId.FileSource;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(byte), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsByte_IfParameterEqualsSceneType()
        {
            ExifTagId testParam = ExifTagId.SceneType;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(byte), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsByte_IfParameterEqualsGPsAltitudeRef()
        {
            ExifTagId testParam = ExifTagId.GpsAltitudeRef;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(byte), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsArrayOfByte_IfParameterEqualsExifVersion()
        {
            ExifTagId testParam = ExifTagId.ExifVersion;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(byte[]), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsArrayOfByte_IfParameterEqualsFlashpixVersion()
        {
            ExifTagId testParam = ExifTagId.FlashpixVersion;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(byte[]), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsArrayOfByte_IfParameterEqualsComponentsConfiguration()
        {
            ExifTagId testParam = ExifTagId.ComponentsConfiguration;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(byte[]), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsArrayOfByte_IfParameterEqualsMakerNote()
        {
            ExifTagId testParam = ExifTagId.MakerNote;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(byte[]), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsArrayOfByte_IfParameterEqualsUserComment()
        {
            ExifTagId testParam = ExifTagId.UserComment;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(byte[]), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsArrayOfByte_IfParameterEqualsOECF()
        {
            ExifTagId testParam = ExifTagId.OECF;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(byte[]), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsArrayOfByte_IfParameterEqualsSpatialFrequencyResponse()
        {
            ExifTagId testParam = ExifTagId.SpatialFrequencyResponse;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(byte[]), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsArrayOfByte_IfParameterEqualsCFAPattern()
        {
            ExifTagId testParam = ExifTagId.CFAPattern;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(byte[]), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsArrayOfByte_IfParameterEqualsDeviceSettingDescription()
        {
            ExifTagId testParam = ExifTagId.DeviceSettingDescription;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(byte[]), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsArrayOfByte_IfParameterEqualsGPsVersionId()
        {
            ExifTagId testParam = ExifTagId.GpsVersionId;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(byte[]), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsArrayOfByte_IfParameterEqualsGpsProcessingMethod()
        {
            ExifTagId testParam = ExifTagId.GpsProcessingMethod;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(byte[]), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsArrayOfByte_IfParameterEqualsGpsAreaInformation()
        {
            ExifTagId testParam = ExifTagId.GpsAreaInformation;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(byte[]), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsInt_IfParameterEqualsCompression()
        {
            ExifTagId testParam = ExifTagId.Compression;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(int), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsInt_IfParameterEqualsPhotometricInterpretation()
        {
            ExifTagId testParam = ExifTagId.PhotometricInterpretation;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(int), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsInt_IfParameterEqualsOrientation()
        {
            ExifTagId testParam = ExifTagId.Orientation;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(int), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsInt_IfParameterEqualsSamplesPerPixel()
        {
            ExifTagId testParam = ExifTagId.SamplesPerPixel;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(int), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsInt_IfParameterEqualsPlanarConfiguration()
        {
            ExifTagId testParam = ExifTagId.PlanarConfiguration;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(int), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsInt_IfParameterEqualsYCbCrPositioning()
        {
            ExifTagId testParam = ExifTagId.YCbCrPositioning;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(int), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsInt_IfParameterEqualsResolutionUnit()
        {
            ExifTagId testParam = ExifTagId.ResolutionUnit;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(int), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsInt_IfParameterEqualsColorSpace()
        {
            ExifTagId testParam = ExifTagId.ColorSpace;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(int), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsInt_IfParameterEqualsExposureProgram()
        {
            ExifTagId testParam = ExifTagId.ExposureProgram;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(int), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsInt_IfParameterEqualsMeteringMode()
        {
            ExifTagId testParam = ExifTagId.MeteringMode;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(int), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsInt_IfParameterEqualsLightSource()
        {
            ExifTagId testParam = ExifTagId.LightSource;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(int), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsInt_IfParameterEqualsFlash()
        {
            ExifTagId testParam = ExifTagId.Flash;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(int), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsInt_IfParameterEqualsFocalPlaneResolutionUnit()
        {
            ExifTagId testParam = ExifTagId.FocalPlaneResolutionUnit;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(int), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsInt_IfParameterEqualsSensingMethod()
        {
            ExifTagId testParam = ExifTagId.SensingMethod;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(int), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsInt_IfParameterEqualsCustomRendered()
        {
            ExifTagId testParam = ExifTagId.CustomRendered;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(int), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsInt_IfParameterEqualsExposureMode()
        {
            ExifTagId testParam = ExifTagId.ExposureMode;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(int), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsInt_IfParameterEqualsWhiteBalance()
        {
            ExifTagId testParam = ExifTagId.WhiteBalance;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(int), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsInt_IfParameterEqualsFocalLengthIn35mmFilm()
        {
            ExifTagId testParam = ExifTagId.FocalLengthIn35mmFilm;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(int), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsInt_IfParameterEqualsSceneCaptureType()
        {
            ExifTagId testParam = ExifTagId.SceneCaptureType;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(int), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsInt_IfParameterEqualsContrast()
        {
            ExifTagId testParam = ExifTagId.Contrast;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(int), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsInt_IfParameterEqualsSaturation()
        {
            ExifTagId testParam = ExifTagId.Saturation;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(int), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsInt_IfParameterEqualsSharpness()
        {
            ExifTagId testParam = ExifTagId.Sharpness;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(int), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsInt_IfParameterEqualsSubjectDistanceRange()
        {
            ExifTagId testParam = ExifTagId.SubjectDistanceRange;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(int), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsInt_IfParameterEqualsGpsDifferential()
        {
            ExifTagId testParam = ExifTagId.GpsDifferential;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(int), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsArrayOfInt_IfParameterEqualsBitsPerSample()
        {
            ExifTagId testParam = ExifTagId.BitsPerSample;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(int[]), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsArrayOfInt_IfParameterEqualsYCbCrSubSampling()
        {
            ExifTagId testParam = ExifTagId.YCbCrSubSampling;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(int[]), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsArrayOfInt_IfParameterEqualsTransferFunction()
        {
            ExifTagId testParam = ExifTagId.TransferFunction;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(int[]), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsArrayOfInt_IfParameterEqualsISOSpeedRatings()
        {
            ExifTagId testParam = ExifTagId.ISOSpeedRatings;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(int[]), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsArrayOfInt_IfParameterEqualsSubjectArea()
        {
            ExifTagId testParam = ExifTagId.SubjectArea;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(int[]), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsArrayOfInt_IfParameterEqualsSubjectLocation()
        {
            ExifTagId testParam = ExifTagId.SubjectLocation;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(int[]), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsLong_IfParameterEqualsExifPointer()
        {
            ExifTagId testParam = ExifTagId.ExifPointer;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(long), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsLong_IfParameterEqualsGpsPointer()
        {
            ExifTagId testParam = ExifTagId.GpsPointer;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(long), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsLong_IfParameterEqualsImageWidth()
        {
            ExifTagId testParam = ExifTagId.ImageWidth;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(long), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsLong_IfParameterEqualsImageLength()
        {
            ExifTagId testParam = ExifTagId.ImageLength;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(long), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsLong_IfParameterEqualsRowsPerStrip()
        {
            ExifTagId testParam = ExifTagId.RowsPerStrip;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(long), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsLong_IfParameterEqualsJPEGInterchangeFormat()
        {
            ExifTagId testParam = ExifTagId.JPEGInterchangeFormat;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(long), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsLong_IfParameterEqualsJPEGInterchangeFormatLength()
        {
            ExifTagId testParam = ExifTagId.JPEGInterchangeFormatLength;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(long), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsLong_IfParameterEqualsPixelXDimension()
        {
            ExifTagId testParam = ExifTagId.PixelXDimension;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(long), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsLong_IfParameterEqualsPixelYDimension()
        {
            ExifTagId testParam = ExifTagId.PixelYDimension;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(long), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsArrayOfLong_IfParameterEqualsStripOffsets()
        {
            ExifTagId testParam = ExifTagId.StripOffsets;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(long[]), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsArrayOfLong_IfParameterEqualsStripByteCounts()
        {
            ExifTagId testParam = ExifTagId.StripByteCounts;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(long[]), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsDecimal_IfParameterEqualsXResolution()
        {
            ExifTagId testParam = ExifTagId.XResolution;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(decimal), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsDecimal_IfParameterEqualsYResolution()
        {
            ExifTagId testParam = ExifTagId.YResolution;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(decimal), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsDecimal_IfParameterEqualsCompressedBitsPerPixel()
        {
            ExifTagId testParam = ExifTagId.CompressedBitsPerPixel;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(decimal), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsDecimal_IfParameterEqualsExposureTime()
        {
            ExifTagId testParam = ExifTagId.ExposureTime;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(decimal), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsDecimal_IfParameterEqualsFNumber()
        {
            ExifTagId testParam = ExifTagId.FNumber;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(decimal), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsDecimal_IfParameterEqualsShutterSpeedValue()
        {
            ExifTagId testParam = ExifTagId.ShutterSpeedValue;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(decimal), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsDecimal_IfParameterEqualsApertureValue()
        {
            ExifTagId testParam = ExifTagId.ApertureValue;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(decimal), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsDecimal_IfParameterEqualsBrightnessValue()
        {
            ExifTagId testParam = ExifTagId.BrightnessValue;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(decimal), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsDecimal_IfParameterEqualsExposureBiasValue()
        {
            ExifTagId testParam = ExifTagId.ExposureBiasValue;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(decimal), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsDecimal_IfParameterEqualsMaxApertureValue()
        {
            ExifTagId testParam = ExifTagId.MaxApertureValue;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(decimal), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsDecimal_IfParameterEqualsSubjectDistance()
        {
            ExifTagId testParam = ExifTagId.SubjectDistance;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(decimal), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsDecimal_IfParameterEqualsFocalLength()
        {
            ExifTagId testParam = ExifTagId.FocalLength;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(decimal), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsDecimal_IfParameterEqualsFlashEnergy()
        {
            ExifTagId testParam = ExifTagId.FlashEnergy;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(decimal), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsDecimal_IfParameterEqualsFocalPlaneXResolution()
        {
            ExifTagId testParam = ExifTagId.FocalPlaneXResolution;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(decimal), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsDecimal_IfParameterEqualsFocalPlaneYResolution()
        {
            ExifTagId testParam = ExifTagId.FocalPlaneYResolution;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(decimal), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsDecimal_IfParameterEqualsExposureIndex()
        {
            ExifTagId testParam = ExifTagId.ExposureIndex;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(decimal), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsDecimal_IfParameterEqualsDigitalZoomRatio()
        {
            ExifTagId testParam = ExifTagId.DigitalZoomRatio;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(decimal), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsDecimal_IfParameterEqualsGainControl()
        {
            ExifTagId testParam = ExifTagId.GainControl;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(decimal), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsDecimal_IfParameterEqualsGpsAltitude()
        {
            ExifTagId testParam = ExifTagId.GpsAltitude;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(decimal), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsDecimal_IfParameterEqualsGpsDOP()
        {
            ExifTagId testParam = ExifTagId.GpsDOP;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(decimal), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsDecimal_IfParameterEqualsGpsSpeed()
        {
            ExifTagId testParam = ExifTagId.GpsSpeed;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(decimal), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsDecimal_IfParameterEqualsGpsTrack()
        {
            ExifTagId testParam = ExifTagId.GpsTrack;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(decimal), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsDecimal_IfParameterEqualsGpsImgDirection()
        {
            ExifTagId testParam = ExifTagId.GpsImgDirection;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(decimal), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsDecimal_IfParameterEqualsGpsDestBearing()
        {
            ExifTagId testParam = ExifTagId.GpsDestBearing;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(decimal), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsDecimal_IfParameterEqualsGpsDestDistance()
        {
            ExifTagId testParam = ExifTagId.GpsDestDistance;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(decimal), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsArrayOfDecimal_IfParameterEqualsWhitePoint()
        {
            ExifTagId testParam = ExifTagId.WhitePoint;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(decimal[]), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsArrayOfDecimal_IfParameterEqualsPrimaryChromaticities()
        {
            ExifTagId testParam = ExifTagId.PrimaryChromaticities;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(decimal[]), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsArrayOfDecimal_IfParameterEqualsYCbCrCoefficients()
        {
            ExifTagId testParam = ExifTagId.YCbCrCoefficients;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(decimal[]), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsArrayOfDecimal_IfParameterEqualsReferenceBlackWhite()
        {
            ExifTagId testParam = ExifTagId.ReferenceBlackWhite;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(decimal[]), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsArrayOfDecimal_IfParameterEqualsGpsLatitude()
        {
            ExifTagId testParam = ExifTagId.GpsLatitude;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(decimal[]), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsArrayOfDecimal_IfParameterEqualsGpsLongitude()
        {
            ExifTagId testParam = ExifTagId.GpsLongitude;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(decimal[]), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsArrayOfDecimal_IfParameterEqualsGpsTimeStamp()
        {
            ExifTagId testParam = ExifTagId.GpsTimeStamp;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(decimal[]), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsArrayOfDecimal_IfParameterEqualsGpsDestLatitude()
        {
            ExifTagId testParam = ExifTagId.GpsDestLatitude;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(decimal[]), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsArrayOfDecimal_IfParameterEqualsGpsDestLongitude()
        {
            ExifTagId testParam = ExifTagId.GpsDestLongitude;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(decimal[]), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsString_IfParameterEqualsDateTime()
        {
            ExifTagId testParam = ExifTagId.DateTime;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(string), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsString_IfParameterEqualsImageDescription()
        {
            ExifTagId testParam = ExifTagId.ImageDescription;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(string), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsString_IfParameterEqualsMake()
        {
            ExifTagId testParam = ExifTagId.Make;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(string), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsString_IfParameterEqualsModel()
        {
            ExifTagId testParam = ExifTagId.Model;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(string), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsString_IfParameterEqualsSoftware()
        {
            ExifTagId testParam = ExifTagId.Software;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(string), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsString_IfParameterEqualsArtist()
        {
            ExifTagId testParam = ExifTagId.Artist;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(string), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsString_IfParameterEqualsCopyright()
        {
            ExifTagId testParam = ExifTagId.Copyright;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(string), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsString_IfParameterEqualsRelatedSoundFile()
        {
            ExifTagId testParam = ExifTagId.RelatedSoundFile;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(string), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsString_IfParameterEqualsDateTimeOriginal()
        {
            ExifTagId testParam = ExifTagId.DateTimeOriginal;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(string), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsString_IfParameterEqualsDateTimeDigitized()
        {
            ExifTagId testParam = ExifTagId.DateTimeDigitized;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(string), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsString_IfParameterEqualsSubSecTime()
        {
            ExifTagId testParam = ExifTagId.SubSecTime;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(string), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsString_IfParameterEqualsSubSecTimeOriginal()
        {
            ExifTagId testParam = ExifTagId.SubSecTimeOriginal;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(string), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsString_IfParameterEqualsSubSecTimeDigitized()
        {
            ExifTagId testParam = ExifTagId.SubSecTimeDigitized;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(string), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsString_IfParameterEqualsImageUniqueId()
        {
            ExifTagId testParam = ExifTagId.ImageUniqueId;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(string), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsString_IfParameterEqualsSpectralSensitivity()
        {
            ExifTagId testParam = ExifTagId.SpectralSensitivity;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(string), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsString_IfParameterEqualsGpsLatitudeRef()
        {
            ExifTagId testParam = ExifTagId.GpsLatitudeRef;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(string), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsString_IfParameterEqualsGpsLongitudeRef()
        {
            ExifTagId testParam = ExifTagId.GpsLongitudeRef;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(string), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsString_IfParameterEqualsGpsSatellites()
        {
            ExifTagId testParam = ExifTagId.GpsSatellites;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(string), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsString_IfParameterEqualsGpsStatus()
        {
            ExifTagId testParam = ExifTagId.GpsStatus;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(string), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsString_IfParameterEqualsGpsMeasureMode()
        {
            ExifTagId testParam = ExifTagId.GpsMeasureMode;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(string), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsString_IfParameterEqualsGpsSpeedRef()
        {
            ExifTagId testParam = ExifTagId.GpsSpeedRef;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(string), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsString_IfParameterEqualsGpsTrackRef()
        {
            ExifTagId testParam = ExifTagId.GpsTrackRef;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(string), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsString_IfParameterEqualsGpsImgDirectionRef()
        {
            ExifTagId testParam = ExifTagId.GpsImgDirectionRef;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(string), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsString_IfParameterEqualsGpsMapDatum()
        {
            ExifTagId testParam = ExifTagId.GpsMapDatum;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(string), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsString_IfParameterEqualsGpsDestLatitudeRef()
        {
            ExifTagId testParam = ExifTagId.GpsDestLatitudeRef;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(string), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsString_IfParameterEqualsGpsDestLongitudeRef()
        {
            ExifTagId testParam = ExifTagId.GpsDestLongitudeRef;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(string), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsString_IfParameterEqualsGpsDestBearingRef()
        {
            ExifTagId testParam = ExifTagId.GpsDestBearingRef;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(string), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsString_IfParameterEqualsGpsDestDistanceRef()
        {
            ExifTagId testParam = ExifTagId.GpsDestDistanceRef;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(string), testOutput);
        }

        [TestMethod]
        public void ExifTagIdExtensionsClass_DataTypeMethod_ReturnsString_IfParameterEqualsGpsDateStamp()
        {
            ExifTagId testParam = ExifTagId.GpsDateStamp;

            Type testOutput = testParam.DataType();

            Assert.AreEqual(typeof(string), testOutput);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

    }
}
