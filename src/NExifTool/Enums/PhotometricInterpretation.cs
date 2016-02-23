using System;


namespace NExifTool.Enums
{
    public class PhotometricInterpretation
        : TagEnum<ushort>
    {
        public static readonly PhotometricInterpretation WhiteIsZero = new PhotometricInterpretation(0, "WhiteIsZero");
        public static readonly PhotometricInterpretation BlackIsZero = new PhotometricInterpretation(1, "BlackIsZero");
        public static readonly PhotometricInterpretation RGB = new PhotometricInterpretation(2, "RGB");
        public static readonly PhotometricInterpretation RGBPalette = new PhotometricInterpretation(3, "RGB Palette");
        public static readonly PhotometricInterpretation TransparencyMask = new PhotometricInterpretation(4, "Transparency Mask");
        public static readonly PhotometricInterpretation CMYK = new PhotometricInterpretation(5, "CMYK");
        public static readonly PhotometricInterpretation YCbCr = new PhotometricInterpretation(6, "YCbCr");
        public static readonly PhotometricInterpretation CIELab = new PhotometricInterpretation(8, "CIELab");
        public static readonly PhotometricInterpretation ICCLab = new PhotometricInterpretation(9, "ICCLab");
        public static readonly PhotometricInterpretation ITULab = new PhotometricInterpretation(10, "ITULab");
        public static readonly PhotometricInterpretation ColorFilterArray = new PhotometricInterpretation(32803, "Color Filter Array");
        public static readonly PhotometricInterpretation PixarLogL = new PhotometricInterpretation(32844, "Pixar LogL");
        public static readonly PhotometricInterpretation PixarLogLuv = new PhotometricInterpretation(32845, "Pixar LogLuv");
        public static readonly PhotometricInterpretation LinearRaw = new PhotometricInterpretation(34892, "Linear Raw");
        
        
        public PhotometricInterpretation(ushort key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static PhotometricInterpretation FromKey(ushort key)
        {
            switch(key)
            {
                case 0: return WhiteIsZero;
                case 1: return BlackIsZero;
                case 2: return RGB;
                case 3: return RGBPalette;
                case 4: return TransparencyMask;
                case 5: return CMYK;
                case 6: return YCbCr;
                case 8: return CIELab;
                case 9: return ICCLab;
                case 10: return ITULab;
                case 32803: return ColorFilterArray;
                case 32844: return PixarLogL;
                case 32845: return PixarLogLuv;
                case 34892: return LinearRaw;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
