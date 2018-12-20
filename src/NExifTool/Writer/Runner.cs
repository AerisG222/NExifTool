using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace NExifTool.Writer
{
    public abstract class Runner
    {
        protected readonly ExifToolOptions _options;


        public Runner(ExifToolOptions opts)
        {
            _options = opts ?? throw new ArgumentNullException(nameof(opts));
        }


        protected string GetUpdateArgs(IEnumerable<Operation> updates)
        {
            var sb = new StringBuilder();

            sb.Append($"{Operation.ListSeparatorArg} ");

            foreach(var update in updates)
            {
                sb.Append($"{update.ToArg()} ");
            }

            return sb.ToString();
        }


        protected string EscapeFilePath(string filename)
        {
            return $"\"{filename}\"";
        }


        public abstract Task<WriteResult> RunProcessAsync(IEnumerable<Operation> updates);
    }
}
