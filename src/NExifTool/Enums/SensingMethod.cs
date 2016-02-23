using System;


namespace NExifTool.Enums
{
    public class SensingMethod
        : TagEnum<ushort>
    {
        public static readonly SensingMethod Monochromearea = new SensingMethod(1, "Monochrome area");
        public static readonly SensingMethod OneChipColorArea = new SensingMethod(2, "One-chip color area");
        public static readonly SensingMethod TwoChipColorArea = new SensingMethod(3, "Two-chip color area");
        public static readonly SensingMethod ThreeChipColorArea = new SensingMethod(4, "Three-chip color area");
        public static readonly SensingMethod ColorSequentialArea = new SensingMethod(5, "Color sequential area");
        public static readonly SensingMethod MonochromeLinear = new SensingMethod(6, "Monochrome linear");
        public static readonly SensingMethod Trilinear = new SensingMethod(7, "Trilinear");
        public static readonly SensingMethod ColorSequentialLinear = new SensingMethod(8, "Color sequential linear");

        
        public SensingMethod(ushort key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static SensingMethod FromKey(ushort key)
        {
            switch(key)
            {
                case 1: return Monochromearea;
                case 2: return OneChipColorArea;
                case 3: return TwoChipColorArea;
                case 4: return ThreeChipColorArea;
                case 5: return ColorSequentialArea;
                case 6: return MonochromeLinear;
                case 7: return Trilinear;
                case 8: return ColorSequentialLinear;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
