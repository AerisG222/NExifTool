using System;


namespace NExifTool.Enums.Nikon
{
    public class NikonFlashColorFilter
        : TagEnum<byte>
    {
        public static readonly NikonFlashColorFilter None = new NikonFlashColorFilter(0, "None");
        public static readonly NikonFlashColorFilter FlGl1 = new NikonFlashColorFilter(1, "FL-GL1");
        public static readonly NikonFlashColorFilter FlGl2 = new NikonFlashColorFilter(2, "FL-GL2");	   	
        public static readonly NikonFlashColorFilter TnA1 = new NikonFlashColorFilter(9, "TN-A1");
        public static readonly NikonFlashColorFilter TnA2 = new NikonFlashColorFilter(10, "TN-A2");
        public static readonly NikonFlashColorFilter Red = new NikonFlashColorFilter(65, "Red");
        public static readonly NikonFlashColorFilter Blue = new NikonFlashColorFilter(66, "Blue");
        public static readonly NikonFlashColorFilter Yellow = new NikonFlashColorFilter(67, "Yellow");
        public static readonly NikonFlashColorFilter Amber = new NikonFlashColorFilter(68, "Amber");

        
        public NikonFlashColorFilter(byte key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static NikonFlashColorFilter FromKey(byte key)
        {
            switch(key)
            {
                case 0: return None;
                case 1: return FlGl1;
                case 2: return FlGl2;	   	
                case 9: return TnA1;
                case 10: return TnA2;
                case 65: return Red;
                case 66: return Blue;
                case 67: return Yellow;
                case 68: return Amber;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
