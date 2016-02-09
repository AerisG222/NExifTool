using System;
using System.Text;
using System.Diagnostics;


namespace NExifTool
{
    public class ExifToolOptions
    {
        public string ExifToolPath { get; set; } = "exiftool";

        
        public ProcessStartInfo GetStartInfo(string rawFile)
        {
            var psi = new ProcessStartInfo();
            
            psi.FileName = ExifToolPath;
            psi.UseShellExecute = false;
            psi.RedirectStandardOutput = true;
            
            StringBuilder args = new StringBuilder();
            
            // odd, man page does not list the 5, but i seem to need this
            // for the test file
            args.Append("-s -G:0:1:2:3:4:5 -t ");
            args.Append(rawFile);
            
            psi.Arguments = args.ToString();
            
            return psi;
        }
    }
}
