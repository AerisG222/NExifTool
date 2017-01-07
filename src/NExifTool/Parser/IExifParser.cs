using System.Collections.Generic;
using System.IO;


namespace NExifTool.Parser
{
    public interface IExifParser
    {
        bool Quiet { get; set; }
        IList<Tag> ParseTags(StreamReader reader);
    }
}
