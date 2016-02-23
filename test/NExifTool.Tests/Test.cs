using System;
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
    }
}
