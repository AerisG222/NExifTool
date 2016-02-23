using System;


namespace NExifTool.Enums.Nikon
{
    public class NikonHighIsoNoiseReduction
        : TagEnum<ushort>
    {
        public static readonly NikonHighIsoNoiseReduction Off = new NikonHighIsoNoiseReduction(0, "Off");
        public static readonly NikonHighIsoNoiseReduction Minimal = new NikonHighIsoNoiseReduction(1, "Minimal");
        public static readonly NikonHighIsoNoiseReduction Low = new NikonHighIsoNoiseReduction(2, "Low");
        public static readonly NikonHighIsoNoiseReduction MediumLow = new NikonHighIsoNoiseReduction(3, "Medium Low");	   	
        public static readonly NikonHighIsoNoiseReduction Normal = new NikonHighIsoNoiseReduction(4, "Normal");
        public static readonly NikonHighIsoNoiseReduction MediumHigh = new NikonHighIsoNoiseReduction(5, "Medium High");
        public static readonly NikonHighIsoNoiseReduction High = new NikonHighIsoNoiseReduction(6, "High");

        
        public NikonHighIsoNoiseReduction(ushort key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static NikonHighIsoNoiseReduction FromKey(ushort key)
        {
            switch(key)
            {
                case 0: return Off;
                case 1: return Minimal;
                case 2: return Low;
                case 3: return MediumLow;	   	
                case 4: return Normal;
                case 5: return MediumHigh;
                case 6: return High;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
