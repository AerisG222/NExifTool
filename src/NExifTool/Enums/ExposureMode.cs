using System;


namespace NExifTool.Enums
{
    public class ExposureMode
        : TagEnum<ushort>
    {
        public static readonly ExposureMode Auto = new ExposureMode(0, "Auto");
        public static readonly ExposureMode Manual = new ExposureMode(1, "Manual");
        public static readonly ExposureMode AutoBracket = new ExposureMode(2, "Auto Bracket");
        
        
        public ExposureMode(ushort key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static ExposureMode FromKey(ushort key)
        {
            switch(key)
            {
                case 0: return Auto;
                case 1: return Manual;
                case 2: return AutoBracket;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
