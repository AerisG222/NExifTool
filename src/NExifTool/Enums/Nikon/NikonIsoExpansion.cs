using System;


namespace NExifTool.Enums.Nikon
{
    public class NikonIsoExpansion
        : TagEnum<ushort>
    {
        public static readonly NikonIsoExpansion Off = new NikonIsoExpansion(0x0, "Off");
        public static readonly NikonIsoExpansion High0_3 = new NikonIsoExpansion(0x101, "Hi 0.3");
        public static readonly NikonIsoExpansion High0_5 = new NikonIsoExpansion(0x102, "Hi 0.5");
        public static readonly NikonIsoExpansion High0_7 = new NikonIsoExpansion(0x103, "Hi 0.7");
        public static readonly NikonIsoExpansion High1_0 = new NikonIsoExpansion(0x104, "Hi 1.0");
        public static readonly NikonIsoExpansion High1_3 = new NikonIsoExpansion(0x105, "Hi 1.3");
        public static readonly NikonIsoExpansion High1_5 = new NikonIsoExpansion(0x106, "Hi 1.5");
        public static readonly NikonIsoExpansion High1_7 = new NikonIsoExpansion(0x107, "Hi 1.7");
        public static readonly NikonIsoExpansion High2_0 = new NikonIsoExpansion(0x108, "Hi 2.0");
        public static readonly NikonIsoExpansion High2_3 = new NikonIsoExpansion(0x109, "Hi 2.3");
        public static readonly NikonIsoExpansion High2_5 = new NikonIsoExpansion(0x10a, "Hi 2.5");	   	
        public static readonly NikonIsoExpansion High2_7 = new NikonIsoExpansion(0x10b, "Hi 2.7");
        public static readonly NikonIsoExpansion High3_0 = new NikonIsoExpansion(0x10c, "Hi 3.0");
        public static readonly NikonIsoExpansion High3_3 = new NikonIsoExpansion(0x10d, "Hi 3.3");
        public static readonly NikonIsoExpansion High3_5 = new NikonIsoExpansion(0x10e, "Hi 3.5");
        public static readonly NikonIsoExpansion High3_7 = new NikonIsoExpansion(0x10f, "Hi 3.7");
        public static readonly NikonIsoExpansion High4_0 = new NikonIsoExpansion(0x110, "Hi 4.0");
        public static readonly NikonIsoExpansion Low0_3 = new NikonIsoExpansion(0x201, "Lo 0.3");
        public static readonly NikonIsoExpansion Low0_5 = new NikonIsoExpansion(0x202, "Lo 0.5");
        public static readonly NikonIsoExpansion Low0_7 = new NikonIsoExpansion(0x203, "Lo 0.7");
        public static readonly NikonIsoExpansion Low1_0 = new NikonIsoExpansion(0x204, "Lo 1.0");

        
        
        public NikonIsoExpansion(ushort key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static NikonIsoExpansion FromKey(ushort key)
        {
            switch(key)
            {
                case 0x0: return Off;
                case 0x101: return High0_3;
                case 0x102: return High0_5;
                case 0x103: return High0_7;
                case 0x104: return High1_0;
                case 0x105: return High1_3;
                case 0x106: return High1_5;
                case 0x107: return High1_7;
                case 0x108: return High2_0;
                case 0x109: return High2_3;
                case 0x10a: return High2_5;	   	
                case 0x10b: return High2_7;
                case 0x10c: return High3_0;
                case 0x10d: return High3_3;
                case 0x10e: return High3_5;
                case 0x10f: return High3_7;
                case 0x110: return High4_0;
                case 0x201: return Low0_3;
                case 0x202: return Low0_5;
                case 0x203: return Low0_7;
                case 0x204: return Low1_0;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
