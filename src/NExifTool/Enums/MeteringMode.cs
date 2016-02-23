using System;


namespace NExifTool.Enums
{
    public class MeteringMode
        : TagEnum<ushort>
    {
        public static readonly MeteringMode Unknown = new MeteringMode(0, "Unknown");
        public static readonly MeteringMode Average = new MeteringMode(1, "Average");
        public static readonly MeteringMode CenterWeightedAverage = new MeteringMode(2, "Center-weighted average");
        public static readonly MeteringMode Spot = new MeteringMode(3, "Spot");
        public static readonly MeteringMode MultiSpot = new MeteringMode(4, "Multi-spot");
        public static readonly MeteringMode MultiSegment = new MeteringMode(5, "Multi-segment");
        public static readonly MeteringMode Partial = new MeteringMode(6, "Partial");
        public static readonly MeteringMode Other = new MeteringMode(255, "Other");
        
        
        public MeteringMode(ushort key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static MeteringMode FromKey(ushort key)
        {
            switch(key)
            {
                case 0: return Unknown;
                case 1: return Average;
                case 2: return CenterWeightedAverage;
                case 3: return Spot;
                case 4: return MultiSpot;
                case 5: return MultiSegment;
                case 6: return Partial;
                case 255: return Other;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
