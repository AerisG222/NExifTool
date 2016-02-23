using System;


namespace NExifTool.Enums.Gps
{
    public class GpsTrackRef
        : TagEnum<string>
    {
        public static readonly GpsTrackRef MagneticNorth = new GpsTrackRef("M", "Magnetic North");
        public static readonly GpsTrackRef TrueNorth = new GpsTrackRef("T", "True North");
        
        
        public GpsTrackRef(string key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static GpsTrackRef FromKey(string key)
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
