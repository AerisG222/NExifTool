using System;


namespace NExifTool.Enums.Gps
{
    public class GpsLatitudeRef
        : TagEnum<string>
    {
        public static readonly GpsLatitudeRef North = new GpsLatitudeRef("N", "North");
        public static readonly GpsLatitudeRef South = new GpsLatitudeRef("S", "South");
        
        
        public GpsLatitudeRef(string key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static GpsLatitudeRef FromKey(string key)
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
