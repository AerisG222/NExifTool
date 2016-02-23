using System;


namespace NExifTool.Enums.Gps
{
    public class GpsDestBearingRef
        : TagEnum<string>
    {
        public static readonly GpsDestBearingRef MagneticNorth = new GpsDestBearingRef("M", "Magnetic North");
        public static readonly GpsDestBearingRef TrueNorth = new GpsDestBearingRef("T", "True North");
        
        
        public GpsDestBearingRef(string key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static GpsDestBearingRef FromKey(string key)
        {
            if(string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }
            
            switch(key.ToLower())
            {
                case "m": return MagneticNorth;
                case "t": return TrueNorth;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
