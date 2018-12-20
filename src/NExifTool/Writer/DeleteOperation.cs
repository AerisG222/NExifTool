using System;


namespace NExifTool.Writer
{
    public class DeleteOperation
        : Operation
    {
        public DeleteOperation(Tag tag)
            : base(tag)
        {

        }


        internal override string ToArg() => $"-{Target.Name}=";
    }
}