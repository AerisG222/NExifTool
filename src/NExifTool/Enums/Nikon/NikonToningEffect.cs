using System;


namespace NExifTool.Enums.Nikon
{
    public class NikonToningEffect
        : TagEnum<byte>
    {
        public static readonly NikonToningEffect BlackAndWhite = new NikonToningEffect(0x80, "B&W");
        public static readonly NikonToningEffect Sepia = new NikonToningEffect(0x81, "Sepia");
        public static readonly NikonToningEffect Cyanotype = new NikonToningEffect(0x82, "Cyanotype");
        public static readonly NikonToningEffect Red = new NikonToningEffect(0x83, "Red");
        public static readonly NikonToningEffect Yellow = new NikonToningEffect(0x84, "Yellow");
        public static readonly NikonToningEffect Green = new NikonToningEffect(0x85, "Green");	   	
        public static readonly NikonToningEffect BlueGreen = new NikonToningEffect(0x86, "Blue-green");
        public static readonly NikonToningEffect Blue = new NikonToningEffect(0x87, "Blue");
        public static readonly NikonToningEffect PurpleBlue = new NikonToningEffect(0x88, "Purple-blue");
        public static readonly NikonToningEffect RedPurple = new NikonToningEffect(0x89, "Red-purple");
        public static readonly NikonToningEffect NA = new NikonToningEffect(0xff, "n/a");
        
        
        public NikonToningEffect(byte key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static NikonToningEffect FromKey(byte key)
        {
            switch(key)
            {
                case 0x80: return BlackAndWhite;
                case 0x81: return Sepia;
                case 0x82: return Cyanotype;
                case 0x83: return Red;
                case 0x84: return Yellow;
                case 0x85: return Green;	   	
                case 0x86: return BlueGreen;
                case 0x87: return Blue;
                case 0x88: return PurpleBlue;
                case 0x89: return RedPurple;
                case 0xff: return NA;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
