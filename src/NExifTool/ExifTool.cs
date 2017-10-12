using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using Medallion.Shell;


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
        

        public IEnumerable<Tag> GetTags(Stream stream)
        {
            return GetTagsAsync(stream).Result;
        }

        
        public Task<IEnumerable<Tag>> GetTagsAsync(string srcPath)
        {
            if(!File.Exists(srcPath))
            {
                throw new FileNotFoundException("Please make sure the image exists.", srcPath);
            }
            
            var args = Options.GetArguments(srcPath);
            return RunProcessAsync(args, null);
        }
        

        public Task<IEnumerable<Tag>> GetTagsAsync(Stream stream)
        {
            if(stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            var args = Options.GetArguments(stream);
            return RunProcessAsync(args, stream);
        }


        IEnumerable<Tag> ParseTags(StreamReader output)
        {
            return Options.Parser.ParseTags(output);
        }

        
        async Task<IEnumerable<Tag>> RunProcessAsync(string[] args, Stream stream)
        {
            Command cmd = null;

            try
            {
                if(stream == null)
                {
                    cmd = Command.Run(Options.ExifToolPath, args);
                }
                else
                {
                    cmd = Command.Run(Options.ExifToolPath, args) < stream;
                }

                await cmd.Task;

                var sr = new StreamReader(cmd.StandardOutput.BaseStream);
                return ParseTags(sr);
            }
            catch (Win32Exception ex)
            {
                throw new Exception("Error when trying to start the exiftool process.  Please make sure exiftool is installed, and its path is properly specified in the options.", ex);
            }
        }
    }
}
