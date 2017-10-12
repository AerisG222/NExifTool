using System.Collections.Generic;
using System.IO;
using NExifTool.Parser;


namespace NExifTool
{
    public class ExifToolOptions
    {
        IExifParser _exifParser = new ExifParser();
        bool _quiet;
        
        
        public string ExifToolPath { get; set; } = "exiftool";
        
        public bool Quiet 
        { 
            get
            {
                return _quiet;
            } 
            set
            {
                _quiet = value;
                _exifParser.Quiet = value;
            }
        }
        
        
        public IExifParser Parser
        { 
            get
            {
                return _exifParser;
            }
            set
            {
                _exifParser = value == null ? new ExifParser() : value;
                _exifParser.Quiet = Quiet;
            }
        }
        
        
        public string[] GetArguments(string rawFile)
        {
            var args = GetDefaultArguments();

            args.Add(rawFile);

            return args.ToArray();
        }


        public string[] GetArguments(Stream stream)
        {
            var args = GetDefaultArguments();

            args.Add("-");

            return args.ToArray();
        }
        

        List<string> GetDefaultArguments()
        {
            var list = new List<string>();

            list.Add("-X");
            list.Add("-t");
            list.Add("-ALL");
            list.Add("-ALL#");

            return list;
        }
    }
}
