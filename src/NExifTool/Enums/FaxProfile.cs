using System;


namespace NExifTool.Enums
{
    public class FaxProfile
        : TagEnum<ushort>
    {
        public static readonly FaxProfile Unknown = new FaxProfile(0, "Unknown");
        public static readonly FaxProfile MinimalBWLossless = new FaxProfile(1, "Minimal B&W lossless, S");
        public static readonly FaxProfile ExtendedBWLossless = new FaxProfile(2, "Extended B&W lossless, F");
        public static readonly FaxProfile LosslessJbigBW = new FaxProfile(3, "Lossless JBIG B&W, J");
        public static readonly FaxProfile LossyColorAndGrayscale = new FaxProfile(4, "Lossy color and grayscale, C");
        public static readonly FaxProfile LosslessColorAndGrayscale = new FaxProfile(5, "Lossless color and grayscale, L");
        public static readonly FaxProfile MixedRaster = new FaxProfile(6, "Mixed raster content, M");
        public static readonly FaxProfile ProfileT = new FaxProfile(7, "Profile T");
        public static readonly FaxProfile MultiProfiles = new FaxProfile(255, "Multi Profiles");

        
        public FaxProfile(ushort key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static FaxProfile FromKey(ushort key)
        {
            switch(key)
            {
                case 0: return Unknown;
                case 1: return MinimalBWLossless;
                case 2: return ExtendedBWLossless;
                case 3: return LosslessJbigBW;
                case 4: return LossyColorAndGrayscale;
                case 5: return LosslessColorAndGrayscale;
                case 6: return MixedRaster;
                case 7: return ProfileT;
                case 255: return MultiProfiles;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
