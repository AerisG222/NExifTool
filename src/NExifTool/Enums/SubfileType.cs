using System;


namespace NExifTool.Enums
{
    public class SubfileType
        : TagEnum<uint>
    {
        /* TODO: how should we deal with these?
        Bit 0 = Reduced resolution
        Bit 1 = Single page
        Bit 2 = Transparency mask
        Bit 3 = TIFF/IT final page
        Bit 4 = TIFF-FX mixed raster content
        */
        
        public static readonly SubfileType FullResolutionImage = new SubfileType(0x0, "Full-resolution Image");
        public static readonly SubfileType ReducedResolutionImage = new SubfileType(0x1, "Reduced-resolution image");
        public static readonly SubfileType SinglePageOfMultiPageImage = new SubfileType(0x2, "Single page of multi-page image");
        public static readonly SubfileType SinglePageOfMultiPageReducedImage = new SubfileType(0x3, "Single page of multi-page reduced-resolution image");
        public static readonly SubfileType TransparencyMask = new SubfileType(0x4, "Transparency mask");
        public static readonly SubfileType TransparencyMaskReducedResolutionImage = new SubfileType(0x5, "Transparency mask of reduced-resolution image");
        public static readonly SubfileType TransparencyMaskMultiPageImage = new SubfileType(0x6, "Transparency mask of multi-page image");
        public static readonly SubfileType TransparencyMaskMultiPageReducedResolutionImage = new SubfileType(0x7, "Transparency mask of reduced-resolution multi-page image");
        public static readonly SubfileType AlternateReducedResolutionImage = new SubfileType(0x10001, "Alternate reduced-resolution image");
        public static readonly SubfileType Invalid = new SubfileType(0xffffffff, "invalid");
        
        
        public SubfileType(uint key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static SubfileType FromKey(uint key)
        {
            switch(key)
            {
                case 0x0: return FullResolutionImage;
                case 0x1: return ReducedResolutionImage;
                case 0x2: return SinglePageOfMultiPageImage;
                case 0x3: return SinglePageOfMultiPageReducedImage;
                case 0x4: return TransparencyMask;
                case 0x5: return TransparencyMaskReducedResolutionImage;
                case 0x6: return TransparencyMaskMultiPageImage;
                case 0x7: return TransparencyMaskMultiPageReducedResolutionImage;
                case 0x10001: return AlternateReducedResolutionImage;
                case 0xffffffff: return Invalid;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
