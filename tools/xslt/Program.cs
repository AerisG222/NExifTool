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
            WriteLine("        static void AddInfo(string name, string description, string type)");
            WriteLine("        {");
            WriteLine("            if(!Details.ContainsKey(name))");
            WriteLine("            {");
            WriteLine("                Details.Add(name, new TagInfo { Name = name, Description = description, ValueType = type });");
            WriteLine("            }");
            WriteLine("            //else");
            WriteLine("            //{");
            WriteLine("                //Console.WriteLine($\"duplicate: {name}\");");
            WriteLine("            //}");
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
            var g0 = table.Attribute("g0")?.Value.ToLower();
            var g1 = table.Attribute("g1")?.Value.ToLower();
            var g2 = table.Attribute("g2")?.Value.ToLower();
            
            foreach(var tag in table.Descendants("tag"))
            {
                var name = tag.Attribute("name").Value.ToLower();
                var type = tag.Attribute("type").Value.ToLower();
                var desc = tag.Descendants("desc").First(x => (string) x.Attribute("lang") == "en")?.Value;
                
                WriteTag(g0, g1, g2, name, desc, type);
                
                if(string.Equals(g0, "exif", StringComparison.Ordinal) && string.Equals(g1, "ifd0", StringComparison.Ordinal))
                {
                    WriteTag(g0, "subifd1", g2, name, desc, type);
                    WriteTag(g0, "exififd", g2, name, desc, type);
                }
            }
        }
        
        
        static void WriteTag(string g0, string g1, string g2, string name, string desc, string type)
        {
            WriteLine($"            AddInfo(\"{g0}:{g1}:{g2}::name\", \"{desc}\", \"{type}\");");
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
