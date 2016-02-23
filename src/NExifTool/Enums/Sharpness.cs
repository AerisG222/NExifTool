using System;


namespace NExifTool.Enums
{
    public class Sharpness
        : TagEnum<ushort>
    {
        public static readonly Sharpness Normal = new Sharpness(0, "Normal");
        public static readonly Sharpness Soft = new Sharpness(1, "Soft");
        public static readonly Sharpness Hard = new Sharpness(2, "Hard");
        
        
        public Sharpness(ushort key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static Sharpness FromKey(ushort key)
        {
            switch(key)
            {
                case 0: return Normal;
                case 1: return Soft;
                case 2: return Hard;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
