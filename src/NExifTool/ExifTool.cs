using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using NExifTool.Parser;
using NExifTool.Reader;
using NExifTool.Writer;

namespace NExifTool
{
    public class ExifTool
    {
        readonly ExifToolOptions _opts;

        public ExifTool(ExifToolOptions opts)
        {
            _opts = opts ?? throw new ArgumentNullException(nameof(opts));
        }

        public async Task<IEnumerable<Tag>> GetTagsAsync(string srcPath)
        {
            VerifySourceFile(srcPath);

            var reader = new ExifReader(_opts);
            var parser = new ExifParser();
            var exifJson = await reader.ReadExifAsync(srcPath).ConfigureAwait(false);

            return parser.ParseTags(exifJson);
        }

        public async Task<IEnumerable<Tag>> GetTagsAsync(Stream stream)
        {
            if(stream == null)
            {
                throw new ArgumentNullException(nameof(stream));
            }

            var reader = new ExifReader(_opts);
            var parser = new ExifParser();
            var exifJson = await reader.ReadExifAsync(stream).ConfigureAwait(false);

            return parser.ParseTags(exifJson);
        }

        public Task<WriteResult> OverwriteTagsAsync(string srcPath, IEnumerable<Operation> updates, FileWriteMode writeMode)
        {
            VerifySourceFile(srcPath);
            VerifyUpdates(updates);

            var runner = new FileToFileRunner(_opts, srcPath, writeMode);

            return runner.RunProcessAsync(updates);
        }

        public Task<WriteResult> WriteTagsAsync(string srcPath, IEnumerable<Operation> updates, string dstPath)
        {
            VerifySourceFile(srcPath);
            VerifyUpdates(updates);

            var runner = new FileToFileRunner(_opts, srcPath, dstPath);

            return runner.RunProcessAsync(updates);
        }

        public Task<WriteResult> WriteTagsAsync(string srcPath, IEnumerable<Operation> updates)
        {
            VerifySourceFile(srcPath);
            VerifyUpdates(updates);

            var runner = new FileToStreamRunner(_opts, srcPath);

            return runner.RunProcessAsync(updates);
        }

        public Task<WriteResult> WriteTagsAsync(Stream src, IEnumerable<Operation> updates)
        {
            VerifyUpdates(updates);

            var runner = new StreamToStreamRunner(_opts, src);

            return runner.RunProcessAsync(updates);
        }

        public Task<WriteResult> WriteTagsAsync(Stream src, IEnumerable<Operation> updates, string dstPath)
        {
            VerifyUpdates(updates);

            var runner = new StreamToFileRunner(_opts, src, dstPath);

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
    }
}
