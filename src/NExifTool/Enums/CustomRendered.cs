using System;


namespace NExifTool.Enums
{
    public class CustomRendered
        : TagEnum<ushort>
    {
        public static readonly CustomRendered Normal = new CustomRendered(0, "Normal");
        public static readonly CustomRendered Custom = new CustomRendered(1, "Custom");
        
        
        public CustomRendered(ushort key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static CustomRendered FromKey(ushort key)
        {
            switch(key)
            {
                case 0: return Normal;
                case 1: return Custom;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
