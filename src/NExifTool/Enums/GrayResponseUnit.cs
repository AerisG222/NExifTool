using System;


namespace NExifTool.Enums
{
    public class GrayResponseUnit
        : TagEnum<ushort>
    {
        public static readonly GrayResponseUnit OneENegativeOne = new GrayResponseUnit(1, "0.1");
        public static readonly GrayResponseUnit OneENegativeThree = new GrayResponseUnit(2, "0.001");
        public static readonly GrayResponseUnit OneENegativeFour = new GrayResponseUnit(3, "0.0001");
        public static readonly GrayResponseUnit OneENegativeFive = new GrayResponseUnit(4, "1e-05");
        public static readonly GrayResponseUnit OneENegativeSix = new GrayResponseUnit(5, "1e-06");
        
        
        public GrayResponseUnit(ushort key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static GrayResponseUnit FromKey(ushort key)
        {
            switch(key)
            {
                case 1: return OneENegativeOne;
                case 2: return OneENegativeThree;
                case 3: return OneENegativeFour;
                case 4: return OneENegativeFive;
                case 5: return OneENegativeSix;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
