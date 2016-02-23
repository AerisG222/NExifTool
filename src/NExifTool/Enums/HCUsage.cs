using System;


namespace NExifTool.Enums
{
    public class HCUsage
        : TagEnum<ushort>
    {
        public static readonly HCUsage CT = new HCUsage(0, "CT");
        public static readonly HCUsage LineArt = new HCUsage(1, "Line Art");
        public static readonly HCUsage Trap = new HCUsage(2, "Trap");
        
        
        public HCUsage(ushort key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static HCUsage FromKey(ushort key)
        {
            switch(key)
            {
                case 0: return CT;
                case 1: return LineArt;
                case 2: return Trap;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
