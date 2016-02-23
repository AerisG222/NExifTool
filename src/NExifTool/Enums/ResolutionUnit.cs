using System;


namespace NExifTool.Enums
{
    public class ResolutionUnit
        : TagEnum<ushort>
    {
        public static readonly ResolutionUnit None = new ResolutionUnit(1, "None");
        public static readonly ResolutionUnit Inches = new ResolutionUnit(2, "inches");
        public static readonly ResolutionUnit Centimeters = new ResolutionUnit(3, "cm");
        
        
        public ResolutionUnit(ushort key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static ResolutionUnit FromKey(ushort key)
        {
            switch(key)
            {
                case 1: return None;
                case 2: return Inches;
                case 3: return Centimeters;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
