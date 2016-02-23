using System;


namespace NExifTool.Enums
{
    public class MakerNoteSafety
        : TagEnum<ushort>
    {
        public static readonly MakerNoteSafety Unsafe = new MakerNoteSafety(0, "Unsafe");
        public static readonly MakerNoteSafety Safe = new MakerNoteSafety(1, "Safe");
        
        
        public MakerNoteSafety(ushort key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static MakerNoteSafety FromKey(ushort key)
        {
            switch(key)
            {
                case 0: return Unsafe;
                case 1: return Safe;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
