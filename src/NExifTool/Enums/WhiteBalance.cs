using System;


namespace NExifTool.Enums
{
    public class WhiteBalance
        : TagEnum<ushort>
    {
        public static readonly WhiteBalance Auto = new WhiteBalance(0, "Auto");
        public static readonly WhiteBalance Manual = new WhiteBalance(1, "Manual");
        
        
        public WhiteBalance(ushort key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static WhiteBalance FromKey(ushort key)
        {
            switch(key)
            {
                case 0: return Auto;
                case 1: return Manual;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
