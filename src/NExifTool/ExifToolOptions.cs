using System;
using System.Text;
using System.Diagnostics;


namespace NExifTool
{
    public class ExifToolOptions
    {
        public string ExifToolPath { get; set; }

        
        public ProcessStartInfo GetStartInfo(string rawFile)
        {
            var psi = new ProcessStartInfo();
            
            psi.FileName = ExifToolPath;
            
            StringBuilder args = new StringBuilder();
            
            args.Append("-s -t ");
            args.Append(rawFile);
            
            psi.Arguments = args.ToString();
            
            return psi;
        }
    }
}
