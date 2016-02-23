using System;


namespace NExifTool.Enums
{
    public class Thresholding
        : TagEnum<ushort>
    {
        public static readonly Thresholding NoDithering = new Thresholding(1, "No dithering or halftoning");
        public static readonly Thresholding OrderedDither = new Thresholding(2, "Ordered dither or halftone");
        public static readonly Thresholding RandomizedDither = new Thresholding(3, "Randomized dither");
        
        
        public Thresholding(ushort key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static Thresholding FromKey(ushort key)
        {
            switch(key)
            {
                case 1: return NoDithering;
                case 2: return OrderedDither;
                case 3: return RandomizedDither;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
