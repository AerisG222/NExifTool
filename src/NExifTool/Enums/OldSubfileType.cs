using System;


namespace NExifTool.Enums
{
    public class OldSubfileType
        : TagEnum<ushort>
    {
        public static readonly OldSubfileType FullResolutionImage = new OldSubfileType(1, "Full-resolution image");
        public static readonly OldSubfileType ReducedResolutionImage = new OldSubfileType(2, "Reduced-resolution image");
        public static readonly OldSubfileType SinglePageOfMultiPageImage = new OldSubfileType(3, "Single page of multi-page image");
        
        
        public OldSubfileType(ushort key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static OldSubfileType FromKey(ushort key)
        {
            switch(key)
            {
                case 1: return FullResolutionImage;
                case 2: return ReducedResolutionImage;
                case 3: return SinglePageOfMultiPageImage;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
