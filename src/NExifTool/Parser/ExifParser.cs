using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using NExifTool;
using NExifTool.Enums;
using NExifTool.Enums.Gps;
using NExifTool.Enums.Nikon;


namespace NExifTool.Parser
{
    public class ExifParser
        : IExifParser
    {
        const string EXIF_TOOL_TAG_NAME = "ExifToolVersion";
        byte _exifToolTagCounter = 0;
        
        
        bool IsNumericSection
        {
            get
            {
                return _exifToolTagCounter > 1;
            }
        }
        
        
        public virtual IList<Tag> ParseTags(StreamReader reader)
        {
            var list = new List<Tag>();
            
            foreach(var pi in GetParseInfo(reader))
            {
                list.Add(BuildTag(pi));
            }
            
            return list;
        }
        
                
        IEnumerable<ParseInfo> GetParseInfo(StreamReader reader)
        {
            var doc = XDocument.Load(reader);
            XNamespace nsRdf = "http://www.w3.org/1999/02/22-rdf-syntax-ns#";
            XNamespace nsEt = "http://ns.exiftool.ca/1.0/";
            var tags = new Dictionary<string, ParseInfo>();
            var els = doc.Element(nsRdf + "RDF").Element(nsRdf + "Description");
            
            foreach(var el in els.Elements())
            {
                if(string.Equals(el.Name.LocalName, EXIF_TOOL_TAG_NAME, StringComparison.OrdinalIgnoreCase))
                {
                    _exifToolTagCounter++;
                }
                
                var tableName = el.Attribute(nsEt + "table").Value;
                var tagId = el.Attribute(nsEt + "id").Value;
                var val = el.Value;
                var key = TagInfo.GenerateLookupKey(tableName, tagId);
                    
                if(!IsNumericSection)
                {
                    tags[key] = new ParseInfo {
                        TableName = tableName,
                        TagId = tagId,
                        Value = val
                    };
                }
                else
                {
                    if(tags.ContainsKey(key))
                    {
                        tags[key].NumberValue = val;
                    }
                    else
                    {
                        tags[key] = new ParseInfo {
                            TableName = tableName,
                            TagId = tagId,
                            NumberValue = val
                        };
                    }
                }
            }
            
            return tags.Values;
        }
        
                
        TagInfo GetTagInfo(string tableName, string tagId)
        {
            var key = TagInfo.GenerateLookupKey(tableName, tagId);
            
            if(ExifToolLookup.Details.ContainsKey(key))
            {
                return ExifToolLookup.Details[key];
            }
            else
            {
                return new TagInfo { TableName = tableName, Id = tagId };
            }
        }
        
        
        Tag BuildTag(ParseInfo pi)
        {
            var ti = GetTagInfo(pi.TableName, pi.TagId);
            var tag = CreateSpecificTag(ti, pi.NumberValue);
            
            tag.TagInfo = ti;
            tag.Value = pi.Value;
            tag.NumberValue = pi.NumberValue;
            
            return tag;
        }
        
        
        Tag CreateSpecificTag(TagInfo info, string numberValue)
        {
            try
            {
                if(info.IsGps)
                {
                    switch(info.Name.ToLower())
                    {
                        case "gpslatituderef":
                            return new Tag<GpsLatitudeRef> { TypedValue = GpsLatitudeRef.FromKey(numberValue) };
                        case "gpslongituderef":
                            return new Tag<GpsLongitudeRef> { TypedValue = GpsLongitudeRef.FromKey(numberValue) };
                        case "gpsaltituderef":
                            return new Tag<GpsAltitudeRef> { TypedValue = GpsAltitudeRef.FromKey(byte.Parse(numberValue)) };
                        case "gpsstatus":
                            return new Tag<GpsStatus> { TypedValue = GpsStatus.FromKey(numberValue) };
                        case "gpsmeasuremode":
                            return new Tag<GpsMeasureMode> { TypedValue = GpsMeasureMode.FromKey(numberValue) };
                        case "gpsspeedref":
                            return new Tag<GpsSpeedRef> { TypedValue = GpsSpeedRef.FromKey(numberValue) };
                        case "gpstrackref":
                            return new Tag<GpsTrackRef> { TypedValue = GpsTrackRef.FromKey(numberValue) };
                        case "gpsimgdirectionref":
                            return new Tag<GpsImgDirectionRef> { TypedValue = GpsImgDirectionRef.FromKey(numberValue) };
                        case "gpsdestlatituderef":
                            return new Tag<GpsDestLatitudeRef> { TypedValue = GpsDestLatitudeRef.FromKey(numberValue) };
                        case "gpsdestlongituderef":
                            return new Tag<GpsDestLongitudeRef> { TypedValue = GpsDestLongitudeRef.FromKey(numberValue) };
                        case "gpsdestbearingref":
                            return new Tag<GpsDestBearingRef> { TypedValue = GpsDestBearingRef.FromKey(numberValue) };
                        case "gpsdestdistanceref":
                            return new Tag<GpsDestDistanceRef> { TypedValue = GpsDestDistanceRef.FromKey(numberValue) };
                        case "gpsdifferential":
                            return new Tag<GpsDifferential> { TypedValue = GpsDifferential.FromKey(ushort.Parse(numberValue)) };
                    }
                }
                
                if(info.IsNikon)
                {
                    switch(info.Name.ToLower())
                    {
                        case "colorspace":
                            return new Tag<NikonColorSpace> { TypedValue = NikonColorSpace.FromKey(ushort.Parse(numberValue)) };
                        case "vibrationreduction":
                            return new Tag<NikonVibrationReduction> { TypedValue = NikonVibrationReduction.FromKey(byte.Parse(numberValue)) };
                        case "vrmode":
                            return new Tag<NikonVRMode> { TypedValue = NikonVRMode.FromKey(byte.Parse(numberValue)) };
                        case "imageauthentication":
                            return new Tag<NikonImageAuthentication> { TypedValue = NikonImageAuthentication.FromKey(byte.Parse(numberValue)) };
                        case "actived-lighting":
                            return new Tag<NikonActiveDLighting> { TypedValue = NikonActiveDLighting.FromKey(ushort.Parse(numberValue)) };
                        case "picturecontroladjust":
                            return new Tag<NikonPictureControlAdjust> { TypedValue = NikonPictureControlAdjust.FromKey(byte.Parse(numberValue)) };
                        case "filtereffect":
                            return new Tag<NikonFilterEffect> { TypedValue = NikonFilterEffect.FromKey(byte.Parse(numberValue)) };
                        case "toningeffect":
                            return new Tag<NikonToningEffect> { TypedValue = NikonToningEffect.FromKey(byte.Parse(numberValue)) };
                        case "daylightsavings":
                            return new Tag<NikonDaylightSavings> { TypedValue = NikonDaylightSavings.FromKey(byte.Parse(numberValue)) };
                        case "datedisplayformat":
                            return new Tag<NikonDateDisplayFormat> { TypedValue = NikonDateDisplayFormat.FromKey(byte.Parse(numberValue)) };
                        case "isoexpansion":
                            return new Tag<NikonIsoExpansion> { TypedValue = NikonIsoExpansion.FromKey(ushort.Parse(numberValue)) };
                        case "isoexpansion2":
                            return new Tag<NikonIsoExpansion2> { TypedValue = NikonIsoExpansion2.FromKey(ushort.Parse(numberValue)) };
                        case "vignettecontrol":
                            return new Tag<NikonVignetteControl> { TypedValue = NikonVignetteControl.FromKey(ushort.Parse(numberValue)) };
                        case "autodistortioncontrol":
                            return new Tag<NikonAutoDistortionControl> { TypedValue = NikonAutoDistortionControl.FromKey(byte.Parse(numberValue)) };
                        case "hdr":
                            return new Tag<NikonHdr> { TypedValue = NikonHdr.FromKey(byte.Parse(numberValue)) };
                        case "hdrlevel":
                            return new Tag<NikonHdrLevel> { TypedValue = NikonHdrLevel.FromKey(byte.Parse(numberValue)) };
                        case "hdrsmoothing":
                            return new Tag<NikonHdrSmoothing> { TypedValue = NikonHdrSmoothing.FromKey(byte.Parse(numberValue)) };
                        case "hdrlevel2":
                            return new Tag<NikonHdrLevel2> { TypedValue = NikonHdrLevel2.FromKey(byte.Parse(numberValue)) };
                        case "textencoding":
                            return new Tag<NikonTextEncoding> { TypedValue = NikonTextEncoding.FromKey(byte.Parse(numberValue)) };
                        case "flashmode":
                            return new Tag<NikonFlashMode> { TypedValue = NikonFlashMode.FromKey(byte.Parse(numberValue)) };
                        case "afareamode":
                            return new Tag<NikonAfAreaMode> { TypedValue = NikonAfAreaMode.FromKey(byte.Parse(numberValue)) };
                        case "afpoint":
                            return new Tag<NikonAfPoint> { TypedValue = NikonAfPoint.FromKey(byte.Parse(numberValue)) };
                        case "afpointsinfocus":
                            return new Tag<NikonAfPointsInFocus> { TypedValue = NikonAfPointsInFocus.FromKey(ushort.Parse(numberValue)) };
                        case "nefcompression":
                            return new Tag<NikonNefCompression> { TypedValue = NikonNefCompression.FromKey(ushort.Parse(numberValue)) };
                        case "retouchhistory":
                            return new Tag<NikonRetouchHistory> { TypedValue = NikonRetouchHistory.FromKey(ushort.Parse(numberValue)) };
                        case "flashsource":
                            return new Tag<NikonFlashSource> { TypedValue = NikonFlashSource.FromKey(byte.Parse(numberValue)) };
                        case "flashcolorfilter":
                            return new Tag<NikonFlashColorFilter> { TypedValue = NikonFlashColorFilter.FromKey(byte.Parse(numberValue)) };
                        case "highisonoisereduction":
                            return new Tag<NikonHighIsoNoiseReduction> { TypedValue = NikonHighIsoNoiseReduction.FromKey(ushort.Parse(numberValue)) };
                    }
                }
                
                if(info.IsExif)
                {
                    switch(info.Name.ToLower())
                    {
                        case "interopindex":
                            return new Tag<InteropIndex> { TypedValue = InteropIndex.FromKey(numberValue) };
                        case "subfiletype":
                            return new Tag<SubfileType> { TypedValue = SubfileType.FromKey(uint.Parse(numberValue)) };
                        case "oldsubfiletype":
                            return new Tag<OldSubfileType> { TypedValue = OldSubfileType.FromKey(ushort.Parse(numberValue)) };
                        case "compression":
                            return new Tag<Compression> { TypedValue = Compression.FromKey(ushort.Parse(numberValue)) };
                        case "photometricinterpretation":
                            return new Tag<PhotometricInterpretation> { TypedValue = PhotometricInterpretation.FromKey(ushort.Parse(numberValue)) };
                        case "thresholding":
                            return new Tag<Thresholding> { TypedValue = Thresholding.FromKey(ushort.Parse(numberValue)) };
                        case "fillorder":
                            return new Tag<FillOrder> { TypedValue = FillOrder.FromKey(ushort.Parse(numberValue)) };
                        case "orientation":
                            return new Tag<Orientation> { TypedValue = Orientation.FromKey(ushort.Parse(numberValue)) };
                        case "planarconfiguration":
                            return new Tag<PlanarConfiguration> { TypedValue = PlanarConfiguration.FromKey(ushort.Parse(numberValue)) };
                        case "grayresponseunit":
                            return new Tag<GrayResponseUnit> { TypedValue = GrayResponseUnit.FromKey(ushort.Parse(numberValue)) };
                        case "resolutionunit":
                            return new Tag<ResolutionUnit> { TypedValue = ResolutionUnit.FromKey(ushort.Parse(numberValue)) };
                        case "predictor":
                            return new Tag<Predictor> { TypedValue = Predictor.FromKey(ushort.Parse(numberValue)) };
                        case "cleanfaxdata":
                            return new Tag<CleanFaxData> { TypedValue = CleanFaxData.FromKey(ushort.Parse(numberValue)) };
                        case "inkset":
                            return new Tag<InkSet> { TypedValue = InkSet.FromKey(ushort.Parse(numberValue)) };
                        case "extrasamples":
                            return new Tag<ExtraSamples> { TypedValue = ExtraSamples.FromKey(ushort.Parse(numberValue)) };
                        case "sampleformat":
                            return new Tag<SampleFormat> { TypedValue = SampleFormat.FromKey(ushort.Parse(numberValue)) };
                        case "indexed":
                            return new Tag<Indexed> { TypedValue = Indexed.FromKey(ushort.Parse(numberValue)) };
                        case "opiproxy":
                            return new Tag<OpiProxy> { TypedValue = OpiProxy.FromKey(ushort.Parse(numberValue)) };
                        case "profiletype":    
                            return new Tag<ProfileType> { TypedValue = ProfileType.FromKey(ushort.Parse(numberValue)) };
                        case "faxprofile":
                            return new Tag<FaxProfile> { TypedValue = FaxProfile.FromKey(ushort.Parse(numberValue)) };
                        case "jpegproc":
                            return new Tag<JpegProc> { TypedValue = JpegProc.FromKey(ushort.Parse(numberValue)) };
                        case "ycbcrsubsampling":
                            return new Tag<YCbCrSubSampling> { TypedValue = YCbCrSubSampling.FromKey(numberValue) };
                        case "ycbcrpositioning":
                            return new Tag<YCbCrPositioning> { TypedValue = YCbCrPositioning.FromKey(ushort.Parse(numberValue)) };
                        case "sonyrawfiletype":
                            return new Tag<SonyRawFileType> { TypedValue = SonyRawFileType.FromKey(ushort.Parse(numberValue)) };
                        case "rasterpadding":
                            return new Tag<RasterPadding> { TypedValue = RasterPadding.FromKey(ushort.Parse(numberValue)) };
                        case "imagecolorindicator":
                            return new Tag<ImageColorIndicator> { TypedValue = ImageColorIndicator.FromKey(ushort.Parse(numberValue)) };
                        case "backgroundcolorindicator":
                            return new Tag<BackgroundColorIndicator> { TypedValue = BackgroundColorIndicator.FromKey(ushort.Parse(numberValue)) };
                        case "hcusage":
                            return new Tag<HCUsage> { TypedValue = HCUsage.FromKey(ushort.Parse(numberValue)) };
                        case "exposureprogram":
                            return new Tag<ExposureProgram> { TypedValue = ExposureProgram.FromKey(ushort.Parse(numberValue)) };
                        case "sensitivitytype":
                            return new Tag<SensitivityType> { TypedValue = SensitivityType.FromKey(ushort.Parse(numberValue)) };
                        case "componentsconfiguration":
                            return new Tag<ComponentsConfiguration> { TypedValue = ComponentsConfiguration.FromKey(ushort.Parse(numberValue)) };
                        case "meteringmode":
                            return new Tag<MeteringMode> { TypedValue = MeteringMode.FromKey(ushort.Parse(numberValue)) };
                        case "lightsource":
                        case "calibrationilluminant1":
                        case "calibrationilluminant2":
                            return new Tag<LightSource> { TypedValue = LightSource.FromKey(ushort.Parse(numberValue)) };
                        case "flash":
                            return new Tag<FlashValue> { TypedValue = FlashValue.FromKey(ushort.Parse(numberValue)) };
                        case "focalplaneresolutionunit":
                            return new Tag<FocalPlaneResolutionUnit> { TypedValue = FocalPlaneResolutionUnit.FromKey(ushort.Parse(numberValue)) };
                        case "securityclassification":
                            return new Tag<SecurityClassification> { TypedValue = SecurityClassification.FromKey(numberValue) };
                        case "sensingmethod":
                            return new Tag<SensingMethod> { TypedValue = SensingMethod.FromKey(ushort.Parse(numberValue)) };
                        case "colorspace":
                            return new Tag<ColorSpace> { TypedValue = ColorSpace.FromKey(ushort.Parse(numberValue)) };
                        case "filesource":
                            return new Tag<FileSource> { TypedValue = FileSource.FromKey(ushort.Parse(numberValue)) };
                        case "scenetype":
                            return new Tag<SceneType> { TypedValue = SceneType.FromKey(ushort.Parse(numberValue)) };
                        case "customrendered":
                            return new Tag<CustomRendered> { TypedValue = CustomRendered.FromKey(ushort.Parse(numberValue)) };
                        case "exposuremode":
                            return new Tag<ExposureMode> { TypedValue = ExposureMode.FromKey(ushort.Parse(numberValue)) };
                        case "whitebalance":
                            return new Tag<WhiteBalance> { TypedValue = WhiteBalance.FromKey(ushort.Parse(numberValue)) };
                        case "scenecapturetype":
                            return new Tag<SceneCaptureType> { TypedValue = SceneCaptureType.FromKey(ushort.Parse(numberValue)) };
                        case "gaincontrol":
                            return new Tag<GainControl> { TypedValue = GainControl.FromKey(ushort.Parse(numberValue)) };
                        case "contrast":
                            return new Tag<Contrast> { TypedValue = Contrast.FromKey(ushort.Parse(numberValue)) };    
                        case "saturation":
                            return new Tag<Saturation> { TypedValue = Saturation.FromKey(ushort.Parse(numberValue)) };
                        case "sharpness":
                            return new Tag<Sharpness> { TypedValue = Sharpness.FromKey(ushort.Parse(numberValue)) };
                        case "subjectdistancerange":
                            return new Tag<SubjectDistanceRange> { TypedValue = SubjectDistanceRange.FromKey(ushort.Parse(numberValue)) };
                        case "pixelformat":
                            return new Tag<PixelFormat> { TypedValue = PixelFormat.FromKey(ushort.Parse(numberValue)) };
                        case "transformation":
                            return new Tag<Transformation> { TypedValue = Transformation.FromKey(ushort.Parse(numberValue)) };
                        case "uncompressed":
                            return new Tag<Uncompressed> { TypedValue = Uncompressed.FromKey(ushort.Parse(numberValue)) };
                        case "imagedatadiscard":
                            return new Tag<ImageDataDiscard> { TypedValue = ImageDataDiscard.FromKey(ushort.Parse(numberValue)) };
                        case "alphadatadiscard":
                            return new Tag<AlphaDataDiscard> { TypedValue = AlphaDataDiscard.FromKey(ushort.Parse(numberValue)) };
                        case "usptooriginalcontenttype":
                            return new Tag<USPTOOriginalContentType> { TypedValue = USPTOOriginalContentType.FromKey(ushort.Parse(numberValue)) };
                        case "cfalayout":
                            return new Tag<CFALayout> { TypedValue = CFALayout.FromKey(ushort.Parse(numberValue)) };
                        case "makernotesafety":
                            return new Tag<MakerNoteSafety> { TypedValue = MakerNoteSafety.FromKey(ushort.Parse(numberValue)) };
                        case "profileembedpolicy":
                            return new Tag<ProfileEmbedPolicy> { TypedValue = ProfileEmbedPolicy.FromKey(ushort.Parse(numberValue)) };
                        case "previewcolorspace":
                            return new Tag<PreviewColorSpace> { TypedValue = PreviewColorSpace.FromKey(ushort.Parse(numberValue)) };
                        case "profilehuesatmapencoding":
                            return new Tag<ProfileHueSatMapEncoding> { TypedValue = ProfileHueSatMapEncoding.FromKey(ushort.Parse(numberValue)) };
                        case "profilelooktableencoding":
                            return new Tag<ProfileLookTableEncoding> { TypedValue = ProfileLookTableEncoding.FromKey(ushort.Parse(numberValue)) };
                        case "defaultblackrender":
                            return new Tag<DefaultBlackRender> { TypedValue = DefaultBlackRender.FromKey(ushort.Parse(numberValue)) };
                    }
                }
                
                // ---- VALUE TAG ----
                if(string.IsNullOrEmpty(info.ValueType))
                {
                    return new Tag();
                }
                
                switch(info.ValueType.ToLower())
                {
                    case "int8u":
                        return new Tag<byte> { TypedValue = byte.Parse(numberValue) };
                    case "int8s":
                        return new Tag<sbyte> { TypedValue = sbyte.Parse(numberValue) };
                    case "int16u": 
                        return new Tag<ushort> { TypedValue = ushort.Parse(numberValue) };
                    case "int16s":
                        return new Tag<short> { TypedValue = short.Parse(numberValue) };
                    case "int32u":
                        return new Tag<uint> { TypedValue = uint.Parse(numberValue) };
                    case "integer":
                    case "int32s":
                        return new Tag<int> { TypedValue = int.Parse(numberValue) };
                    case "int64u":
                        return new Tag<ulong> { TypedValue = ulong.Parse(numberValue) };
                    case "int64s":
                        return new Tag<long> { TypedValue = long.Parse(numberValue) };
                    case "float":
                    case "rational32s":
                    case "rational32u":
                        return new Tag<float> { TypedValue = float.Parse(numberValue) };
                    case "double":
                    case "rational":
                    case "rational64s":
                    case "rational64u":
                    case "real":
                        return new Tag<double> { TypedValue = double.Parse(numberValue) };
                    case "boolean":
                        return new Tag<bool> { TypedValue = bool.Parse(numberValue) };
                }
            }
            catch
            {
                // there are some entries that are listed as whole numbers, but are actually fractions.  lets try to parse those here as a fallback
                //try
                //{
                //    return new Tag<double> { TypedValue = double.Parse(numberValue) };
                //}
                //catch
                //{
                    // we tried our best, just print a note for now about the error
                    Console.WriteLine($"error converting {info.TableName}::{info.Id}.  Expected type: {info.ValueType} but got value: {numberValue}");
                //}
            }
            
            return new Tag();
        }
    } 
}
