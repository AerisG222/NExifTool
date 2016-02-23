using System;


namespace NExifTool.Enums.Gps
{
    public class GpsSpeedRef
        : TagEnum<string>
    {
        public static readonly GpsSpeedRef Kmph = new GpsSpeedRef("K", "km/h");
        public static readonly GpsSpeedRef Mph = new GpsSpeedRef("M", "mph");
        public static readonly GpsSpeedRef Knots = new GpsSpeedRef("N", "knots");
        
        
        public GpsSpeedRef(string key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static GpsSpeedRef FromKey(string key)
        {
            if(string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }
            
            switch(key.ToLower())
            {
                case "k": return Kmph;
                case "m": return Mph;
                case "n": return Knots;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
