using System;


namespace NExifTool.Enums
{
    public class InkSet
        : TagEnum<ushort>
    { 	
        public static readonly InkSet CMYK = new InkSet(1, "CMYK");
        public static readonly InkSet NotCMYK = new InkSet(2, "Not CMYK");
        
        
        public InkSet(ushort key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static InkSet FromKey(ushort key)
        {
            switch(key)
            {
                case 1: return CMYK;
                case 2: return NotCMYK;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
