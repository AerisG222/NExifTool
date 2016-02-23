using System;


namespace NExifTool.Enums
{
    public class DefaultBlackRender
        : TagEnum<ushort>
    {
        public static readonly DefaultBlackRender Auto = new DefaultBlackRender(0, "Auto");
        public static readonly DefaultBlackRender None = new DefaultBlackRender(1, "None");
        
        
        public DefaultBlackRender(ushort key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static DefaultBlackRender FromKey(ushort key)
        {
            switch(key)
            {
                case 0: return Auto;
                case 1: return None;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
