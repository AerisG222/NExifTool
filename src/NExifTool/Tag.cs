using System;


namespace NExifTool
{
    public class Tag
    {
        public TagGroup TagGroup { get; set; }
        public TagInfo TagInfo { get; set; }
        public string Value { get; set; }
    }
}
