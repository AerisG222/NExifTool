using System;


namespace NExifTool.Enums
{
    public class SceneType
        : TagEnum<ushort>
    {
        public static readonly SceneType DirectlyPhotographed = new SceneType(1, "Directly photographed");
        
        
        public SceneType(ushort key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static SceneType FromKey(ushort key)
        {
            switch(key)
            {
                case 1: return DirectlyPhotographed;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
