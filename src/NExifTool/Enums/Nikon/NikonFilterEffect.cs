using System;


namespace NExifTool.Enums.Nikon
{
    public class NikonFilterEffect
        : TagEnum<byte>
    {
        public static readonly NikonFilterEffect Off = new NikonFilterEffect(0x80, "Off");
        public static readonly NikonFilterEffect Yellow = new NikonFilterEffect(0x81, "Yellow");
        public static readonly NikonFilterEffect Orange = new NikonFilterEffect(0x82, "Orange");	   	
        public static readonly NikonFilterEffect Red = new NikonFilterEffect(0x83, "Red");
        public static readonly NikonFilterEffect Green = new NikonFilterEffect(0x84, "Green");
        public static readonly NikonFilterEffect NA = new NikonFilterEffect(0xff, "n/a");
        
        
        public NikonFilterEffect(byte key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static NikonFilterEffect FromKey(byte key)
        {
            switch(key)
            {
                case 0x80: return Off;
                case 0x81: return Yellow;
                case 0x82: return Orange;	   	
                case 0x83: return Red;
                case 0x84: return Green;
                case 0xff: return NA;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
