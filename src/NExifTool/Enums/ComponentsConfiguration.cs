using System;


namespace NExifTool.Enums
{
    public class ComponentsConfiguration
        : TagEnum<ushort>
    {
        public static readonly ComponentsConfiguration Unknown = new ComponentsConfiguration(0, "-");
        public static readonly ComponentsConfiguration Y = new ComponentsConfiguration(1, "Y");
        public static readonly ComponentsConfiguration Cb = new ComponentsConfiguration(2, "Cb");
        public static readonly ComponentsConfiguration Cr = new ComponentsConfiguration(3, "Cr");	   	
        public static readonly ComponentsConfiguration R = new ComponentsConfiguration(4, "R");
        public static readonly ComponentsConfiguration G = new ComponentsConfiguration(5, "G");
        public static readonly ComponentsConfiguration B = new ComponentsConfiguration(6, "B");
        
        
        public ComponentsConfiguration(ushort key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static ComponentsConfiguration FromKey(ushort key)
        {
            switch(key)
            {
                case 0: return Unknown;
                case 1: return Y;
                case 2: return Cb;
                case 3: return Cr;	   	
                case 4: return R;
                case 5: return G;
                case 6: return B;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
