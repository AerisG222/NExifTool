using System;


namespace NExifTool.Writer
{
    public class TagUpdateSpec
    {
        public string Target { get; private set; }
        public WriteOperation Operation { get; private set; }
        public string Value { get; private set; }


        public TagUpdateSpec(string target, string value, WriteOperation operation = WriteOperation.Set)
        {
            if(string.IsNullOrWhiteSpace(target))
            {
                throw new ArgumentNullException(nameof(target));
            }

            Target = target;
        }


        public string ToCommandlineArg()
        {
            switch(Operation)
            {
                case WriteOperation.Add:
                    return $"-{Target}+={Value}";
                case WriteOperation.Delete:
                    return $"-{Target}=";
                case WriteOperation.Set:
                    return $"-{Target}={Value}";
                case WriteOperation.Subtract:
                    return $"-{Target}-={Value}";
            }

            throw new InvalidOperationException();
        }
    }
}
