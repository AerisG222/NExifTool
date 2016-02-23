using System;


namespace NExifTool.Enums.Gps
{
    public class GpsImgDirectionRef
        : TagEnum<string>
    {
        public static readonly GpsImgDirectionRef MagneticNorth = new GpsImgDirectionRef("M", "Magnetic North");
        public static readonly GpsImgDirectionRef TrueNorth = new GpsImgDirectionRef("T", "True North");
        
        
        public GpsImgDirectionRef(string key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static GpsImgDirectionRef FromKey(string key)
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
