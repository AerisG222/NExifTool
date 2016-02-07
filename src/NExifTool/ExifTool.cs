using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Threading.Tasks;


namespace NExifTool
{
	public class ExifTool
	{
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
            
            var output = await RunProcessAsync(srcPath);
             
            return ParseOutput(output);
        }
        
        
        IEnumerable<Tag> ParseOutput(string output)
        {
            return null;
        }
        
        
        // TODO: what if we want to specify a timeout?
        // http://stackoverflow.com/questions/10788982/is-there-any-async-equivalent-of-process-start
        Task<string> RunProcessAsync(string fileName)
        {
            var tcs = new TaskCompletionSource<string>();
            
            var process = new Process
            {
                StartInfo = Options.GetStartInfo(fileName),
                EnableRaisingEvents = true
            };

            process.Exited += (sender, args) =>
            {
                tcs.SetResult(output);
                process.Dispose();
            };

            process.Start();

            return tcs.Task;
        }
	}
}
