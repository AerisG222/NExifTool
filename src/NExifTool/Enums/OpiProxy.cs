using System;


namespace NExifTool.Enums
{
    public class OpiProxy
        : TagEnum<ushort>
    {
        public static readonly OpiProxy HigherResolutionNotExists = new OpiProxy(0, "Higher resolution image does not exist");
        public static readonly OpiProxy HigherResolutionExists = new OpiProxy(1, "Higher resolution image exists");
        
        
        public OpiProxy(ushort key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static OpiProxy FromKey(ushort key)
        {
            switch(key)
            {
                case 0: return HigherResolutionNotExists;
                case 1: return HigherResolutionExists;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
