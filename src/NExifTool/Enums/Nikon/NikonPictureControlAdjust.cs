using System;


namespace NExifTool.Enums.Nikon
{
    public class NikonPictureControlAdjust
        : TagEnum<byte>
    {
        public static readonly NikonPictureControlAdjust Default = new NikonPictureControlAdjust(0, "DefaultSettings");
        public static readonly NikonPictureControlAdjust QuickAdjust = new NikonPictureControlAdjust(1, "Quick Adjust");
        public static readonly NikonPictureControlAdjust FullControl = new NikonPictureControlAdjust(2, "Full Control");
        
        
        public NikonPictureControlAdjust(byte key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static NikonPictureControlAdjust FromKey(byte key)
        {
            switch(key)
            {
                case 0: return Default;
                case 1: return QuickAdjust;
                case 2: return FullControl;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
