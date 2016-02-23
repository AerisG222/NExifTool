using System;


namespace NExifTool.Enums
{
    public class ProfileHueSatMapEncoding
        : TagEnum<ushort>
    {
        public static readonly ProfileHueSatMapEncoding Linear = new ProfileHueSatMapEncoding(0, "Linear");
        public static readonly ProfileHueSatMapEncoding sRGB = new ProfileHueSatMapEncoding(1, "sRGB");
        
        
        public ProfileHueSatMapEncoding(ushort key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static ProfileHueSatMapEncoding FromKey(ushort key)
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
