using System;


namespace NExifTool.Enums
{
    public class ImageDataDiscard
        : TagEnum<ushort>
    {
        public static readonly ImageDataDiscard FullResolution = new ImageDataDiscard(0, "Full Resolution");
        public static readonly ImageDataDiscard Flexbits = new ImageDataDiscard(1, "Flexbits Discarded");
        public static readonly ImageDataDiscard HighPass = new ImageDataDiscard(2, "HighPass Frequency Data Discarded");
        public static readonly ImageDataDiscard HighAndLowPass = new ImageDataDiscard(3, "Highpass and LowPass Frequency Data Discarded");

        
        public ImageDataDiscard(ushort key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static ImageDataDiscard FromKey(ushort key)
        {
            switch(key)
            {
                case 0: return FullResolution;
                case 1: return Flexbits;
                case 2: return HighPass;
                case 3: return HighAndLowPass;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
