using System;


namespace NExifTool.Enums.Nikon
{
    public class NikonFlashSource
        : TagEnum<byte>
    {
        public static readonly NikonFlashSource None = new NikonFlashSource(0, "None");
        public static readonly NikonFlashSource External = new NikonFlashSource(1, "External");
        public static readonly NikonFlashSource Internal = new NikonFlashSource(2, "Internal");
        
        
        public NikonFlashSource(byte key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static NikonFlashSource FromKey(byte key)
        {
            switch(key)
            {
                case 0: return None;
                case 1: return External;
                case 2: return Internal;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
