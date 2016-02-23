using System;


namespace NExifTool.Enums.Nikon
{
    public class NikonFlashMode
        : TagEnum<byte>
    {
        public static readonly NikonFlashMode DidNotFire = new NikonFlashMode(0, "Did Not Fire");
        public static readonly NikonFlashMode FiredManual = new NikonFlashMode(1, "Fired, Manual");
        public static readonly NikonFlashMode NotReady = new NikonFlashMode(3, "Not Ready");
        public static readonly NikonFlashMode FiredExternal = new NikonFlashMode(7, "Fired, External");
        public static readonly NikonFlashMode FiredCommanderMode = new NikonFlashMode(8, "Fired, Commander Mode");
        public static readonly NikonFlashMode FiredTtlMode = new NikonFlashMode(9, "Fired, TTL Mode");
        
        
        public NikonFlashMode(byte key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static NikonFlashMode FromKey(byte key)
        {
            switch(key)
            {
                case 0: return DidNotFire;
                case 1: return FiredManual;
                case 3: return NotReady;
                case 7: return FiredExternal;
                case 8: return FiredCommanderMode;
                case 9: return FiredTtlMode;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
