using System;


namespace NExifTool.Enums.Nikon
{
    public class NikonHdrSmoothing
        : TagEnum<byte>
    {
        public static readonly NikonHdrSmoothing Off = new NikonHdrSmoothing(0, "Off");
        public static readonly NikonHdrSmoothing Normal = new NikonHdrSmoothing(1, "Normal");
        public static readonly NikonHdrSmoothing Low = new NikonHdrSmoothing(2, "Low");	
        public static readonly NikonHdrSmoothing High = new NikonHdrSmoothing(3, "High");
        public static readonly NikonHdrSmoothing Auto = new NikonHdrSmoothing(48, "Auto");
        public static readonly NikonHdrSmoothing NA = new NikonHdrSmoothing(255, "n/a");

        
        public NikonHdrSmoothing(byte key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static NikonHdrSmoothing FromKey(byte key)
        {
            switch(key)
            {
                case 0: return Off;
                case 1: return Normal;
                case 2: return Low;	
                case 3: return High;
                case 48: return Auto;
                case 255: return NA;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
