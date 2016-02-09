using System;
using System.Linq;
using Xunit;
using NExifTool;


namespace NExifTool.Tests
{
    public class Test
    {
        [Fact]
        public async void GetTagsFromImage()
        {
            var et = new ExifTool(new ExifToolOptions());
            
            var res = await et.GetTagsAsync("DSC_3982.NEF");
            
            foreach(var tag in res)
            {
                Console.WriteLine(tag.TagInfo.Description + " ~ " + tag.Value);
            }
            
            Assert.True(res.Count() > 0);
        }
    }
}
