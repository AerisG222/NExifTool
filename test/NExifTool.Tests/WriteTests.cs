using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;
using NExifTool.Enums;
using NExifTool.Writer;


namespace NExifTool.Tests
{
    public class WriteTests
    {
        const string SRC_FILE = "space test.jpg";

        // japanese string taken from here: https://stackoverflow.com/questions/2627891/does-process-startinfo-arguments-support-a-utf-8-string
        const string COMMENT = "\"this is a これはテストです test\"";  // note: it is currently up to the consumer to properly escape  values if needed

        readonly List<Operation> UPDATES = new List<Operation> {
            new SetOperation("comment", COMMENT)
        };


        [Fact]
        public async void StreamToStreamWriteTest()
        {
            var opts = new ExifToolOptions();
            var et = new ExifTool(opts);
            var src = new FileStream(SRC_FILE, FileMode.Open);

            var result = await et.WriteTagsAsync(src, UPDATES);

            Assert.True(result.Success);
            Assert.NotNull(result.Output);

            ValidateTag(await et.GetTagsAsync(result.Output));
        }


        [Fact]
        public async void StreamToFileWriteTest()
        {
            var opts = new ExifToolOptions();
            var et = new ExifTool(opts);
            var src = new FileStream(SRC_FILE, FileMode.Open);

            var result = await et.WriteTagsAsync(src, UPDATES, "stream_to_file_test.jpg");

            Assert.True(result.Success);
            Assert.Null(result.Output);

            ValidateTag(await et.GetTagsAsync("stream_to_file_test.jpg"));
        }


        [Fact]
        public async void FileToStreamWriteTest()
        {
            var opts = new ExifToolOptions();
            var et = new ExifTool(opts);

            var result = await et.WriteTagsAsync(SRC_FILE, UPDATES);

            Assert.True(result.Success);
            Assert.NotNull(result.Output);

            ValidateTag(await et.GetTagsAsync(result.Output));
        }


        [Fact]
        public async void FileToFileWriteTest()
        {
            var opts = new ExifToolOptions();
            var et = new ExifTool(opts);

            var result = await et.WriteTagsAsync(SRC_FILE, UPDATES, "file_to_file_test.jpg");

            Assert.True(result.Success);
            Assert.Null(result.Output);

            ValidateTag(await et.GetTagsAsync("file_to_file_test.jpg"));

            File.Delete("file_to_file_test.jpg");
        }


        [Fact]
        public async void OverwriteTest()
        {
            File.Copy(SRC_FILE, "overwrite_test.jpg");

            var opts = new ExifToolOptions();
            var et = new ExifTool(opts);

            var result = await et.OverwriteTagsAsync("overwrite_test.jpg", UPDATES);

            Assert.True(result.Success);
            Assert.Null(result.Output);

            ValidateTag(await et.GetTagsAsync("overwrite_test.jpg"));

            File.Delete("overwrite_test.jpg");
        }


        void ValidateTag(IEnumerable<Tag> tags)
        {
            var tag = tags.SingleOrDefault(x => string.Equals(x.TagInfo.Name, "comment", StringComparison.OrdinalIgnoreCase));

            Assert.NotNull(tag);
            Assert.Equal(COMMENT.Replace("\"", string.Empty), tag.Value);
        }
    }
}
