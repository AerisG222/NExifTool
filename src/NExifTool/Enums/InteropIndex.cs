using System;


namespace NExifTool.Enums
{
    public class InteropIndex
        : TagEnum<string>
    {
        public static readonly InteropIndex AdobeRGB = new InteropIndex("R03", "DCF option file (Adobe RGB)");
        public static readonly InteropIndex sRGB = new InteropIndex("R98", "R98 - DCF basic file (sRGB)");
        public static readonly InteropIndex Thumbnail = new InteropIndex("THM", "THM - DCF thumbnail file");
        
        
        public InteropIndex(string key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static InteropIndex FromKey(string key)
        {
            if(string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }
            
            switch(key.Trim().ToLower())
            {
                case "r03": return AdobeRGB;
                case "r98": return sRGB;
                case "thm": return Thumbnail;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
