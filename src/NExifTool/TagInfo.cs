using System;


namespace NExifTool
{
    public class TagInfo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ValueType { get; set; }
        public string TableName { get; set; }
        public string GeneralGroup { get; set; }
        public string SpecificGroup { get; set; }
        public string CategoryGroup { get; set; }
        
        
        public bool IsGps
        {
            get
            {
                return TableName.StartsWith("GPS", StringComparison.OrdinalIgnoreCase);
            }
        }
        
        
        public bool IsNikon
        {
            get
            {
                return TableName.StartsWith("Nikon", StringComparison.OrdinalIgnoreCase); 
            }
        }
        
        
        public bool IsExif
        {
            get
            {
                return TableName.StartsWith("EXIF", StringComparison.OrdinalIgnoreCase);
            }
        }
        
        
        internal string LookupKey
        {
            get
            {
                return GenerateLookupKey(TableName, Id);
            }
        }
        
        
        static internal string GenerateLookupKey(string tableName, string tagId)
        {
            return $"{tableName}::{tagId}".ToLower();
        }
    }
}
