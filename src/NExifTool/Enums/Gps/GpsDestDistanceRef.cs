using System;


namespace NExifTool.Enums.Gps
{
    public class GpsDestDistanceRef
        : TagEnum<string>
    {
        public static readonly GpsDestDistanceRef Kilometers = new GpsDestDistanceRef("K", "Kilometers");
        public static readonly GpsDestDistanceRef Miles = new GpsDestDistanceRef("M", "Miles");
        public static readonly GpsDestDistanceRef NauticalMiles = new GpsDestDistanceRef("N", "Nautical Miles");
        
        
        public GpsDestDistanceRef(string key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static GpsDestDistanceRef FromKey(string key)
        {
            if(string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }
            
            switch(key.ToLower())
            {
                case "k": return Kilometers;
                case "m": return Miles;
                case "n": return NauticalMiles;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
