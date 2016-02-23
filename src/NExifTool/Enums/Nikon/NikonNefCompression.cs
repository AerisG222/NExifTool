using System;


namespace NExifTool.Enums.Nikon
{
    public class NikonNefCompression
        : TagEnum<ushort>
    {
        public static readonly NikonNefCompression LossyType1 = new NikonNefCompression(1, "Lossy (type 1)");
        public static readonly NikonNefCompression Uncompressed = new NikonNefCompression(2, "Uncompressed");
        public static readonly NikonNefCompression Lossless = new NikonNefCompression(3, "Lossless");
        public static readonly NikonNefCompression LossyType2 = new NikonNefCompression(4, "Lossy (type 2)");
        public static readonly NikonNefCompression UncompressedReducedTo12bit = new NikonNefCompression(6, "Uncompressed (reduced to 12 bit)");
        public static readonly NikonNefCompression Small = new NikonNefCompression(8, "Small");

        
        public NikonNefCompression(ushort key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static NikonNefCompression FromKey(ushort key)
        {
            switch(key)
            {
                case 1: return LossyType1;
                case 2: return Uncompressed;
                case 3: return Lossless;
                case 4: return LossyType2;
                case 6: return UncompressedReducedTo12bit;
                case 8: return Small;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
