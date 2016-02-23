using System;


namespace NExifTool.Enums.Gps
{
    public class GpsAltitudeRef
        : TagEnum<byte>
    {
        public static readonly GpsAltitudeRef AboveSeaLevel = new GpsAltitudeRef(0, "Above Sea Level");
        public static readonly GpsAltitudeRef BelowSeaLevel = new GpsAltitudeRef(1, "Below Sea Level");
        
        
        public GpsAltitudeRef(byte key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static GpsAltitudeRef FromKey(byte key)
        {
            switch(key)
            {
                case 0: return AboveSeaLevel;
                case 1: return BelowSeaLevel;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
