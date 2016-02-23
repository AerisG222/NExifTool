using System;


namespace NExifTool.Enums
{
    public class SecurityClassification
        : TagEnum<string>
    {
        public static readonly SecurityClassification Confidential = new SecurityClassification("C", "Confidential");
        public static readonly SecurityClassification Restricted = new SecurityClassification("R", "Restricted");
        public static readonly SecurityClassification Secret = new SecurityClassification("S", "Secret");
        public static readonly SecurityClassification TopSecret = new SecurityClassification("T", "Top Secret");
        public static readonly SecurityClassification Unclassified = new SecurityClassification("U", "Unclassified");
        
        
        public SecurityClassification(string key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static SecurityClassification FromKey(string key)
        {
            if(string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }
            
            switch(key.ToLower())
            {
                case "c": return Confidential;
                case "r": return Restricted;
                case "s": return Secret;
                case "t": return TopSecret;
                case "u": return Unclassified;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
