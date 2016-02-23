using System;
using System.Collections.Generic;
using System.IO;


namespace NExifTool.Parser
{
    public interface IExifParser
    {
        IList<Tag> ParseTags(StreamReader reader);
    }
}
