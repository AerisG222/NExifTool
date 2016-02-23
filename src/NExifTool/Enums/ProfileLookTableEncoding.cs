using System;


namespace NExifTool.Enums
{
    public class ProfileLookTableEncoding
        : TagEnum<ushort>
    {
        public static readonly ProfileLookTableEncoding Linear = new ProfileLookTableEncoding(0, "Linear");
        public static readonly ProfileLookTableEncoding sRGB = new ProfileLookTableEncoding(1, "sRGB");
        
        
        public ProfileLookTableEncoding(ushort key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static ProfileLookTableEncoding FromKey(ushort key)
        {
            switch(key)
            {
                case 0: return Linear;
                case 1: return sRGB;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
