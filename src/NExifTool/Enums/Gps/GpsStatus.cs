using System;


namespace NExifTool.Enums.Gps
{
    public class GpsStatus
        : TagEnum<string>
    {
        public static readonly GpsStatus Active = new GpsStatus("A", "Measurement Active");
        public static readonly GpsStatus Void = new GpsStatus("V", "Measurement Void");
        
        
        public GpsStatus(string key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static GpsStatus FromKey(string key)
        {
            if(string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }
            
            switch(key.ToLower())
            {
                case "a": return Active;
                case "v": return Void;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
