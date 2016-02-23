using System;


namespace NExifTool.Enums
{
    public class LightSource
        : TagEnum<ushort>
    {
        public static readonly LightSource Unknown = new LightSource(0, "Unknown");
        public static readonly LightSource Daylight = new LightSource(1, "Daylight");
        public static readonly LightSource Fluorescent = new LightSource(2, "Fluorescent");
        public static readonly LightSource Tungsten = new LightSource(3, "Tungsten (Incandescent)");
        public static readonly LightSource Flash = new LightSource(4, "Flash");
        public static readonly LightSource FineWeather = new LightSource(9, "Fine Weather");
        public static readonly LightSource Cloudy = new LightSource(10, "Cloudy");
        public static readonly LightSource Shade = new LightSource(11, "Shade");
        public static readonly LightSource DaylightFluorescent = new LightSource(12, "Daylight Fluorescent");
        public static readonly LightSource DayWhiteFluorescent = new LightSource(13, "Day White Fluorescent");
        public static readonly LightSource CoolWhiteFluorescent = new LightSource(14, "Cool White Fluorescent");
        public static readonly LightSource WhiteFluorescent = new LightSource(15, "White Fluorescent");
        public static readonly LightSource WarmWhiteFluorescent = new LightSource(16, "Warm White Fluorescent");
        public static readonly LightSource StandardLightA = new LightSource(17, "Standard Light A");
        public static readonly LightSource StandardLightB = new LightSource(18, "Standard Light B");
        public static readonly LightSource StandardLightC = new LightSource(19, "Standard Light C");
        public static readonly LightSource D55 = new LightSource(20, "D55");
        public static readonly LightSource D65 = new LightSource(21, "D65");
        public static readonly LightSource D75 = new LightSource(22, "D75");
        public static readonly LightSource D50 = new LightSource(23, "D50");
        public static readonly LightSource IsoStudioTungsten = new LightSource(24, "ISO Studio Tungsten");
        public static readonly LightSource Other = new LightSource(255, "Other");
        
        
        public LightSource(ushort key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static LightSource FromKey(ushort key)
        {
            switch(key)
            {
                case 0: return Unknown;
                case 1: return Daylight;
                case 2: return Fluorescent;
                case 3: return Tungsten;
                case 4: return Flash;
                case 9: return FineWeather;
                case 10: return Cloudy;
                case 11: return Shade;
                case 12: return DaylightFluorescent;
                case 13: return DayWhiteFluorescent;
                case 14: return CoolWhiteFluorescent;
                case 15: return WhiteFluorescent;
                case 16: return WarmWhiteFluorescent;
                case 17: return StandardLightA;
                case 18: return StandardLightB;
                case 19: return StandardLightC;
                case 20: return D55;
                case 21: return D65;
                case 22: return D75;
                case 23: return D50;
                case 24: return IsoStudioTungsten;
                case 255: return Other;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
