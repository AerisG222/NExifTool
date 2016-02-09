using System;


namespace NExifTool
{
    public class Tag
    {
        public string GeneralGroup { get; set; }
        public string SpecificGroup { get; set; }
        public string CategoryGroup { get; set; }
        public string DocumentNumberGroup { get; set; }
        public string InstanceNumberGroup { get; set; }
        public TagInfo TagInfo { get; set; }
        public string Value { get; set; }
    }
}
