using System.IO;
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
            var psi = BuildStartInfo();

            psi.Arguments = $"{psi.Arguments} {EscapeFilename(rawFile)}";

            return psi;
        }


        public ProcessStartInfo GetStartInfo(Stream stream)
        {
            var psi = BuildStartInfo();

            psi.Arguments = $"{psi.Arguments} -";
            psi.RedirectStandardInput = true;

            return psi;
        }
        

        ProcessStartInfo BuildStartInfo()
        {
            var psi = new ProcessStartInfo();
            
            psi.FileName = ExifToolPath;
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            psi.Arguments = "-X -t -ALL -ALL#";

            return psi;
        }

        
        string EscapeFilename(string file)
        {
            return $"\"{file}\"";
        }
    }
}
