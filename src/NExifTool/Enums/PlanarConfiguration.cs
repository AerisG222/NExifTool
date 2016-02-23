using System;


namespace NExifTool.Enums
{
    public class PlanarConfiguration
        : TagEnum<ushort>
    {
        public static readonly PlanarConfiguration Chunky = new PlanarConfiguration(1, "Chunky");
        public static readonly PlanarConfiguration Planar = new PlanarConfiguration(2, "Planar");
        
        
        public PlanarConfiguration(ushort key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static PlanarConfiguration FromKey(ushort key)
        {
            switch(key)
            {
                case 1: return Chunky;
                case 2: return Planar;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
