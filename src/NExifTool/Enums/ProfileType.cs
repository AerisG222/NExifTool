using System;


namespace NExifTool.Enums
{
    public class ProfileType
        : TagEnum<ushort>
    {
        public static readonly ProfileType Unspecified = new ProfileType(0, "Unspecified");
        public static readonly ProfileType Group3Fax = new ProfileType(1, "Group 3 FAX");
        
        
        public ProfileType(ushort key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static ProfileType FromKey(ushort key)
        {
            switch(key)
            {
                case 0: return Unspecified;
                case 1: return Group3Fax;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
