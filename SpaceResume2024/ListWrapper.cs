namespace SpaceResume2024;

public class ListWrapper : List<string>
{
    public ListWrapper(IEnumerable<string> collection) : base(collection)
    {
        AddRange(collection);
    }
    public ListWrapper()
    {
    }

    public ListWrapper(string values)
    {
        AddRange(values.Split('\n'));
    }
}