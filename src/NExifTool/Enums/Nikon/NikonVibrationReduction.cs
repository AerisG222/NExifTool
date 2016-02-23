using System;


namespace NExifTool.Enums.Nikon
{
    public class NikonVibrationReduction
        : TagEnum<byte>
    {
        public static readonly NikonVibrationReduction NA = new NikonVibrationReduction(0, "n/a");
        public static readonly NikonVibrationReduction On = new NikonVibrationReduction(1, "On");
        public static readonly NikonVibrationReduction Off = new NikonVibrationReduction(2, "Off");
        
        
        public NikonVibrationReduction(byte key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static NikonVibrationReduction FromKey(byte key)
        {
            switch(key)
            {
                case 0: return NA;
                case 1: return On;
                case 2: return Off;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
