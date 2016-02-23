using System;


namespace NExifTool.Enums.Nikon
{
    public class NikonVRMode
        : TagEnum<byte>
    {
        public static readonly NikonVRMode Normal = new NikonVRMode(0, "Normal");
        public static readonly NikonVRMode Active = new NikonVRMode(2, "Active");
        
        
        public NikonVRMode(byte key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static NikonVRMode FromKey(byte key)
        {
            switch(key)
            {
                case 0: return Normal;
                case 2: return Active;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
