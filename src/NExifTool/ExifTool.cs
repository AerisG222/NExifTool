using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
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


        public Task<WriteResult> OverwriteTagsAsync(string srcPath, IEnumerable<Operation> updates)
        {
            VerifySourceFile(srcPath);
            VerifyUpdates(updates);

            var runner = new FileToFileRunner(Options, srcPath, srcPath, true);

            return runner.RunProcessAsync(updates);
        }


        public Task<WriteResult> WriteTagsAsync(string srcPath, IEnumerable<Operation> updates, string dstPath)
        {
            VerifySourceFile(srcPath);
            VerifyUpdates(updates);

            var runner = new FileToFileRunner(Options, srcPath, dstPath, false);

            return runner.RunProcessAsync(updates);
        }


        public Task<WriteResult> WriteTagsAsync(string srcPath, IEnumerable<Operation> updates)
        {
            VerifySourceFile(srcPath);
            VerifyUpdates(updates);

            var runner = new FileToStreamRunner(Options, srcPath);

            return runner.RunProcessAsync(updates);
        }


        public Task<WriteResult> WriteTagsAsync(Stream src, IEnumerable<Operation> updates)
        {
            VerifyUpdates(updates);

            var runner = new StreamToStreamRunner(Options, src);

            return runner.RunProcessAsync(updates);
        }


        public Task<WriteResult> WriteTagsAsync(Stream src, IEnumerable<Operation> updates, string dstPath)
        {
            VerifyUpdates(updates);

            var runner = new StreamToFileRunner(Options, src, dstPath);

            return runner.RunProcessAsync(updates);
        }


        void VerifySourceFile(string srcPath)
        {
            if(!File.Exists(srcPath))
            {
                throw new FileNotFoundException("Please make sure the image exists.", srcPath);
            }
        }


        void VerifyUpdates(IEnumerable<Operation> updates)
        {
            if(updates == null)
            {
                throw new ArgumentNullException();
            }

            if(updates.Count() == 0)
            {
                throw new ArgumentException("No update operations specified!", nameof(updates));
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
    }
}
