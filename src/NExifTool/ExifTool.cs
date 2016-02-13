using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Threading.Tasks;


namespace NExifTool
{
    public class ExifTool
    {
        static readonly string[] SEP_ROW = new string[] { "\n", "\r" };
        static readonly string[] SEP_COL = new string[] { "\t" };
        static readonly string[] SEP_GROUP = new string[] { ":" };
        
        
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
            var lines = output.Split(SEP_ROW, StringSplitOptions.RemoveEmptyEntries);
            
            foreach(var line in lines)
            {
                var cols = line.Split(SEP_COL, StringSplitOptions.RemoveEmptyEntries);
                var tag = new Tag();
                
                var groups = cols[0].Split(SEP_GROUP, StringSplitOptions.RemoveEmptyEntries);
                
                for(int i = 0; i < groups.Length; i++)
                {
                    switch(i)
                    {
                        case 0:
                            tag.GeneralGroup = groups[i];
                            break;
                        case 1:
                            tag.SpecificGroup = groups[i];
                            break;
                        case 2:
                            tag.CategoryGroup = groups[i];
                            break;
                        case 3:
                            tag.DocumentNumberGroup = groups[i];
                            break;
                        case 4:
                            tag.InstanceNumberGroup = groups[i];
                            break;
                    }
                }
                
                if(ExifToolLookup.Details.ContainsKey(cols[1]))
                {
                    tag.TagInfo = ExifToolLookup.Details[cols[1]];
                }
                
                if(cols.Length > 2)
                {
                    tag.Value = cols[2];
                }
                
                yield return tag;
            }
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
                var output = process.StandardOutput.ReadToEnd();
                tcs.SetResult(output);
                process.Dispose();
            };

            process.Start();

            return tcs.Task;
        }
    }
}
