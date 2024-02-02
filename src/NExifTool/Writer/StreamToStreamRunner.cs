using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using Medallion.Shell;

namespace NExifTool.Writer
{
    public class StreamToStreamRunner
        : Runner
    {
        readonly Stream _src;

        public StreamToStreamRunner(ExifToolOptions opts, Stream src)
            : base(opts)
        {
            _src = src ?? throw new ArgumentNullException(nameof(src));
        }

        public override async Task<WriteResult> RunProcessAsync(IEnumerable<Operation> updates)
        {
            var updateArgs = GetUpdateArgs(updates);
            var args = $"{updateArgs} -o - -";
            var ms = new MemoryStream();

            try
            {
                var cmd = Command.Run(_options.ExifToolPath, options: opts => {
                    opts.StartInfo(si => si.Arguments = args);
                }) < _src > ms;

                var result = await cmd.Task.ConfigureAwait(false);

                ms.Seek(0, SeekOrigin.Begin);

                return new WriteResult(result.Success, ms);
            }
            catch (Win32Exception ex)
            {
                throw new Exception("Error when trying to start the exiftool process.  Please make sure exiftool is installed, and its path is properly specified in the options.", ex);
            }
        }
    }
}
