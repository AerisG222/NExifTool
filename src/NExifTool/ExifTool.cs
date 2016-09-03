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
        

        public IEnumerable<Tag> GetTags(Stream stream)
        {
            return GetTagsAsync(stream).Result;
        }

        
        public async Task<IEnumerable<Tag>> GetTagsAsync(string srcPath)
        {
            if(!File.Exists(srcPath))
            {
                throw new FileNotFoundException("Please make sure the image exists.", srcPath);
            }
            
            var psi = Options.GetStartInfo(srcPath);
            var result = await RunProcessAsync(psi, null);
            
            return ParseTags(result);
        }
        

        public async Task<IEnumerable<Tag>> GetTagsAsync(Stream stream)
        {
            if(stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            var psi = Options.GetStartInfo(stream);
            var result = await RunProcessAsync(psi, stream);

            return ParseTags(result);
        }


        IEnumerable<Tag> ParseTags(ExifToolResult result)
        {
            var tags = Options.Parser.ParseTags(result.Output);
            
            _process.Dispose();
            
            return tags;
        }

        
        // http://stackoverflow.com/questions/10788982/is-there-any-async-equivalent-of-process-start
        Task<ExifToolResult> RunProcessAsync(ProcessStartInfo psi, Stream stream)
        {
            var tcs = new TaskCompletionSource<ExifToolResult>();
            
            _process = new Process
            {
                StartInfo = psi,
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

                if(stream != null)
                {
                    stream.CopyTo(_process.StandardInput.BaseStream);
                    _process.StandardInput.Flush();
                    _process.StandardInput.Dispose();
                }
            }
            catch (Win32Exception ex)
            {
                throw new Exception("Error when trying to start the exiftool process.  Please make sure exiftool is installed, and its path is properly specified in the options.", ex);
            }

            return tcs.Task;
        }
    }
}
