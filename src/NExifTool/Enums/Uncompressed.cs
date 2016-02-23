using System;


namespace NExifTool.Enums
{
    public class Uncompressed
        : TagEnum<ushort>
    {
        public static readonly Uncompressed No = new Uncompressed(0, "No");
        public static readonly Uncompressed Yes = new Uncompressed(1, "Yes");
        
        
        public Uncompressed(ushort key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static Uncompressed FromKey(ushort key)
        {
            switch(key)
            {
                case 0: return No;
                case 1: return Yes;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
