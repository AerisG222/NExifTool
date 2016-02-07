using System;


namespace NExifTool
{
    public class Tag<T>
    {
        public TagInfo TagInfo { get; set; }
        public T Value { get; set; }
    }
}
