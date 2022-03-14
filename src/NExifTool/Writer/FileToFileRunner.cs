using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using Medallion.Shell;


namespace NExifTool.Writer
{
    public class FileToFileRunner
        : Runner
    {
        readonly string _src;
        readonly string _dst;
        readonly bool _overwrite;
        readonly OverwriteMode? _overwriteMode;

        public FileToFileRunner(ExifToolOptions opts, string src, string dst, bool overwrite)
            : base(opts)
        {
            _src = src ?? throw new ArgumentNullException(nameof(src));
            _dst = dst ?? throw new ArgumentNullException(nameof(dst));
            _overwrite = overwrite;
        }

        public FileToFileRunner(ExifToolOptions opts, string src, string dst, bool overwrite, OverwriteMode? overwriteMode)
            : base(opts)
        {
            _src = src ?? throw new ArgumentNullException(nameof(src));
            _dst = dst ?? throw new ArgumentNullException(nameof(dst));
            _overwrite = overwrite;
            _overwriteMode = overwriteMode;
        }

        public override async Task<WriteResult> RunProcessAsync(IEnumerable<Operation> updates)
        {
            var updateArgs = GetUpdateArgs(updates);
            string args = null;

            if(_overwrite)
            {
                args = $"{updateArgs} {ParseOverwriteMode(_overwriteMode)} {EscapeFilePath(_src)}";
            }
            else
            {
                args = $"{updateArgs} -o {EscapeFilePath(_dst)} {EscapeFilePath(_src)}";
            }

            try
            {
                var cmd = Command.Run(_options.ExifToolPath, options: opts => {
                    opts.StartInfo(si => si.Arguments = args);
                });

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
