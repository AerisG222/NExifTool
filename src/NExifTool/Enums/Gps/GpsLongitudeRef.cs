using System;


namespace NExifTool.Enums.Gps
{
    public class GpsLongitudeRef
        : TagEnum<string>
    {
        public static readonly GpsLongitudeRef East = new GpsLongitudeRef("E", "East");
        public static readonly GpsLongitudeRef West = new GpsLongitudeRef("W", "West");
        
        
        public GpsLongitudeRef(string key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static GpsLongitudeRef FromKey(string key)
        {
            if(string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }
            
            switch(key.ToLower())
            {
                case "e": return East;
                case "w": return West;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
