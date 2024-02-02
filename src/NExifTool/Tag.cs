using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using NExifTool.Writer;

namespace NExifTool
{
    public class Tag
    {
        static readonly string[] DATE_FORMATS = new string[]
        {
            "yyyy:MM:dd HH:mm:sszzz",
            "yyyy:MM:dd HH:mm:ss"
        };

        public string Id { get; }
        public string Name { get; }
        public string Description { get; }
        public string TableName { get; }
        public string Group { get; }
        public string Value { get; }
        public string NumberValue { get; }
        public IReadOnlyList<string> List { get; }

        public bool IsInteger { get => TryGetInt64() != null; }
        public bool IsDouble { get => TryGetDouble() != null; }
        public bool IsDate { get => TryGetDateTime() != null; }
        public bool IsList { get => List != null; }

        public Tag(
            string id,
            string name,
            string description,
            string tableName,
            string group,
            string value,
            string numberValue = null,
            IEnumerable<string> list = null)
        {
            Id = id;
            Name = name;
            Description = description;
            TableName = tableName;
            Group = group;
            Value = value;
            NumberValue = numberValue;
            List = list?.ToList()?.AsReadOnly();
        }

        public Tag(string name, string value)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            if(string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameof(value));
            }

            Name = name;
            Value = value;
        }

        public Tag(string name, double value)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            Name = name;
            NumberValue = value.ToString();
        }

        public Tag(string name, IEnumerable<string> list)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(list));
            }

            Name = name;
            List = list.ToList().AsReadOnly();
        }

        public long? TryGetInt64()
        {
            if (long.TryParse(NumberValue, out var num))
            {
                return num;
            }

            if (long.TryParse(Value, out var val))
            {
                return val;
            }

            return null;
        }

        public long GetInt64()
        {
            var val = TryGetInt64();

            if(val == null)
            {
                throw new InvalidOperationException($"Value for tag with name {Name} is not an integer");
            }

            return (long)val;
        }

        public double? TryGetDouble()
        {
            if (double.TryParse(NumberValue, out var num))
            {
                return num;
            }

            if (double.TryParse(Value, out var val))
            {
                return val;
            }

            return null;
        }

        public double GetDouble()
        {
            var val = TryGetDouble();

            if(val == null)
            {
                throw new InvalidOperationException($"Value for tag with name {Name} is not a double");
            }

            return (double)val;
        }

        public DateTime? TryGetDateTime()
        {
            if (DateTime.TryParseExact(Value, DATE_FORMATS, CultureInfo.CurrentCulture, DateTimeStyles.None, out var val))
            {
                return val;
            }

            return null;
        }

        public DateTime GetDateTime()
        {
            var val = TryGetDateTime();

            if(val == null)
            {
                throw new InvalidOperationException($"Value for tag with name {Name} is not a datetime, or in an expected format");
            }

            return (DateTime)val;
        }

        public byte GetByte() => Convert.ToByte(GetInt64());
        public short GetInt16() => Convert.ToInt16(GetInt64());
        public ushort GetUInt16() => Convert.ToUInt16(GetInt64());
        public int GetInt32() => Convert.ToInt32(GetInt64());
        public uint GetUInt32() => Convert.ToUInt32(GetInt64());
        public ulong GetUInt64() => Convert.ToUInt64(GetInt64());

        public float GetSingle() => Convert.ToSingle(GetDouble());

        public byte? TryGetByte()
        {
            try
            {
                return GetByte();
            }
            catch
            {
                return null;
            }
        }

        public short? TryGetInt16()
        {
            try
            {
                return GetInt16();
            }
            catch
            {
                return null;
            }
        }

        public ushort? TryGetUInt16()
        {
            try
            {
                return GetUInt16();
            }
            catch
            {
                return null;
            }
        }

        public int? TryGetInt32()
        {
            try
            {
                return GetInt32();
            }
            catch
            {
                return null;
            }
        }

        public uint? TryGetUInt32()
        {
            try
            {
                return GetUInt32();
            }
            catch
            {
                return null;
            }
        }

        public ulong? TryGetUInt64()
        {
            try
            {
                return GetUInt64();
            }
            catch
            {
                return null;
            }
        }

        public float? TryGetSingle()
        {
            try
            {
                return GetSingle();
            }
            catch
            {
                return null;
            }
        }

        public byte[] GetBinary()
        {
            var bin = TryGetBinary();

            if(bin == null)
            {
                throw new InvalidOperationException("Could not get a binary value for this tag");
            }

            return bin;
        }

        public byte[] TryGetBinary()
        {
            if(string.IsNullOrWhiteSpace(Value))
            {
                return null;
            }

            if(!Value.StartsWith("base64:"))
            {
                return null;
            }

            try
            {
                return Convert.FromBase64String(Value.Substring("base64:".Length));
            }
            catch
            {
                return null;
            }
        }

        internal string ValueToWrite()
        {
            if(List != null)
            {
                return string.Join(Operation.ListSeparator, List);
            }

            if(NumberValue != null)
            {
                return NumberValue;
            }

            return Value;
        }
    }
}
