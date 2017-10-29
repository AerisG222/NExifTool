using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using Medallion.Shell;
using NExifTool.Writer;


namespace NExifTool
{
    public class ExifTool
    {
        public ExifToolOptions Options { get; private set; }
        
        
        public ExifTool(ExifToolOptions options)
        {
            Options = options;
        }
        
        
        public Task<IEnumerable<Tag>> GetTagsAsync(string srcPath)
        {
            VerifySourceFile(srcPath);
            
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


        public void OverwriteTagsAsync(string srcPath, IEnumerable<TagUpdateSpec> updates)
        {
            VerifySourceFile(srcPath);
        }


        public Stream OverwriteTagsAsync(Stream src, IEnumerable<TagUpdateSpec> updates)
        {

        }


        public void WriteTagsAsync(string srcPath, IEnumerable<TagUpdateSpec> updates, string dstPath)
        {
            VerifySourceFile(srcPath);
        }


        public Stream WriteTagsAsync(string srcPath, IEnumerable<TagUpdateSpec> updates)
        {
            VerifySourceFile(srcPath);
        }


        public void WriteTagsAsync(Stream stream, IEnumerable<TagUpdateSpec> updates)
        {

        }


        public void WriteTagsAsync(Stream stream, IEnumerable<TagUpdateSpec> updates, string dstPath)
        {

        }


        void VerifySourceFile(string srcPath)
        {
            if(!File.Exists(srcPath))
            {
                throw new FileNotFoundException("Please make sure the image exists.", srcPath);
            }
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


        async Task RunWriteProcessAsync(string srcPath)
        {

        }
    }
}
