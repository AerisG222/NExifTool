using System;


namespace NExifTool.Enums
{
    public class FlashValue
        : TagEnum<ushort>
    {
        public static readonly FlashValue NoFlash = new FlashValue(0x0, "No Flash");
        public static readonly FlashValue Fired = new FlashValue(0x1, "Fired");
        public static readonly FlashValue FiredReturnNotDetected = new FlashValue(0x5, "Fired, Return not detected");
        public static readonly FlashValue FiredReturnDetected = new FlashValue(0x7, "Fired, Return detected");
        public static readonly FlashValue OnDidNotFire = new FlashValue(0x8, "On, Did not fire");
        public static readonly FlashValue OnFired = new FlashValue(0x9, "On, Fired");
        public static readonly FlashValue OnReturnNotDetected = new FlashValue(0xd, "On, Return not detected");
        public static readonly FlashValue OnReturnDetected = new FlashValue(0xf, "On, Return detected");
        public static readonly FlashValue OffDidNotFire = new FlashValue(0x10, "Off, Did not fire");
        public static readonly FlashValue OffDidNotFireReturnNotDetected = new FlashValue(0x14, "Off, Did not fire, Return not detected");
        public static readonly FlashValue AutoDidNotFire = new FlashValue(0x18, "Auto, Did not fire");
        public static readonly FlashValue AutoFired = new FlashValue(0x19, "Auto, Fired");
        public static readonly FlashValue AutoFiredReturnNotDetected = new FlashValue(0x1d, "Auto, Fired, Return not detected");
        public static readonly FlashValue AutoFiredReturnDetected = new FlashValue(0x1f, "Auto, Fired, Return detected");
        public static readonly FlashValue NoFlashFunction = new FlashValue(0x20, "No flash function");
        public static readonly FlashValue OffNoFlashFunction = new FlashValue(0x30, "Off, No flash function");
        public static readonly FlashValue FiredRedEyeReduction = new FlashValue(0x41, "Fired, Red-eye reduction");
        public static readonly FlashValue FiredRedEyeReductionReturnNotDetected = new FlashValue(0x45, "Fired, Red-eye reduction, Return not detected");
        public static readonly FlashValue FiredRedEyeReductionReturnDetected = new FlashValue(0x47, "Fired, Red-eye reduction, Return detected");
        public static readonly FlashValue OnRedEyeReduction = new FlashValue(0x49, "On, Red-eye reduction");
        public static readonly FlashValue OnRedEyeReductionReturnNotDetected = new FlashValue(0x4d, "On, Red-eye reduction, Return not detected");
        public static readonly FlashValue OnRedEyeReductionReturnDetected = new FlashValue(0x4f, "On, Red-eye reduction, Return detected");
        public static readonly FlashValue OffRedEyeReduction = new FlashValue(0x50, "Off, Red-eye reduction");
        public static readonly FlashValue AutoDidNotFireRedEyReduction = new FlashValue(0x58, "Auto, Did not fire, Red-eye reduction");
        public static readonly FlashValue AutoFiredRedEyeReduction = new FlashValue(0x59, "Auto, Fired, Red-eye reduction");
        public static readonly FlashValue AutoFiredRedEyeReductionReturnNotDetected = new FlashValue(0x5d, "Auto, Fired, Red-eye reduction, Return not detected");
        public static readonly FlashValue AutoFiredRedEyeReductionReturnDetected = new FlashValue(0x5f, "Auto, Fired, Red-eye reduction, Return detected");
        
        
        public FlashValue(ushort key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static FlashValue FromKey(ushort key)
        {
            switch(key)
            {
                case 0x0: return NoFlash;
                case 0x1: return Fired;
                case 0x5: return FiredReturnNotDetected;
                case 0x7: return FiredReturnDetected;
                case 0x8: return OnDidNotFire;
                case 0x9: return OnFired;
                case 0xd: return OnReturnNotDetected;
                case 0xf: return OnReturnDetected;
                case 0x10: return OffDidNotFire;
                case 0x14: return OffDidNotFireReturnNotDetected;
                case 0x18: return AutoDidNotFire;
                case 0x19: return AutoFired;
                case 0x1d: return AutoFiredReturnNotDetected;
                case 0x1f: return AutoFiredReturnDetected;
                case 0x20: return NoFlashFunction;
                case 0x30: return OffNoFlashFunction;
                case 0x41: return FiredRedEyeReduction;
                case 0x45: return FiredRedEyeReductionReturnNotDetected;
                case 0x47: return FiredRedEyeReductionReturnDetected;
                case 0x49: return OnRedEyeReduction;
                case 0x4d: return OnRedEyeReductionReturnNotDetected;
                case 0x4f: return OnRedEyeReductionReturnDetected;
                case 0x50: return OffRedEyeReduction;
                case 0x58: return AutoDidNotFireRedEyReduction;
                case 0x59: return AutoFiredRedEyeReduction;
                case 0x5d: return AutoFiredRedEyeReductionReturnNotDetected;
                case 0x5f: return AutoFiredRedEyeReductionReturnDetected;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
