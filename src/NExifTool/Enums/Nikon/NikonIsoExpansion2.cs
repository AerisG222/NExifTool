using System;


namespace NExifTool.Enums.Nikon
{
    public class NikonIsoExpansion2
        : TagEnum<ushort>
    {
        public static readonly NikonIsoExpansion2 Off = new NikonIsoExpansion2(0x0, "Off");
        public static readonly NikonIsoExpansion2 High0_3 = new NikonIsoExpansion2(0x101, "Hi 0.3");
        public static readonly NikonIsoExpansion2 High0_5 = new NikonIsoExpansion2(0x102, "Hi 0.5");
        public static readonly NikonIsoExpansion2 High0_7 = new NikonIsoExpansion2(0x103, "Hi 0.7");
        public static readonly NikonIsoExpansion2 High1_0 = new NikonIsoExpansion2(0x104, "Hi 1.0");
        public static readonly NikonIsoExpansion2 High1_3 = new NikonIsoExpansion2(0x105, "Hi 1.3");
        public static readonly NikonIsoExpansion2 High1_5 = new NikonIsoExpansion2(0x106, "Hi 1.5");
        public static readonly NikonIsoExpansion2 High1_7 = new NikonIsoExpansion2(0x107, "Hi 1.7");
        public static readonly NikonIsoExpansion2 High2_0 = new NikonIsoExpansion2(0x108, "Hi 2.0");
        public static readonly NikonIsoExpansion2 Low0_3 = new NikonIsoExpansion2(0x201, "Lo 0.3");
        public static readonly NikonIsoExpansion2 Low0_5 = new NikonIsoExpansion2(0x202, "Lo 0.5");
        public static readonly NikonIsoExpansion2 Low0_7 = new NikonIsoExpansion2(0x203, "Lo 0.7");
        public static readonly NikonIsoExpansion2 Low1_0 = new NikonIsoExpansion2(0x204, "Lo 1.0");

        
        
        public NikonIsoExpansion2(ushort key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static NikonIsoExpansion2 FromKey(ushort key)
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
                case 0x201: return Low0_3;
                case 0x202: return Low0_5;
                case 0x203: return Low0_7;
                case 0x204: return Low1_0;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
