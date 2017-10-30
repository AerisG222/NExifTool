using System;


namespace NExifTool.Writer
{
    public class AddOperation
        : Operation
    {
        public string Value { get; private set; }

        public AddOperation(string target, string value)
            : base(target)
        {
            if(string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentNullException(nameof(value));
            }

            Value = value;
        }


        internal override string ToArg() => $"-{Target}+={Value}";
    }
}