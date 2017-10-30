using System;


namespace NExifTool.Writer
{
    public class DeleteOperation
        : Operation
    {
        public DeleteOperation(string target)
            : base(target)
        {

        }


        internal override string ToArg() => $"-{Target}=";
    }
}