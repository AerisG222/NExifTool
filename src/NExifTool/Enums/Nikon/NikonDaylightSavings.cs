using System;


namespace NExifTool.Enums.Nikon
{
    public class NikonDaylightSavings
        : TagEnum<byte>
    {
        public static readonly NikonDaylightSavings No = new NikonDaylightSavings(0, "No");
        public static readonly NikonDaylightSavings Yes = new NikonDaylightSavings(1, "Yes");

        
        public NikonDaylightSavings(byte key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static NikonDaylightSavings FromKey(byte key)
        {
            switch(key)
            {
                case 0: return No;
                case 1: return Yes;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
