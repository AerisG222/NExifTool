using System;


namespace NExifTool.Writer
{
    public abstract class Operation
    {
        internal const string ListSeparator = "|";
        internal static readonly string ListSeparatorArg = $"-sep \"{ListSeparator}\"";


        public Tag Target { get; }


        public Operation(Tag tag)
        {
            Target = tag ?? throw new ArgumentNullException(nameof(tag));
        }


        internal abstract string ToArg();
    }
}
