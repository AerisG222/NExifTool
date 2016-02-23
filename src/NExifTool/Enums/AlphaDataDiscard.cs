using System;


namespace NExifTool.Enums
{
    public class AlphaDataDiscard
        : TagEnum<ushort>
    {
        public static readonly AlphaDataDiscard FullResolution = new AlphaDataDiscard(0, "Full Resolution");
        public static readonly AlphaDataDiscard Flexbits = new AlphaDataDiscard(1, "Flexbits Discarded");
        public static readonly AlphaDataDiscard HighPass = new AlphaDataDiscard(2, "HighPass Frequency Data Discarded");
        public static readonly AlphaDataDiscard HighAndLowPass = new AlphaDataDiscard(3, "Highpass and LowPass Frequency Data Discarded");

        
        public AlphaDataDiscard(ushort key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static AlphaDataDiscard FromKey(ushort key)
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
