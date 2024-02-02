using System.IO;

namespace NExifTool.Writer
{
    public class WriteResult
    {
        public bool Success { get; private set; }
        public Stream Output { get; private set; }

        public WriteResult(bool success, Stream output)
        {
            Success = success;
            Output = output;
        }
    }
}
