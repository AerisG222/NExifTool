using System;


namespace NExifTool.Enums
{
    public class Orientation
        : TagEnum<ushort>
    {
        public static readonly Orientation Horizontal = new Orientation(1, "Horizontal (normal)");
        public static readonly Orientation MirrorHorizontal = new Orientation(2, "Mirror horizontal");
        public static readonly Orientation Rotate180 = new Orientation(3, "Rotate 180");
        public static readonly Orientation MirrorVertical = new Orientation(4, "Mirror vertical");
        public static readonly Orientation MirrorHorizontalAndRotate270 = new Orientation(5, "Mirror horizontal and rotate 270 CW");
        public static readonly Orientation Rotate90CW = new Orientation(6, "Rotate 90 CW");
        public static readonly Orientation MirrorHorizontalAndRotate90CW = new Orientation(7, "Mirror horizontal and rotate 90 CW");
        public static readonly Orientation Rotate270CW = new Orientation(8, "Rotate 270 CW");
        
        
        public Orientation(ushort key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static Orientation FromKey(ushort key)
        {
            switch(key)
            {
                case 1: return Horizontal;
                case 2: return MirrorHorizontal;
                case 3: return Rotate180;
                case 4: return MirrorVertical;
                case 5: return MirrorHorizontalAndRotate270;
                case 6: return Rotate90CW;
                case 7: return MirrorHorizontalAndRotate90CW;
                case 8: return Rotate270CW;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
