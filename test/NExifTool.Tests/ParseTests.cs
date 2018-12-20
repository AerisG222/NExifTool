using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;
using NExifTool;


namespace NExifTool.Tests
{
    public class ParseTests
    {
        [Fact]
        public async void HasExtensionTags()
        {
            var et = new ExifTool(new ExifToolOptions());
            var tags = await et.GetTagsAsync("35781602-96011d02-09ec-11e8-9335-aaa98042aa5a.jpg");

            var res = tags
                .Where(x => x.Id.StartsWith("apple"))
                .ToList();

            foreach(var tag in res)
            {
                Console.WriteLine($"{tag.Id} : {tag.Name} : {tag.Description} : {tag.Value}");
            }

            Assert.True(res.Count() > 0, "HasExtensionTags::1");
            Assert.True(res.Count(x => x.Id == "apple-fi:RegionsRegionListExtensionsAngleInfoYaw" ) >= 1, "HasExtensionTags::2");
            Assert.True(res.Count(x => x.Name == "RegionExtensionsAngleInfoYaw" ) >= 1, "HasExtensionTags::3");
        }


        [Fact]
        public async void GetTagsFromImage()
        {
            var et = new ExifTool(new ExifToolOptions());

            var res = (await et.GetTagsAsync("DSC_3982.NEF")).ToList();

            foreach(var tag in res)
            {
                Console.WriteLine($"{tag.Name} : {tag.Description} : {tag.Value}");
            }

            Assert.True(res.Count() > 0);
        }


        [Fact]
        public async void GetTagsFromImageWithKeywords()
        {
            var et = new ExifTool(new ExifToolOptions());

            var res = (await et.GetTagsAsync("50032922-56e5cc00-ffee-11e8-9cc9-a1330b3a909f.jpg")).ToList();

            foreach(var tag in res)
            {
                Console.WriteLine($"{tag.Name} : {tag.Description} : {tag.Value}");
            }

            Assert.True(res.Count() > 0);

            var keywords = res.SingleOrDefaultPrimaryTag("keywords");

            Assert.NotNull(keywords);
            Assert.NotNull(keywords.List);
            Assert.Equal(3, keywords.List.Count);
            Assert.Equal("Fay Canyon", keywords.List[1]);
        }


        [Fact]
        public async void GetRegionExtensionsTagWithSpaces()
        {
            var et = new ExifTool(new ExifToolOptions());

            var res = (await et.GetTagsAsync("35781602-96011d02-09ec-11e8-9335-aaa98042aa5a.jpg")).ToList();

            var region = res.SingleOrDefaultPrimaryTag("RegionAreaY");

            Assert.NotNull(region);
            Assert.NotNull(region.List);
            Assert.Equal(2, region.List.Count);
            Assert.Equal(0.4605, Convert.ToDouble(region.List[0]));
            Assert.Equal(0.4710, Convert.ToDouble(region.List[1]));
        }


        [Fact]
        public async void TestFilenameWithSpace()
        {
            var et = new ExifTool(new ExifToolOptions());
            var res = (await et.GetTagsAsync("space test.NEF")).ToList();

            Assert.True(res.Count() > 0);
        }


        [Fact]
        public async void TestExifValues()
        {
            var et = new ExifTool(new ExifToolOptions());
            var tags = (await et.GetTagsAsync("DSC_3982.NEF")).ToList();

            var bitsPerSampleTag = tags.SingleOrDefaultPrimaryTag("BitsPerSample");
            var bitsPerSample = bitsPerSampleTag?.TryGetUInt16();
            var digitalZoomRatio = tags.SingleOrDefaultPrimaryTag("DigitalZoomRatio")?.TryGetDouble();
            var expTime = tags.SingleOrDefaultPrimaryTag("ExposureTime");

            Assert.Equal((ushort?)14, bitsPerSample);
            Assert.Equal((double?)1, digitalZoomRatio);

            Assert.Equal("1/500", expTime.Value);
            Assert.Equal("0.002", expTime.NumberValue);
            Assert.Equal(.002, expTime.GetDouble());
        }


        [Fact]
        public async void TestStream()
        {
            using(var ms = new MemoryStream())
            using(var fs = new FileStream("DSC_3982.NEF", FileMode.Open))
            {
                fs.CopyTo(ms);
                ms.Seek(0, SeekOrigin.Begin);

                var et = new ExifTool(new ExifToolOptions());
                var tags = (await et.GetTagsAsync(ms)).ToList();

                var bitsPerSample = tags.SingleOrDefaultPrimaryTag("BitsPerSample")?.TryGetUInt16();
                var digitalZoomRatio = tags.SingleOrDefaultPrimaryTag("DigitalZoomRatio")?.TryGetDouble();
                var expTime = tags.SingleOrDefaultPrimaryTag("ExposureTime");

                Assert.Equal((ushort?)14, bitsPerSample);
                Assert.Equal((double?)1, digitalZoomRatio);

                Assert.Equal("1/500", expTime.Value);
                Assert.Equal("0.002", expTime.NumberValue);
                Assert.Equal(0.002, expTime.GetDouble());
            }
        }
    }
}
