namespace NExifTool.Enums
{
    // 'enums' in this area derived from www.sno.phy.queensu.ca/~phil/exiftool/TagNames/EXIF.html
    public class TagEnum<T>
    {
        public T Key { get; private set; }
        public string Description { get; private set; }
        
        
        protected TagEnum(T key, string description)
        {
            Key = key;
            Description = description;
        }
    }
}
