namespace NExifTool.Writer
{
    public class SetOperation
        : Operation
    {
        public SetOperation(Tag tag)
            : base(tag)
        {

        }

        internal override string ToArg() => $"-{Target.Name}=\"{Target.ValueToWrite()}\"";
    }
}