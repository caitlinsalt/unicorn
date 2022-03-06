﻿namespace Unicorn.Images.Jpeg
{
    internal enum ExifTagId
    {
        GpsVersionId                = 0x0000,
        GpsLatitudeRef              = 0x0001,
        GpsLatitude                 = 0x0002,
        GpsLongitudeRef             = 0x0003,
        GpsLongitude                = 0x0004,
        GpsAltitudeRef              = 0x0005,
        GpsAltitude                 = 0x0006,
        GpsTimeStamp                = 0x0007,
        GpsSatellites               = 0x0008,
        GpsStatus                   = 0x0009,
        GpsMeasureMode              = 0x000a,
        GpsDOP                      = 0x000b,
        GpsSpeedRef                 = 0x000c,
        GpsSpeed                    = 0x000d,
        GpsTrackRef                 = 0x000e,
        GpsTrack                    = 0x000f,
        GpsImgDirectionRef          = 0x0010,
        GpsImgDirection             = 0x0011,
        GpsMapDatum                 = 0x0012,
        GpsDestLatitudeRef          = 0x0013,
        GpsDestLatitude             = 0x0014,
        GpsDestLongitudeRef         = 0x0015,
        GpsDestLongitude            = 0x0016,
        GpsDestBearingRef           = 0x0017,
        GpsDestBearing              = 0x0018,
        GpsDestDistanceRef          = 0x0019,
        GpsDestDistance             = 0x001a,
        GpsProcessingMethod         = 0x001b,
        GpsAreaInformation          = 0x001c,
        GpsDateStamp                = 0x001d,
        GpsDifferential             = 0x001e,
        ImageWidth                  = 0x0100,
        ImageLength                 = 0x0101,
        BitsPerSample               = 0x0102,
        Compression                 = 0x0103,
        PhotometricInterpretation   = 0x0106,
        ImageDescription            = 0x010e,
        Make                        = 0x010f,
        Model                       = 0x0110,
        StripOffsets                = 0x0111,
        Orientation                 = 0x0112,
        SamplesPerPixel             = 0x0115,
        RowsPerStrip                = 0x0116,
        StripByteCounts             = 0x0117,
        XResolution                 = 0x011a,
        YResolution                 = 0x011b,
        PlanarConfiguration         = 0x011c,
        ResolutionUnit              = 0x0128,
        TransferFunction            = 0x012d,
        Software                    = 0x0131,
        DateTime                    = 0x0132,
        Artist                      = 0x013b,
        WhitePoint                  = 0x013e,
        PrimaryChromaticities       = 0x013f,
        JPEGInterchangeFormat       = 0x0201,
        JPEGInterchangeFormatLength = 0x0202,
        YCbCrCoefficients           = 0x0211,
        YCbCrSubSampling            = 0x0212,
        YCbCrPositioning            = 0x0213,
        ReferenceBlackWhite         = 0x0214,
        Copyright                   = 0x8298,
        ExposureTime                = 0x829a,
        FNumber                     = 0x829d,
        ExifPointer                 = 0x8769,
        ExposureProgram             = 0x8822,
        SpectralSensitivity         = 0x8824,
        GpsPointer                  = 0x8825,
        ISOSpeedRatings             = 0x8827,
        OECF                        = 0x8828,
        ExifVersion                 = 0x9000,
        DateTimeOriginal            = 0x9003,
        DateTimeDigitized           = 0x9004,
        ComponentsConfiguration     = 0x9101,
        CompressedBitsPerPixel      = 0x9102,
        ShutterSpeedValue           = 0x9201,
        ApertureValue               = 0x9202,
        BrightnessValue             = 0x9203,
        ExposureBiasValue           = 0x9204,
        MaxApertureValue            = 0x9205,
        SubjectDistance             = 0x9206,
        MeteringMode                = 0x9207,
        LightSource                 = 0x9208,
        Flash                       = 0x9209,
        FocalLength                 = 0x920a,
        SubjectArea                 = 0x9214,
        MakerNote                   = 0x927c,
        UserComment                 = 0x9286,
        SubSecTime                  = 0x9290,
        SubSecTimeOriginal          = 0x9291,
        SubSecTimeDigitized         = 0x9292,
        FlashpixVersion             = 0xa000,
        ColorSpace                  = 0xa001,
        PixelXDimension             = 0xa002,
        PixelYDimension             = 0xa003,
        RelatedSoundFile            = 0xa004,
        InteroperabilityPointer     = 0xa005,
        FlashEnergy                 = 0xa20b,
        SpatialFrequencyResponse    = 0xa20c,
        FocalPlaneXResolution       = 0xa20e,
        FocalPlaneYResolution       = 0xa20f,
        FocalPlaneResolutionUnit    = 0xa210,
        SubjectLocation             = 0xa214,
        ExposureIndex               = 0xa215,
        SensingMethod               = 0xa217,
        FileSource                  = 0xa300,
        SceneType                   = 0xa301,
        CFAPattern                  = 0xa302,
        CustomRendered              = 0xa401,
        ExposureMode                = 0xa402,
        WhiteBalance                = 0xa403,
        DigitalZoomRatio            = 0xa404,
        FocalLengthIn35mmFilm       = 0xa405,
        SceneCaptureType            = 0xa406,
        GainControl                 = 0xa407,
        Contrast                    = 0xa408,
        Saturation                  = 0xa409,
        Sharpness                   = 0xa40a,
        DeviceSettingDescription    = 0xa40b,
        SubjectDistanceRange        = 0xa40c,
        ImageUniqueId               = 0xa420,
    }
}
