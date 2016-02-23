using System;


namespace NExifTool.Enums
{
    public class RasterPadding
        : TagEnum<ushort>
    {
        public static readonly RasterPadding Byte = new RasterPadding(0, "Byte");
        public static readonly RasterPadding Word = new RasterPadding(1, "Word");
        public static readonly RasterPadding LongWord = new RasterPadding(2, "Long Word");
        public static readonly RasterPadding Sector = new RasterPadding(9, "Sector");
        public static readonly RasterPadding LongSector = new RasterPadding(10, "Long Sector");
        
        
        public RasterPadding(ushort key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static RasterPadding FromKey(ushort key)
        {
            switch(key)
            {
                case 0: return Byte;
                case 1: return Word;
                case 2: return LongWord;
                case 9: return Sector;
                case 10: return LongSector;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
