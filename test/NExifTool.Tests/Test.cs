using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using NExifTool;
using NExifTool.Enums;


namespace NExifTool.Tests
{
    public class Test
    {
        [Fact]
        public async void GetTagsFromImage()
        {
            var et = new ExifTool(new ExifToolOptions());
            
            var res = (await et.GetTagsAsync("DSC_3982.NEF")).ToList();
            
            foreach(var tag in res)
            {
                Console.WriteLine($"{tag.GetType()} : {tag.TagInfo.Name} : {tag.TagInfo.Description} : {tag.Value}");
                
                var tsft = tag as Tag<SubfileType>;
                
                if(tsft != null)
                {
                    var sft = tsft.TypedValue;
                    
                    Assert.True(string.Equals(sft.Description, "Full-resolution Image", StringComparison.OrdinalIgnoreCase));
                }
            }
            
            Assert.True(res.Count() > 0);
        }
        
        
        [Fact]
        public void TestEnums()
        {
            var st = SubfileType.FromKey(0);
            
            Assert.True(st == SubfileType.FullResolutionImage); 
        }
        
        
        [Fact]
        public async void TestFilenameWithSpace()
        {
            var et = new ExifTool(new ExifToolOptions());
            var res = (await et.GetTagsAsync("space test.NEF")).ToList();
            
            Assert.True(res.Count() > 0);
        }
        
        
        [Fact(Skip = "used primarily to support some dev work")]
        public void DumpDistinctTypes()
        {
            var types = ExifToolLookup.Details.Values
                .Select(x => x.ValueType)
                .Distinct()
                .ToList();
                
            foreach(var t in types)
            {
                Console.WriteLine(t);
            } 
        }
        
        
        [Fact]
        public async void TestExifValues()
        {
            var et = new ExifTool(new ExifToolOptions());
            var tags = (await et.GetTagsAsync("DSC_3982.NEF")).ToList();
            
            var bitsPerSample = GetExifData<ushort>(tags, "BitsPerSample")?.TypedValue;
            var digitalZoomRatio = GetExifData<double>(tags, "DigitalZoomRatio")?.TypedValue;
            
            Assert.True(bitsPerSample == 14, "bits per sample should be 14 for this photo");
            Assert.True(digitalZoomRatio == 1, "digital zoom ratio should be 1 for this photo");
        }
        
        
        static Tag<T> GetExifData<T>(IEnumerable<Tag> exifData, string datapoint)
        {
            var t = GetExifData(exifData, datapoint);
            
            if(t == null)
            {
                return null;
            }
            
            try
            {
                return (Tag<T>)t;
            }
            catch(Exception ex)
            {
                Console.WriteLine($"error trying to cast tag for {datapoint}.  Was expecting {typeof(T)} but got {t.GetType()} with value {t.Value}");
                
                throw ex;
            }
        }
        
        
        static Tag GetExifData(IEnumerable<Tag> exifData, string datapoint)
        {
            var tag = exifData.SingleOrDefault(x => string.Equals(x.TagInfo.Name, datapoint, StringComparison.OrdinalIgnoreCase));
            
            return tag;
        }
    }
}
