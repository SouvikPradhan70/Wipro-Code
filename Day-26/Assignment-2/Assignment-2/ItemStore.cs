public class ItemStore
{
    private readonly List<string> _items = new();
    public IReadOnlyList<string> Items => _items;

    public void Add(string? item)
    {
        if (!string.IsNullOrWhiteSpace(item))
            _items.Add(item.Trim());
    }
}
