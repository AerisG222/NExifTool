using System;


namespace NExifTool.Enums.Nikon
{
    public class NikonHdr
        : TagEnum<byte>
    {
        public static readonly NikonHdr Off = new NikonHdr(0, "Off");
        public static readonly NikonHdr On = new NikonHdr(1, "On");
        public static readonly NikonHdr Auto = new NikonHdr(48, "Auto");
        
        
        public NikonHdr(byte key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static NikonHdr FromKey(byte key)
        {
            switch(key)
            {
                case 0: return Off;
                case 1: return On;
                case 48: return Auto;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
