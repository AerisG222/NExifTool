using System;


namespace NExifTool.Writer
{
    public class AddOperation
        : Operation
    {
        public AddOperation(Tag tag)
            : base(tag)
        {

        }


        internal override string ToArg() => $"-{Target.Name}+=\"{Target.ValueToWrite()}\"";
    }
}