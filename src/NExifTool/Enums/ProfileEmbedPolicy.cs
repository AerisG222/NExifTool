using System;


namespace NExifTool.Enums
{
    public class ProfileEmbedPolicy
        : TagEnum<ushort>
    {
        public static readonly ProfileEmbedPolicy AllowCopying = new ProfileEmbedPolicy(0, "Allow Copying");
        public static readonly ProfileEmbedPolicy EmbedIfUsed = new ProfileEmbedPolicy(1, "Embed if Used");
        public static readonly ProfileEmbedPolicy NeverEmbed = new ProfileEmbedPolicy(2, "Never Embed");
        public static readonly ProfileEmbedPolicy NoRestrictions = new ProfileEmbedPolicy(3, "No Restrictions");

        
        public ProfileEmbedPolicy(ushort key, string description)
            : base(key, description)
        {
            
        }
        
        
        public static ProfileEmbedPolicy FromKey(ushort key)
        {
            switch(key)
            {
                case 0: return AllowCopying;
                case 1: return EmbedIfUsed;
                case 2: return NeverEmbed;
                case 3: return NoRestrictions;
            }
            
            throw new ArgumentOutOfRangeException(nameof(key));
        }
    }
}
