using System;


namespace NExifTool.Enums
{
    public class ExposureProgram
        : TagEnum<ushort>
    {
        public static readonly ExposureProgram NotDefined = new ExposureProgram(0, "Not Defined");
        public static readonly ExposureProgram Manual = new ExposureProgram(1, "Manual");
        public static readonly ExposureProgram ProgramAE = new ExposureProgram(2, "Program AE");
        public static readonly ExposureProgram AperturePriorityAE = new ExposureProgram(3, "Aperture-priority AE");
        public static readonly ExposureProgram ShutterSpeedPriorityAE = new ExposureProgram(4, "Shutter speed priority AE");
        public static readonly ExposureProgram Creative = new ExposureProgram(5, "Creative (Slow speed)");
        public static readonly ExposureProgram Action = new ExposureProgram(6, "Action (High speed)");
        public static readonly ExposureProgram Portrait = new ExposureProgram(7, "Portrait");
        public static readonly ExposureProgram Landscape = new ExposureProgram(8, "Landscape");
        public static readonly ExposureProgram Bulb = new ExposureProgram(9, "Bulb");
        
        
        public ExposureProgram(ushort key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static ExposureProgram FromKey(ushort key)
        {
            switch(key)
            {
                case 0: return NotDefined;
                case 1: return Manual;
                case 2: return ProgramAE;
                case 3: return AperturePriorityAE;
                case 4: return ShutterSpeedPriorityAE;
                case 5: return Creative;
                case 6: return Action;
                case 7: return Portrait;
                case 8: return Landscape;
                case 9: return Bulb;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
