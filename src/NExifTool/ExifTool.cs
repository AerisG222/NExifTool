using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Diagnostics;
using System.Threading.Tasks;


namespace NExifTool
{
    public class ExifTool
    {
        Process _process;
        
        
        public ExifToolOptions Options { get; private set; }
        
        
        public ExifTool(ExifToolOptions options)
        {
            Options = options;
        }
        
        
        public IEnumerable<Tag> GetTags(string srcPath)
        {
            return GetTagsAsync(srcPath).Result;
        }
        
        
        public async Task<IEnumerable<Tag>> GetTagsAsync(string srcPath)
        {
            if(!File.Exists(srcPath))
            {
                throw new FileNotFoundException("Please make sure the image exists.", srcPath);
            }
            
            var result = await RunProcessAsync(srcPath);
            var tags = Options.Parser.ParseTags(result.Output);
            
            _process.Dispose();
            
            return tags;
        }
        
        
        // http://stackoverflow.com/questions/10788982/is-there-any-async-equivalent-of-process-start
        Task<ExifToolResult> RunProcessAsync(string fileName)
        {
            var tcs = new TaskCompletionSource<ExifToolResult>();
            
            _process = new Process
            {
                StartInfo = Options.GetStartInfo(fileName),
                EnableRaisingEvents = true
            };

            _process.Exited += (sender, args) =>
            {
                var result = new ExifToolResult {
                    Output = _process.StandardOutput
                };
                
                tcs.SetResult(result);
            };

            try
            {
                _process.Start();
            }
            catch (Win32Exception ex)
            {
                throw new Exception("Error when trying to start the exiftool process.  Please make sure exiftool is installed, and its path is properly specified in the options.", ex);
            }

            return tcs.Task;
        }
    }
}
