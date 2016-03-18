using System;
using System.Text;
using System.Diagnostics;
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
        
        
        public ProcessStartInfo GetStartInfo(string rawFile)
        {
            var psi = new ProcessStartInfo();
            
            psi.FileName = ExifToolPath;
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            
            StringBuilder args = new StringBuilder();
            
            // xml seems to be the only one to dump table names and tag ids needed for lookup
            args.Append("-X -t -ALL -ALL# ");
            args.Append(EscapeFilename(rawFile));
            
            psi.Arguments = args.ToString();
            
            return psi;
        }
        
        
        string EscapeFilename(string file)
        {
            return $"\"{file}\"";
        }
    }
}
