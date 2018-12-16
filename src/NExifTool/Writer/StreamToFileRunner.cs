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
            var runner = new StreamToStreamRunner(_options, _src);
            var result = await runner.RunProcessAsync(updates);

            if(result.Success)
            {
                await result.Output.CopyToAsync(new FileStream(_dst, FileMode.CreateNew, FileAccess.ReadWrite));

                return new WriteResult(true, null);
            }

            return new WriteResult(false, null);
        }
    }
}
