using System;


namespace NExifTool.Enums
{
    public class Saturation
        : TagEnum<ushort>
    {
        public static readonly Saturation Normal = new Saturation(0, "Normal");
        public static readonly Saturation Low = new Saturation(1, "Low");
        public static readonly Saturation High = new Saturation(2, "High");
        
        
        public Saturation(ushort key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static Saturation FromKey(ushort key)
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
