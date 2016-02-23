using System;


namespace NExifTool.Enums
{
    public class FillOrder
        : TagEnum<ushort>
    {
        public static readonly FillOrder Normal = new FillOrder(1, "Normal");
        public static readonly FillOrder Reversed = new FillOrder(2, "Reversed");
        
        
        public FillOrder(ushort key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static FillOrder FromKey(ushort key)
        {
            switch(key)
            {
                case 1: return Normal;
                case 2: return Reversed;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
