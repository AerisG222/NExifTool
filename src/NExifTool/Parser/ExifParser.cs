using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;


namespace NExifTool.Parser
{
    public class ExifParser
    {
        public virtual IEnumerable<Tag> ParseTags(JsonElement? json)
        {
            if(json == null)
            {
                throw new ArgumentNullException(nameof(json));
            }

            var json2 = (JsonElement)json;
            var list = new List<Tag>();

            foreach(var prop in json2.EnumerateObject())
            {
                if(prop.Value.ValueKind != JsonValueKind.Object)
                {
                    // exif tags will be represented as objects,
                    // the first property currently is a string representing the filename
                    continue;
                }

                var tag = Parse(prop.Name, prop.Value);

                if(tag != null)
                {
                    list.Add(tag);
                }
            }

            return list;
        }


        Tag Parse(string objName, JsonElement tagJson)
        {
            var nameSepIndex = objName.LastIndexOf(':');
            var group = objName.Substring(0, nameSepIndex);
            var name = objName.Substring(nameSepIndex + 1);

            string numValue = null;
            string desc = null;
            string table = null;
            string id = null;
            string val = null;
            List<string> list = null;

            foreach(var prop in tagJson.EnumerateObject()) {
                switch(prop.Name) {
                    case "desc":
                        desc = ParseValue(prop.Value);
                        break;
                    case "id":
                        id = ParseValue(prop.Value);
                        break;
                    case "num":
                        numValue = ParseValue(prop.Value);
                        break;
                    case "table":
                        table = ParseValue(prop.Value);
                        break;
                    case "val":
                        val = ParseValue(prop.Value);

                        if(prop.Value.ValueKind == JsonValueKind.Array)
                        {
                            list = prop.Value
                                .EnumerateArray()
                                .Select(x => ParseValue(x))
                                .ToList();
                        }

                        break;
                }
            }

            return new Tag(
                id,
                name,
                desc,
                table,
                group,
                val,
                numValue,
                list
            );
        }


        string ParseValue(JsonElement el)
        {
            switch(el.ValueKind)
            {
                case JsonValueKind.String:
                    return el.GetString();
                case JsonValueKind.Number:
                    return el.GetDouble().ToString();
                case JsonValueKind.Null:
                    return null;
                case JsonValueKind.True:
                    return true.ToString();
                case JsonValueKind.False:
                    return false.ToString();
                default:
                    return el.GetRawText();
            }
        }
    }
}
