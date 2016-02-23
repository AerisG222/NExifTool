using System;


namespace NExifTool.Enums
{
    public class CleanFaxData
        : TagEnum<ushort>
    {
        public static readonly CleanFaxData Clean = new CleanFaxData(0, "Clean");
        public static readonly CleanFaxData Regenerated = new CleanFaxData(1, "Regenerated");
        public static readonly CleanFaxData Unclean = new CleanFaxData(2, "Unclean");
        
        
        public CleanFaxData(ushort key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static CleanFaxData FromKey(ushort key)
        {
            switch(key)
            {
                case 0: return Clean;
                case 1: return Regenerated;
                case 2: return Unclean;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
