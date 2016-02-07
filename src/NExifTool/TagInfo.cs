using System;
using System.Collections.Generic;


namespace NExifTool
{
    public class TagInfo
    {
        public string GeneralGroup { get; set; }
        public string SpecificGroup { get; set; }
        public string CategoryGroup { get; set; }
        public string DocumentNumberGroup { get; set; }
        public string InstanceNumberGroup { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Dictionary<string, string> TranslatedDescriptions { get; } = new Dictionary<string, string>();
        
        
        public string GetDescription(string preferredLang)
        {
            if(TranslatedDescriptions.ContainsKey(preferredLang))
            {
                return TranslatedDescriptions[preferredLang];
            }
            
            return Description;
        }
        
        
        public string GetDescription(string[] preferredLangs)
        {
            if(preferredLangs == null || preferredLangs.Length == 0)
            {
                return Description;
            }
            
            foreach(var lang in preferredLangs)
            {
                if(TranslatedDescriptions.ContainsKey(lang))
                {
                    return TranslatedDescriptions[lang];
                }
            }
            
            return Description;
        }
    }
}