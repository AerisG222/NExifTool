using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Linq;


namespace NExifTool.Parser
{
    public class ExifParser
    {
        public virtual IEnumerable<Tag> ParseTags(JObject json)
        {
            var list = new List<Tag>();

            if(json == null)
            {
                throw new ArgumentNullException(nameof(json));
            }

            foreach(var prop in json.Children().Cast<JProperty>())
            {
                if(prop.Value.Type != JTokenType.Object)
                {
                    // exif tags will be represented as objects,
                    // the first property currently is a string representing the filename
                    continue;
                }

                var tag = Parse(prop);

                if(tag != null)
                {
                    list.Add(tag);
                }
            }

            return list;
        }


        Tag Parse(JProperty tagJson)
        {
            var data = tagJson.Value;
            var nameSepIndex = tagJson.Name.LastIndexOf(':');
            var group = tagJson.Name.Substring(0, nameSepIndex);
            var name = tagJson.Name.Substring(nameSepIndex + 1);
            var numValue = data["num"]?.ToString();
            var valJson = data["val"];
            IEnumerable<string> list = null;
            var jarray = valJson as JArray;

            if(jarray != null)
            {
                list = jarray.Select(x => (string)x);
            }

            return new Tag(
                data["id"]?.ToString(),
                name,
                (string)data["desc"],
                (string)data["table"],
                group,
                valJson.ToString(),
                numValue,
                list
            );
        }
    }
}
