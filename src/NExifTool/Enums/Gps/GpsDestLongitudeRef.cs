using System;


namespace NExifTool.Enums.Gps
{
    public class GpsDestLongitudeRef
        : TagEnum<string>
    {
        public static readonly GpsDestLongitudeRef East = new GpsDestLongitudeRef("E", "East");
        public static readonly GpsDestLongitudeRef West = new GpsDestLongitudeRef("W", "West");
        
        
        public GpsDestLongitudeRef(string key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static GpsDestLongitudeRef FromKey(string key)
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
