using System;


namespace NExifTool.Enums.Nikon
{
    public class NikonAutoDistortionControl
        : TagEnum<byte>
    {
        public static readonly NikonAutoDistortionControl Off = new NikonAutoDistortionControl(0, "Off");
        public static readonly NikonAutoDistortionControl On = new NikonAutoDistortionControl(1, "On");
        public static readonly NikonAutoDistortionControl OnUnderwater = new NikonAutoDistortionControl(2, "On (underwater)");
        
        
        public NikonAutoDistortionControl(byte key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static NikonAutoDistortionControl FromKey(byte key)
        {
            switch(key)
            {
                case 0: return Off;
                case 1: return On;
                case 2: return OnUnderwater;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
