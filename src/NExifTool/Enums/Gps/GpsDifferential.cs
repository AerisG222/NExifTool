using System;


namespace NExifTool.Enums
{
    public class GpsDifferential
        : TagEnum<ushort>
    {
        public static readonly GpsDifferential NoCorrection = new GpsDifferential(0, "No Correction");
        public static readonly GpsDifferential DifferentialCorrected = new GpsDifferential(1, "Differential Corrected");
        
        
        public GpsDifferential(ushort key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static GpsDifferential FromKey(ushort key)
        {
            switch(key)
            {
                case 0: return NoCorrection;
                case 1: return DifferentialCorrected;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
