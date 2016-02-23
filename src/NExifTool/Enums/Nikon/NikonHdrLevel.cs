using System;


namespace NExifTool.Enums.Nikon
{
    public class NikonHdrLevel
        : TagEnum<byte>
    {
        public static readonly NikonHdrLevel Auto = new NikonHdrLevel(0, "Auto");
        public static readonly NikonHdrLevel OneEv = new NikonHdrLevel(1, "1 EV");
        public static readonly NikonHdrLevel TwoEv = new NikonHdrLevel(2, "2 EV");
        public static readonly NikonHdrLevel ThreeEv = new NikonHdrLevel(3, "3 EV");
        public static readonly NikonHdrLevel NA = new NikonHdrLevel(255, "n/a");

        
        public NikonHdrLevel(byte key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static NikonHdrLevel FromKey(byte key)
        {
            switch(key)
            {
                case 0: return Auto;
                case 1: return OneEv;
                case 2: return TwoEv;
                case 3: return ThreeEv;
                case 255: return NA;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
