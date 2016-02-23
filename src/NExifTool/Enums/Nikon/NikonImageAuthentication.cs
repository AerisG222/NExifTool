using System;


namespace NExifTool.Enums.Nikon
{
    public class NikonImageAuthentication
        : TagEnum<byte>
    {
        public static readonly NikonImageAuthentication Off = new NikonImageAuthentication(0, "Off");
        public static readonly NikonImageAuthentication On = new NikonImageAuthentication(1, "On");
        
        
        public NikonImageAuthentication(byte key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static NikonImageAuthentication FromKey(byte key)
        {
            switch(key)
            {
                case 0: return Off;
                case 1: return On;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
