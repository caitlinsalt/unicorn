﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Unicorn.Images {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class ImageLoadResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ImageLoadResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Unicorn.Images.ImageLoadResources", typeof(ImageLoadResources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid EXIF image.  The EXIF header has an incorrect format (magic answer bytes not found)..
        /// </summary>
        internal static string ExifSegment_AnswerToEverythingNotFound {
            get {
                return ResourceManager.GetString("ExifSegment_AnswerToEverythingNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid EXIF image.  The EXIF header has an incorrect format (endianness bytes not found)..
        /// </summary>
        internal static string ExifSegment_EndiannessMarkerNotFound {
            get {
                return ResourceManager.GetString("ExifSegment_EndiannessMarkerNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid EXIF image.  Invalid EXIF tag data type found..
        /// </summary>
        internal static string ExifSegment_ImpossibleTagDataType {
            get {
                return ResourceManager.GetString("ExifSegment_ImpossibleTagDataType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid EXIF image.  The EXIF data does not match the specification.  Type mismatch in tag {0}.  Expected type was {1}; found type {2}..
        /// </summary>
        internal static string ExifSegment_WrongTagDataType {
            get {
                return ResourceManager.GetString("ExifSegment_WrongTagDataType", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid JPEG image.  Frame header is not long enough to contain image dimensions..
        /// </summary>
        internal static string JpegSourceImage_DimensionsNotFound {
            get {
                return ResourceManager.GetString("JpegSourceImage_DimensionsNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid JPEG image.  JFIF data block does not contain image resolution data..
        /// </summary>
        internal static string JpegSourceImage_ErrorReadingJFIFData {
            get {
                return ResourceManager.GetString("JpegSourceImage_ErrorReadingJFIFData", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid JPEG image.  Could not find Start Of Frame marker..
        /// </summary>
        internal static string JpegSourceImage_SofNotFound {
            get {
                return ResourceManager.GetString("JpegSourceImage_SofNotFound", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid JPEG image.  Data does not begin with Start Of Image marker..
        /// </summary>
        internal static string JpegSourceImage_SoiNotFound {
            get {
                return ResourceManager.GetString("JpegSourceImage_SoiNotFound", resourceCulture);
            }
        }
    }
}
