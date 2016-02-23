using System;


namespace NExifTool.Enums
{
    public class ImageColorIndicator
        : TagEnum<ushort>
    {
        public static readonly ImageColorIndicator Unspecified = new ImageColorIndicator(0, "Unspecified Image Color");
        public static readonly ImageColorIndicator Specified = new ImageColorIndicator(1, "Specified Image Color");
        
        
        public ImageColorIndicator(ushort key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static ImageColorIndicator FromKey(ushort key)
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
