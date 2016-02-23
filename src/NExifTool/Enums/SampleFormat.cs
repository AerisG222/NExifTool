using System;


namespace NExifTool.Enums
{
    public class SampleFormat
        : TagEnum<ushort>
    {
        public static readonly SampleFormat Unknown = new SampleFormat(0, "Unknown");  // TODO: should we keep this?
        public static readonly SampleFormat Unsigned = new SampleFormat(1, "Unsigned");
        public static readonly SampleFormat Signed = new SampleFormat(2, "Signed");
        public static readonly SampleFormat Float = new SampleFormat(3, "Float");
        public static readonly SampleFormat Undefined = new SampleFormat(4, "Undefined");
        public static readonly SampleFormat ComplexInt = new SampleFormat(5, "Complex int");
        public static readonly SampleFormat ComplexFloat = new SampleFormat(6, "Complex float");
        
        
        public SampleFormat(ushort key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static SampleFormat FromKey(ushort key)
        {
            switch(key)
            {
                case 0: return Unknown;
                case 1: return Unsigned;
                case 2: return Signed;
                case 3: return Float;
                case 4: return Undefined;
                case 5: return ComplexInt;
                case 6: return ComplexFloat;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
