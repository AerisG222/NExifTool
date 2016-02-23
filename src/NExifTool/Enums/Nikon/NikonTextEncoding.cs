using System;


namespace NExifTool.Enums.Nikon
{
    public class NikonTextEncoding
        : TagEnum<byte>
    {
        public static readonly NikonTextEncoding NA = new NikonTextEncoding(0, "n/a");
        public static readonly NikonTextEncoding UTF8 = new NikonTextEncoding(1, "UTF8");
        public static readonly NikonTextEncoding UTF16 = new NikonTextEncoding(2, "UTF16");
        
        
        public NikonTextEncoding(byte key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static NikonTextEncoding FromKey(byte key)
        {
            switch(key)
            {
                case 0: return NA;
                case 1: return UTF8;
                case 2: return UTF16;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
