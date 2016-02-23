using System;


namespace NExifTool.Enums.Nikon
{
    public class NikonActiveDLighting
        : TagEnum<ushort>
    {
        public static readonly NikonActiveDLighting Off = new NikonActiveDLighting(0, "Off");
        public static readonly NikonActiveDLighting Low = new NikonActiveDLighting(1, "Low");
        public static readonly NikonActiveDLighting Normal = new NikonActiveDLighting(3, "Normal");
        public static readonly NikonActiveDLighting High = new NikonActiveDLighting(5, "High");
        public static readonly NikonActiveDLighting ExtraHigh = new NikonActiveDLighting(7, "Extra High");	   	
        public static readonly NikonActiveDLighting ExtraHigh1 = new NikonActiveDLighting(8, "Extra High 1");
        public static readonly NikonActiveDLighting ExtraHigh2 = new NikonActiveDLighting(9, "Extra High 2");
        public static readonly NikonActiveDLighting ExtraHigh3 = new NikonActiveDLighting(10, "Extra High 3");
        public static readonly NikonActiveDLighting ExtraHigh4 = new NikonActiveDLighting(11, "Extra High 4");
        public static readonly NikonActiveDLighting Auto = new NikonActiveDLighting(65535, "Auto");
        
        
        public NikonActiveDLighting(ushort key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static NikonActiveDLighting FromKey(ushort key)
        {
            switch(key)
            {
                case 0: return Off;
                case 1: return Low;
                case 3: return Normal;
                case 5: return High;
                case 7: return ExtraHigh;	   	
                case 8: return ExtraHigh1;
                case 9: return ExtraHigh2;
                case 10: return ExtraHigh3;
                case 11: return ExtraHigh4;
                case 65535: return Auto;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
