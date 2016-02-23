using System;


namespace NExifTool.Enums
{
    public class CFALayout
        : TagEnum<ushort>
    {
        public static readonly CFALayout Rectangular = new CFALayout(1, "Rectangular");
        public static readonly CFALayout EvenColumnsOffsetDownHalfRow = new CFALayout(2, "Even columns offset down 1/2 row");
        public static readonly CFALayout EvenColumnsOffsetUpHalfRow = new CFALayout(3, "Even columns offset up 1/2 row");
        public static readonly CFALayout EvenRowsOffsetRightHalfColumn = new CFALayout(4, "Even rows offset right 1/2 column");
        public static readonly CFALayout EvenRowsOffsetLeftHalfRow = new CFALayout(5, "Even rows offset left 1/2 column");
        public static readonly CFALayout EvenRowsUpHalfRowEvenColumnsLeftHalfColumn = new CFALayout(6, "Even rows offset up by 1/2 row, even columns offset left by 1/2 column");
        public static readonly CFALayout EvenRowsUpHalfRowEvenColumnsRightHalfColumn = new CFALayout(7, "Even rows offset up by 1/2 row, even columns offset right by 1/2 column");
        public static readonly CFALayout EvenRowsDownHalfRowEvenColumnsLeftHalfColumn = new CFALayout(8, "Even rows offset down by 1/2 row, even columns offset left by 1/2 column");
        public static readonly CFALayout EvenRowsDownHalfRowEvenColumnsRightHalfColumn = new CFALayout(9, "Even rows offset down by 1/2 row, even columns offset right by 1/2 column");
        
        
        public CFALayout(ushort key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static CFALayout FromKey(ushort key)
        {
            switch(key)
            {
                case 1: return Rectangular;
                case 2: return EvenColumnsOffsetDownHalfRow;
                case 3: return EvenColumnsOffsetUpHalfRow;
                case 4: return EvenRowsOffsetRightHalfColumn;
                case 5: return EvenRowsOffsetLeftHalfRow;
                case 6: return EvenRowsUpHalfRowEvenColumnsLeftHalfColumn;
                case 7: return EvenRowsUpHalfRowEvenColumnsRightHalfColumn;
                case 8: return EvenRowsDownHalfRowEvenColumnsLeftHalfColumn;
                case 9: return EvenRowsDownHalfRowEvenColumnsRightHalfColumn;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
