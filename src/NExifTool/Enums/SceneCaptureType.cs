using System;


namespace NExifTool.Enums
{
    public class SceneCaptureType
        : TagEnum<ushort>
    {
        public static readonly SceneCaptureType Standard = new SceneCaptureType(0, "Standard");
        public static readonly SceneCaptureType Landscape = new SceneCaptureType(1, "Landscape");
        public static readonly SceneCaptureType Portrait = new SceneCaptureType(2, "Portrait");
        public static readonly SceneCaptureType Night = new SceneCaptureType(3, "Night");
        
        
        public SceneCaptureType(ushort key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static SceneCaptureType FromKey(ushort key)
        {
            switch(key)
            {
                case 0: return Standard;
                case 1: return Landscape;
                case 2: return Portrait;
                case 3: return Night;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
