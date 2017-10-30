using System;


namespace NExifTool.Writer
{
    public abstract class Operation
    {
        public string Target { get; private set; }


        public Operation(string target)
        {
            if(string.IsNullOrWhiteSpace(target))
            {
                throw new ArgumentNullException(nameof(target));
            }

            Target = target;
        }


        internal abstract string ToArg();
    }
}
