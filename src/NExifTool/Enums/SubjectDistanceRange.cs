using System;


namespace NExifTool.Enums
{
    public class SubjectDistanceRange
        : TagEnum<ushort>
    {
        public static readonly SubjectDistanceRange Unknown = new SubjectDistanceRange(0, "Unknown");
        public static readonly SubjectDistanceRange Macro = new SubjectDistanceRange(1, "Macro");
        public static readonly SubjectDistanceRange Close = new SubjectDistanceRange(2, "Close");
        public static readonly SubjectDistanceRange Distant = new SubjectDistanceRange(3, "Distant");
        
        
        public SubjectDistanceRange(ushort key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static SubjectDistanceRange FromKey(ushort key)
        {
            switch(key)
            {
                case 0: return Unknown;
                case 1: return Macro;
                case 2: return Close;
                case 3: return Distant;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
