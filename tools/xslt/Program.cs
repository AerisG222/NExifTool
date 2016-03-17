using System;
using System.Linq;
using System.Xml.Linq;
using static System.Console;


namespace NExifTool.Tools
{
    public class Program
    {
        static string _src;
        static int _count = 1;
        
        
        public static void Main(string[] args)
        {
            _src = args[0];
            
            Generate();
        }
        
        
        public static void Generate()
		{
            WriteLine("// -------------------------------------------------------------------");
            WriteLine("// generated from: exiftool.xml");
            WriteLine($"// generated on: {DateTime.Now}");
            WriteLine("// -------------------------------------------------------------------");
            WriteLine("using System;");
            WriteLine("using System.Collections.Generic;");
            WriteLine();
            WriteLine();
            WriteLine("namespace NExifTool");
            WriteLine("{");
            WriteLine("    public class ExifToolLookup");
            WriteLine("    {");
            WriteLine("        public static readonly Dictionary<string, TagInfo> Details = new Dictionary<string, TagInfo>();");
            WriteLine();
            WriteLine();
            
            WriteMethods();
            
            WriteLine("        static ExifToolLookup()");
            WriteLine("        {");
            
            WriteInitCalls();
            
            WriteLine("        }");
            
            WriteLine();
            WriteLine();
            WriteLine("        static void AddInfo(TagInfo info)");
            WriteLine("        {");
            WriteLine("            if(!Details.ContainsKey(info.LookupKey))");
            WriteLine("            {");
            WriteLine("                Details.Add(info.LookupKey, info);");
            WriteLine("            }");
            
            /* useful for debugging the generator
            WriteLine("            else");
            WriteLine("            {");
            WriteLine("                Console.WriteLine($\"duplicated lookup entry: {info.LookupKey}\");");
            WriteLine("            }");
            */
            
            WriteLine("        }");

            WriteLine("    }");
            WriteLine("}");
            WriteLine();
		}
        
        
        static void WriteMethods()
        {
            var doc = XDocument.Load(_src);
            var tables = doc.Descendants("table");
            
            foreach(var table in tables)
            {
                WriteLine($"        static void InitTable{_count}()");
                WriteLine("        {");
                
                WriteTags(table);
                
                WriteLine("        }");
                WriteLine();
                WriteLine();
                
                _count++;
            }
        }
        
        
        static void WriteTags(XElement table)
        {
            var tableName = table.Attribute("name").Value;
            var tableG0 = table.Attribute("g0")?.Value;
            var tableG1 = table.Attribute("g1")?.Value;
            var tableG2 = table.Attribute("g2")?.Value;
            
            // for indexed items, only use the first one
            foreach(var tag in table.Descendants("tag").Where(x => x.Attribute("index") == null || string.Equals("0", x.Attribute("index").Value)))
            {
                var tagId = tag.Attribute("id").Value;
                var tagName = tag.Attribute("name").Value;
                var type = tag.Attribute("type").Value;
                var desc = tag.Descendants("desc").First(x => (string) x.Attribute("lang") == "en")?.Value;
                var g0 = table.Attribute("g0")?.Value ?? tableG0;
                var g1 = table.Attribute("g1")?.Value ?? tableG1;
                var g2 = table.Attribute("g2")?.Value ?? tableG2;
            
                WriteTag(tableName, tagId, tagName, desc, g0, g1, g2, type);
            }
        }
        
        
        static void WriteTag(string tableName, string tagId, string tagName, string desc, string g0, string g1, string g2, string type)
        {
            WriteLine($"            AddInfo(new TagInfo {{ Id = \"{tagId}\", Name = \"{tagName}\", Description = \"{desc}\", TableName = \"{tableName}\", GeneralGroup = \"{g0}\", SpecificGroup = \"{g1}\", CategoryGroup = \"{g2}\", ValueType = \"{type}\" }});");
        }
        
                
        static void WriteInitCalls()
        {
            for(int i = 1; i < _count; i++)
            {
                WriteLine($"            InitTable{i}();");
            }
        }
    }
}
