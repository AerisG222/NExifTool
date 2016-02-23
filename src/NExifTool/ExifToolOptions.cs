using System;
using System.Text;
using System.Diagnostics;
using NExifTool.Parser;


namespace NExifTool
{
    public class ExifToolOptions
    {
        IExifParser _exifParser = new ExifParser();
        
        
        public string ExifToolPath { get; set; } = "exiftool";
        
        
        public IExifParser Parser
        { 
            get
            {
                return _exifParser;
            }
            set
            {
                _exifParser = value == null ? new ExifParser() : value;
            }
        }
        
        
        public ProcessStartInfo GetStartInfo(string rawFile)
        {
            var psi = new ProcessStartInfo();
            
            psi.FileName = ExifToolPath;
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            
            StringBuilder args = new StringBuilder();
            
            // 1. odd, man page does not list the 5 for groups
            // 2. ALL and ALL# will pull both text and number values
            args.Append("-s -ALL -ALL# -G:0:1:2:3:4:5 -t ");
            args.Append(rawFile);
            
            psi.Arguments = args.ToString();
            
            return psi;
        }
    }
}
