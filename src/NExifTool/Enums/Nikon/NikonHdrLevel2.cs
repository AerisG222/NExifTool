using System;


namespace NExifTool.Enums.Nikon
{
    public class NikonHdrLevel2
        : TagEnum<byte>
    {
        public static readonly NikonHdrLevel2 Auto = new NikonHdrLevel2(0, "Auto");
        public static readonly NikonHdrLevel2 OneEv = new NikonHdrLevel2(1, "1 EV");
        public static readonly NikonHdrLevel2 TwoEv = new NikonHdrLevel2(2, "2 EV");
        public static readonly NikonHdrLevel2 ThreeEv = new NikonHdrLevel2(3, "3 EV");
        public static readonly NikonHdrLevel2 NA = new NikonHdrLevel2(255, "n/a");

        
        public NikonHdrLevel2(byte key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static NikonHdrLevel2 FromKey(byte key)
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
