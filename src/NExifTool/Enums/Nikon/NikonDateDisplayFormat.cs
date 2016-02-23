using System;


namespace NExifTool.Enums.Nikon
{
    public class NikonDateDisplayFormat
        : TagEnum<byte>
    {
        public static readonly NikonDateDisplayFormat YMD = new NikonDateDisplayFormat(0, "Y/M/D");
        public static readonly NikonDateDisplayFormat MDY = new NikonDateDisplayFormat(1, "M/D/Y");
        public static readonly NikonDateDisplayFormat DMY = new NikonDateDisplayFormat(2, "D/M/Y");

        
        public NikonDateDisplayFormat(byte key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static NikonDateDisplayFormat FromKey(byte key)
        {
            switch(key)
            {
                case 0: return YMD;
                case 1: return MDY;
                case 2: return DMY;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
