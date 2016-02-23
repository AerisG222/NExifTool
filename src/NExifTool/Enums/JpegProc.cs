using System;


namespace NExifTool.Enums
{
    public class JpegProc
        : TagEnum<ushort>
    {
        public static readonly JpegProc Baseline = new JpegProc(1, "Baseline");
        public static readonly JpegProc Lossless = new JpegProc(14, "Lossless");
        
        
        public JpegProc(ushort key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static JpegProc FromKey(ushort key)
        {
            switch(key)
            {
                case 1: return Baseline;
                case 14: return Lossless;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
