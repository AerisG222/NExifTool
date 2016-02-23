using System;


namespace NExifTool.Enums.Nikon
{
    public class NikonVignetteControl
        : TagEnum<ushort>
    {
        public static readonly NikonVignetteControl Off = new NikonVignetteControl(0, "Off");
        public static readonly NikonVignetteControl Low = new NikonVignetteControl(1, "Low");
        public static readonly NikonVignetteControl Normal = new NikonVignetteControl(3, "Normal");
        public static readonly NikonVignetteControl High = new NikonVignetteControl(5, "High");

        
        public NikonVignetteControl(ushort key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static NikonVignetteControl FromKey(ushort key)
        {
            switch(key)
            {
                case 0: return Off;
                case 1: return Low;
                case 3: return Normal;
                case 5: return High;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
