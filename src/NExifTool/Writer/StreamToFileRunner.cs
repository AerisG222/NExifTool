using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using Medallion.Shell;


namespace NExifTool.Writer
{
    public class StreamToFileRunner
        : Runner
    {
        readonly Stream _src;
        readonly string _dst;


        public StreamToFileRunner(ExifToolOptions opts, Stream src, string dst)
            : base(opts)
        {
            _src = src ?? throw new ArgumentNullException(nameof(src));
            _dst = dst ?? throw new ArgumentNullException(nameof(dst));
        }


        public override async Task<WriteResult> RunProcessAsync(IEnumerable<Operation> updates)
        {
            var updateArgs = GetUpdateArgs(updates);
            var args = $"{updateArgs} -o {EscapeFilePath(_dst)} -";

            try
            {
                var cmd = Command.Run(_options.ExifToolPath, options: opts => {
                    opts.StartInfo(si => si.Arguments = args);
                }) < _src;

                var result = await cmd.Task.ConfigureAwait(false);

                return new WriteResult(result.Success, null);
            }
            catch (Win32Exception ex)
            {
                throw new Exception("Error when trying to start the exiftool process.  Please make sure exiftool is installed, and its path is properly specified in the options.", ex);
            }
        }
    }
}
