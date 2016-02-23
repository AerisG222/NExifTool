using System;


namespace NExifTool.Enums
{
    public class YCbCrSubSampling
        : TagEnum<string>
    {
        public static readonly YCbCrSubSampling OneOne = new YCbCrSubSampling("1 1", "YCbCr4:4:4 (1 1)");
        public static readonly YCbCrSubSampling OneTwo = new YCbCrSubSampling("1 2", "YCbCr4:4:0 (1 2)");
        public static readonly YCbCrSubSampling OneFour = new YCbCrSubSampling("1 4", "YCbCr4:4:1 (1 4)");
        public static readonly YCbCrSubSampling TwoOne = new YCbCrSubSampling("2 1", "YCbCr4:2:2 (2 1)");	   	
        public static readonly YCbCrSubSampling TwoTwo = new YCbCrSubSampling("2 2", "YCbCr4:2:0 (2 2)");
        public static readonly YCbCrSubSampling TwoFour = new YCbCrSubSampling("2 4", "YCbCr4:2:1 (2 4)");
        public static readonly YCbCrSubSampling FourOne = new YCbCrSubSampling("4 1", "YCbCr4:1:1 (4 1)");
        public static readonly YCbCrSubSampling FourTwo = new YCbCrSubSampling("4 2", "YCbCr4:1:0 (4 2)");


        public YCbCrSubSampling(string key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static YCbCrSubSampling FromKey(string key)
        {
            switch(key)
            {
                case "1 1": return OneOne;
                case "1 2": return OneTwo;
                case "1 4": return OneFour;
                case "2 1": return TwoOne;	   	
                case "2 2": return TwoTwo;
                case "2 4": return TwoFour;
                case "4 1": return FourOne;
                case "4 2": return FourTwo;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
