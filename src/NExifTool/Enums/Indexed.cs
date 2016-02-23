using System;


namespace NExifTool.Enums
{
    public class Indexed
        : TagEnum<ushort>
    {
        public static readonly Indexed NotIndexed = new Indexed(0, "Not Indexed");
        public static readonly Indexed IsIndexed = new Indexed(1, "Indexed");
        
        
        public Indexed(ushort key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static Indexed FromKey(ushort key)
        {
            switch(key)
            {
                case 0: return NotIndexed;
                case 1: return IsIndexed;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
