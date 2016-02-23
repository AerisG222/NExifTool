using System;


namespace NExifTool.Enums
{
    public class FileSource
        : TagEnum<ushort>
    {
        // TODO: what about this one: "\x03\x00\x00\x00" = Sigma Digital Camera
        public static readonly FileSource FilmScanner = new FileSource(1, "Film Scanner");
        public static readonly FileSource ReflectionPrintScanner = new FileSource(2, "Reflection Print Scanner");
        public static readonly FileSource DigitalCamera = new FileSource(3, "Digital Camera");
        
        
        public FileSource(ushort key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static FileSource FromKey(ushort key)
        {
            switch(key)
            {
                case 1: return FilmScanner;
                case 2: return ReflectionPrintScanner;
                case 3: return DigitalCamera;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
