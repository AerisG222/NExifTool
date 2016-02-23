using System;


namespace NExifTool.Enums
{
    public class ExtraSamples
        : TagEnum<ushort>
    {
        public static readonly ExtraSamples Unspecified = new ExtraSamples(0, "Unspecified");
        public static readonly ExtraSamples AssociatedAlpha = new ExtraSamples(1, "Associated Alpha");
        public static readonly ExtraSamples UnassociatedAlpha = new ExtraSamples(2, "Unassociated Alpha");
        
        
        public ExtraSamples(ushort key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static ExtraSamples FromKey(ushort key)
        {
            switch(key)
            {
                case 0: return Unspecified;
                case 1: return AssociatedAlpha;
                case 2: return UnassociatedAlpha;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
