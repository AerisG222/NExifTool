using System;


namespace NExifTool.Enums
{
    public class Predictor
        : TagEnum<ushort>
    {
        public static readonly Predictor None = new Predictor(1, "None");
        public static readonly Predictor HorizontalDifferencing = new Predictor(2, "Horizontal differencing");
        
        
        public Predictor(ushort key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static Predictor FromKey(ushort key)
        {
            switch(key)
            {
                case 1: return None;
                case 2: return HorizontalDifferencing;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
