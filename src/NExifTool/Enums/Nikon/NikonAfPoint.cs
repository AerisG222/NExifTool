using System;


namespace NExifTool.Enums.Nikon
{
    public class NikonAfPoint
        : TagEnum<byte>
    {
        public static readonly NikonAfPoint Center = new NikonAfPoint(0, "Center");
        public static readonly NikonAfPoint Top = new NikonAfPoint(1, "Top");
        public static readonly NikonAfPoint Bottom = new NikonAfPoint(2, "Bottom");
        public static readonly NikonAfPoint MidLeft = new NikonAfPoint(3, "Mid-left");
        public static readonly NikonAfPoint MidRight = new NikonAfPoint(4, "Mid-right");
        public static readonly NikonAfPoint UpperLeft = new NikonAfPoint(5, "Upper-left");	   	
        public static readonly NikonAfPoint UpperRight = new NikonAfPoint(6, "Upper-right");
        public static readonly NikonAfPoint LowerLeft = new NikonAfPoint(7, "Lower-left");
        public static readonly NikonAfPoint LowerRight = new NikonAfPoint(8, "Lower-right");
        public static readonly NikonAfPoint FarLeft = new NikonAfPoint(9, "Far Left");
        public static readonly NikonAfPoint FarRight = new NikonAfPoint(10, "Far Right");
        
        
        public NikonAfPoint(byte key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static NikonAfPoint FromKey(byte key)
        {
            switch(key)
            {
                case 0: return Center;
                case 1: return Top;
                case 2: return Bottom;
                case 3: return MidLeft;
                case 4: return MidRight;
                case 5: return UpperLeft;	   	
                case 6: return UpperRight;
                case 7: return LowerLeft;
                case 8: return LowerRight;
                case 9: return FarLeft;
                case 10: return FarRight;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
