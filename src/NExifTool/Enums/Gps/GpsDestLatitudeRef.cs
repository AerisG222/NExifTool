using System;


namespace NExifTool.Enums.Gps
{
    public class GpsDestLatitudeRef
        : TagEnum<string>
    {
        public static readonly GpsDestLatitudeRef North = new GpsDestLatitudeRef("N", "North");
        public static readonly GpsDestLatitudeRef South = new GpsDestLatitudeRef("S", "South");
        
        
        public GpsDestLatitudeRef(string key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static GpsDestLatitudeRef FromKey(string key)
        {
            if(string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }
            
            switch(key.ToLower())
            {
                case "n": return North;
                case "s": return South;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
