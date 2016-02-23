using System;


namespace NExifTool.Enums
{
    public class ColorSpace
        : TagEnum<ushort>
    {
        public static readonly ColorSpace sRGB = new ColorSpace(0x1, "sRGB");
        public static readonly ColorSpace AdobeRGB = new ColorSpace(0x2, "Adobe RGB");
        public static readonly ColorSpace WideGamutRGB = new ColorSpace(0xfffd, "Wide Gamut RGB");
        public static readonly ColorSpace ICCProfile = new ColorSpace(0xfffe, "ICC Profile");
        public static readonly ColorSpace Uncalibrated = new ColorSpace(0xffff, "Uncalibrated");
        
        
        public ColorSpace(ushort key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static ColorSpace FromKey(ushort key)
        {
            switch(key)
            {
                case 0x1: return sRGB;
                case 0x2: return AdobeRGB;
                case 0xfffd: return WideGamutRGB;
                case 0xfffe: return ICCProfile;
                case 0xffff: return Uncalibrated;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
