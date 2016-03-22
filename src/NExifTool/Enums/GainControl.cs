using System;


namespace NExifTool.Enums
{
    public class GainControl
        : TagEnum<ushort>
    {
        public static readonly GainControl None = new GainControl(0, "None");
        public static readonly GainControl LowGainUp = new GainControl(1, "Low gain up");
        public static readonly GainControl HighGainUp = new GainControl(2, "High gain up");
        public static readonly GainControl LowGainDown = new GainControl(3, "Low gain down");
        public static readonly GainControl HighGainDown = new GainControl(4, "High gain down");
        public static readonly GainControl Unknown = new GainControl(256, "Unknown");
        
        
        public GainControl(ushort key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static GainControl FromKey(ushort key)
        {
            switch(key)
            {
                case 0: return None;
                case 1: return LowGainUp;
                case 2: return HighGainUp;
                case 3: return LowGainDown;
                case 4: return HighGainDown;
                case 256: return Unknown;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
