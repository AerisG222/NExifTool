namespace NExifTool
{
    public class Tag<T>
        : Tag
    {
        public T TypedValue { get; set; }
    }
}
