using System;


namespace NExifTool.Enums
{
    public class FocalPlaneResolutionUnit
        : TagEnum<ushort>
    {
        public static readonly FocalPlaneResolutionUnit None = new FocalPlaneResolutionUnit(1, "None");
        public static readonly FocalPlaneResolutionUnit Inches = new FocalPlaneResolutionUnit(2, "inches");
        public static readonly FocalPlaneResolutionUnit Centimeters = new FocalPlaneResolutionUnit(3, "cm");
        public static readonly FocalPlaneResolutionUnit Millimeters = new FocalPlaneResolutionUnit(4, "mm");
        public static readonly FocalPlaneResolutionUnit Micrometers = new FocalPlaneResolutionUnit(5, "um");

        
        public FocalPlaneResolutionUnit(ushort key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static FocalPlaneResolutionUnit FromKey(ushort key)
        {
            switch(key)
            {
                case 1: return None;
                case 2: return Inches;
                case 3: return Centimeters;
                case 4: return Millimeters;
                case 5: return Micrometers;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
