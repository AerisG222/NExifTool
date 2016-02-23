using System;


namespace NExifTool.Enums
{
    public class Transformation
        : TagEnum<ushort>
    {
        public static readonly Transformation Horizontal = new Transformation(0, "Horizontal (normal)");
        public static readonly Transformation MirrorVertical = new Transformation(1, "Mirror vertical");
        public static readonly Transformation MirrorHorizontal = new Transformation(2, "Mirror horizontal");
        public static readonly Transformation Rotate180 = new Transformation(3, "Rotate 180");
        public static readonly Transformation Rotate90CW = new Transformation(4, "Rotate 90 CW");
        public static readonly Transformation MirrorHorizontalAndRotate90CW = new Transformation(5, "Mirror horizontal and rotate 90 CW");
        public static readonly Transformation MirrorHorizontalAndRotate270CW = new Transformation(6, "Mirror horizontal and rotate 270 CW");
        public static readonly Transformation Rotate270CW = new Transformation(7, "Rotate 270 CW");
        
        
        public Transformation(ushort key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static Transformation FromKey(ushort key)
        {
            switch(key)
            {
                case 0: return Horizontal;
                case 1: return MirrorVertical;
                case 2: return MirrorHorizontal;
                case 3: return Rotate180;
                case 4: return Rotate90CW;
                case 5: return MirrorHorizontalAndRotate90CW;
                case 6: return MirrorHorizontalAndRotate270CW;
                case 7: return Rotate270CW;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
