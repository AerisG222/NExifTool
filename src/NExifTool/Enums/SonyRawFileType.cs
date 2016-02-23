using System;


namespace NExifTool.Enums
{
    public class SonyRawFileType
        : TagEnum<ushort>
    {
        public static readonly SonyRawFileType UncompressedRaw = new SonyRawFileType(0, "Sony Uncompressed RAW");
        public static readonly SonyRawFileType Raw1 = new SonyRawFileType(1, "Sony RAW 1");
        public static readonly SonyRawFileType CompressedRaw = new SonyRawFileType(2, "Sony Compressed RAW");
        public static readonly SonyRawFileType Raw3 = new SonyRawFileType(3, "Sony RAW 3");
        
        
        public SonyRawFileType(ushort key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static SonyRawFileType FromKey(ushort key)
        {
            switch(key)
            {
                case 0: return UncompressedRaw;
                case 1: return Raw1;
                case 2: return CompressedRaw;
                case 3: return Raw3;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
