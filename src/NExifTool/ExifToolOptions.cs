namespace NExifTool
{
    public class ExifToolOptions
    {
        public string ExifToolPath { get; set; } = "exiftool";
        public bool IncludeBinaryTags { get; set; }
        public bool EscapeTagValues { get; set; }
    }
}
