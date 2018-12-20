using System;
using System.Collections.Generic;
using System.Linq;


namespace NExifTool
{
    public static class ListTagExtensions
    {
        public static IEnumerable<Tag> Tags(this IEnumerable<Tag> tags, string name)
        {
            return tags.Where(tag => string.Equals(tag.Name, name, StringComparison.OrdinalIgnoreCase));
        }


        public static IEnumerable<Tag> PrimaryTags(this IEnumerable<Tag> tags, string name)
        {
            return tags.Tags(name).Where(tag => tag.Group.IndexOf("copy", StringComparison.OrdinalIgnoreCase) < 0);
        }


        public static Tag SingleTag(this IEnumerable<Tag> tags, string name)
        {
            return tags.Tags(name).Single();
        }


        public static Tag SinglePrimaryTag(this IEnumerable<Tag> tags, string name)
        {
            return tags.PrimaryTags(name).Single();
        }


        public static Tag SingleOrDefaultTag(this IEnumerable<Tag> tags, string name)
        {
            return tags.Tags(name).SingleOrDefault();
        }


        public static Tag SingleOrDefaultPrimaryTag(this IEnumerable<Tag> tags, string name)
        {
            return tags.PrimaryTags(name).SingleOrDefault();
        }


        public static int TagCount(this IEnumerable<Tag> tags, string name)
        {
            return tags.Tags(name).Count();
        }


        public static int PrimaryTagCount(this IEnumerable<Tag> tags, string name)
        {
            return tags.PrimaryTags(name).Count();
        }
    }
}
