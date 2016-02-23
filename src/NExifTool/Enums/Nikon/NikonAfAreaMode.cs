using System;


namespace NExifTool.Enums.Nikon
{
    public class NikonAfAreaMode
        : TagEnum<byte>
    {
        public static readonly NikonAfAreaMode SingleArea = new NikonAfAreaMode(0, "Single Area");
        public static readonly NikonAfAreaMode DynamicArea = new NikonAfAreaMode(1, "Dynamic Area");
        public static readonly NikonAfAreaMode DynamicAreaClosestSubject = new NikonAfAreaMode(2, "Dynamic Area (closest subject)");
        public static readonly NikonAfAreaMode GroupDynamic = new NikonAfAreaMode(3, "Group Dynamic");
        public static readonly NikonAfAreaMode SingleAreaWide = new NikonAfAreaMode(4, "Single Area (wide)");
        public static readonly NikonAfAreaMode DynamicAreaWide = new NikonAfAreaMode(5, "Dynamic Area (wide)");

        
        public NikonAfAreaMode(byte key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static NikonAfAreaMode FromKey(byte key)
        {
            switch(key)
            {
                case 0: return SingleArea;
                case 1: return DynamicArea;
                case 2: return DynamicAreaClosestSubject;
                case 3: return GroupDynamic;
                case 4: return SingleAreaWide;
                case 5: return DynamicAreaWide;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
