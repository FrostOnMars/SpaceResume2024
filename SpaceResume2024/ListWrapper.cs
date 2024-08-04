namespace SpaceResume2024;

public class ListWrapper : List<string>
{
    #region Public Constructors

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

    #endregion Public Constructors
}