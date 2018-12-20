using System;


namespace NExifTool.Writer
{
    public class SubtractOperation
        : Operation
    {
        public SubtractOperation(Tag tag)
            : base(tag)
        {

        }


        internal override string ToArg() => $"-{Target.Name}-=\"{Target.ValueToWrite()}\"";
    }
}