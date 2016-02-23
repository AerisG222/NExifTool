using System;


namespace NExifTool.Enums
{
    public class YCbCrPositioning
        : TagEnum<ushort>
    {
        public static readonly YCbCrPositioning Centered = new YCbCrPositioning(1, "Centered");
        public static readonly YCbCrPositioning CoSited = new YCbCrPositioning(2, "Co-sited");
        
        
        public YCbCrPositioning(ushort key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static YCbCrPositioning FromKey(ushort key)
        {
            switch(key)
            {
                case 1: return Centered;
                case 2: return CoSited;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
