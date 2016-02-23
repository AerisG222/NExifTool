using System;


namespace NExifTool.Enums.Gps
{
    public class GpsMeasureMode
        : TagEnum<string>
    {
        public static readonly GpsMeasureMode TwoDimensional = new GpsMeasureMode("2", "2-Dimensional Measurement");
        public static readonly GpsMeasureMode ThreeDimensional = new GpsMeasureMode("3", "3-Dimensional Measurement");
        
        
        public GpsMeasureMode(string key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static GpsMeasureMode FromKey(string key)
        {
            if(string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }
            
            switch(key.ToLower())
            {
                case "2": return TwoDimensional;
                case "3": return ThreeDimensional;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
