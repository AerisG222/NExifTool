using System;


namespace NExifTool.Enums.Nikon
{
    public class NikonColorSpace
        : TagEnum<ushort>
    {
        public static readonly NikonColorSpace sRGB = new NikonColorSpace(1, "sRGB");
        public static readonly NikonColorSpace AdobeRGB = new NikonColorSpace(2, "AdobeRGB");
        
        
        public NikonColorSpace(ushort key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static NikonColorSpace FromKey(ushort key)
        {
            switch(key)
            {
                case 1: return sRGB;
                case 2: return AdobeRGB;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
