using System;


namespace NExifTool.Enums
{
    public class PreviewColorSpace
        : TagEnum<ushort>
    {
        public static readonly PreviewColorSpace Unknown = new PreviewColorSpace(0, "Unknown");
        public static readonly PreviewColorSpace GrayGamma22 = new PreviewColorSpace(1, "Gray Gamma 2.2");
        public static readonly PreviewColorSpace sRGB = new PreviewColorSpace(2, "sRGB");
        public static readonly PreviewColorSpace AdobeRGB = new PreviewColorSpace(3, "Adobe RGB");
        public static readonly PreviewColorSpace ProPhotoRGB = new PreviewColorSpace(4, "ProPhoto RGB");

        
        public PreviewColorSpace(ushort key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static PreviewColorSpace FromKey(ushort key)
        {
            switch(key)
            {
                case 0: return Unknown;
                case 1: return GrayGamma22;
                case 2: return sRGB;
                case 3: return AdobeRGB;
                case 4: return ProPhotoRGB;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
