using System;


namespace NExifTool.Enums
{
    public class BackgroundColorIndicator
        : TagEnum<ushort>
    {
        public static readonly BackgroundColorIndicator Unspecified = new BackgroundColorIndicator(0, "Unspecified Background Color");
        public static readonly BackgroundColorIndicator Specified = new BackgroundColorIndicator(1, "Specified Background Color");
        
        
        public BackgroundColorIndicator(ushort key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static BackgroundColorIndicator FromKey(ushort key)
        {
            switch(key)
            {
                case 0: return Unspecified;
                case 1: return Specified;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
