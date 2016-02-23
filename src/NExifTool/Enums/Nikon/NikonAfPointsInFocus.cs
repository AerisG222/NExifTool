using System;


namespace NExifTool.Enums.Nikon
{
    public class NikonAfPointsInFocus
        : TagEnum<ushort>
    {
        public static readonly NikonAfPointsInFocus None = new NikonAfPointsInFocus(0, "(none)");
        public static readonly NikonAfPointsInFocus AllElevenPoints = new NikonAfPointsInFocus(0x7ff, "All 11 Points");
        
        
        public NikonAfPointsInFocus(ushort key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static NikonAfPointsInFocus FromKey(ushort key)
        {
            switch(key)
            {
                case 0: return None;
                case 0x7ff: return AllElevenPoints;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
