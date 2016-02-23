using System;


namespace NExifTool.Enums
{
    public class Contrast
        : TagEnum<ushort>
    {
        public static readonly Contrast Normal = new Contrast(0, "Normal");
        public static readonly Contrast Low = new Contrast(1, "Low");
        public static readonly Contrast High = new Contrast(2, "High");
        
        
        public Contrast(ushort key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static Contrast FromKey(ushort key)
        {
            switch(key)
            {
                case 0: return Normal;
                case 1: return Low;
                case 2: return High;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
