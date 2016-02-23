using System;


namespace NExifTool.Enums
{
    public class USPTOOriginalContentType
        : TagEnum<ushort>
    {
        public static readonly USPTOOriginalContentType TextOrDrawing = new USPTOOriginalContentType(0, "Text or Drawing");
        public static readonly USPTOOriginalContentType Grayscale = new USPTOOriginalContentType(1, "Grayscale");
        public static readonly USPTOOriginalContentType Color = new USPTOOriginalContentType(2, "Color");

        
        
        public USPTOOriginalContentType(ushort key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static USPTOOriginalContentType FromKey(ushort key)
        {
            switch(key)
            {
                case 0: return TextOrDrawing;
                case 1: return Grayscale;
                case 2: return Color;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
