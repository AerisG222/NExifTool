using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Medallion.Shell;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace NExifTool.Reader
{
    public class ExifReader
    {
        readonly ExifToolOptions _opts;


        public ExifReader(ExifToolOptions opts)
        {
            _opts = opts ?? throw new ArgumentNullException(nameof(opts));
        }


        public async Task<JObject> ReadExifAsync(Stream imageStream)
        {
            var args = GetArguments(imageStream);
            var exifDataStream = await GetExifDataAsync(args, imageStream).ConfigureAwait(false);

            return await GetJsonAsync(exifDataStream).ConfigureAwait(false);
        }


        public async Task<JObject> ReadExifAsync(string imagePath)
        {
            var args = GetArguments(imagePath);
            var exifDataStream = await GetExifDataAsync(args, null).ConfigureAwait(false);

            return await GetJsonAsync(exifDataStream).ConfigureAwait(false);
        }


        async Task<JObject> GetJsonAsync(Stream exifDataStream)
        {
            JToken token = null;

            using(var sr = new StreamReader(exifDataStream))
            {
                token = await JToken.ReadFromAsync(new JsonTextReader(sr)).ConfigureAwait(false);
            }

            if(token == null)
            {
                return null;
            }

            if(token.Children().Count() == 1)
            {
                return token.Children().First() as JObject;
            }

            return null;
        }


        async Task<Stream> GetExifDataAsync(string[] args, Stream stream)
        {
            Command cmd = null;

            try
            {
                if(stream == null)
                {
                    cmd = Command.Run(_opts.ExifToolPath, args);
                }
                else
                {
                    cmd = Command.Run(_opts.ExifToolPath, args) < stream;
                }

                await cmd.Task.ConfigureAwait(false);

                return cmd.StandardOutput.BaseStream;
            }
            catch (Win32Exception ex)
            {
                throw new Exception("Error when trying to start the exiftool process.  Please make sure exiftool is installed, and its path is properly specified in the options.", ex);
            }
        }


        string[] GetArguments(string rawFile)
        {
            var args = GetDefaultArguments();

            args.Add(rawFile);

            return args.ToArray();
        }


        string[] GetArguments(Stream stream)
        {
            var args = GetDefaultArguments();

            args.Add("-");

            return args.ToArray();
        }


        List<string> GetDefaultArguments()
        {
            var list = new List<string>
            {
                "-j",
                "-t",
                "-l",
                "-G:0:1:2:3:4",
                "-ALL",
                "-ALL#"
            };

            if(_opts.IncludeBinaryTags)
            {
                list.Add("-b");
            }

            if(_opts.EscapeTagValues)
            {
                list.Add("-E");
            }

            return list;
        }
    }
}