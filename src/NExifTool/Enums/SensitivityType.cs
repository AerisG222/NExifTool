using System;


namespace NExifTool.Enums
{
    public class SensitivityType
        : TagEnum<ushort>
    {
        public static readonly SensitivityType Unknown = new SensitivityType(0, "Unknown");
        public static readonly SensitivityType StandardOutputSensitivity = new SensitivityType(1, "Standard Output Sensitivity");
        public static readonly SensitivityType RecommendedExposureIndex = new SensitivityType(2, "Recommended Exposure Index");
        public static readonly SensitivityType IsoSpeed = new SensitivityType(3, "ISO Speed");
        public static readonly SensitivityType StandardOutputSensitivityRecommendedExposure = new SensitivityType(4, "Standard Output Sensitivity and Recommended Exposure Index");
        public static readonly SensitivityType StandardOutputSensitivityAndIsoSpeed = new SensitivityType(5, "Standard Output Sensitivity and ISO Speed");
        public static readonly SensitivityType RecommendedExposureIndexAndIsoSpeed = new SensitivityType(6, "Recommended Exposure Index and ISO Speed");
        public static readonly SensitivityType StandardOutputSensitivityRecommendedExposureAndIso = new SensitivityType(7, "Standard Output Sensitivity, Recommended Exposure Index and ISO Speed");

        
        public SensitivityType(ushort key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static SensitivityType FromKey(ushort key)
        {
            switch(key)
            {
                case 0: return Unknown;
                case 1: return StandardOutputSensitivity;
                case 2: return RecommendedExposureIndex;
                case 3: return IsoSpeed;
                case 4: return StandardOutputSensitivityRecommendedExposure;
                case 5: return StandardOutputSensitivityAndIsoSpeed;
                case 6: return RecommendedExposureIndexAndIsoSpeed;
                case 7: return StandardOutputSensitivityRecommendedExposureAndIso;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
