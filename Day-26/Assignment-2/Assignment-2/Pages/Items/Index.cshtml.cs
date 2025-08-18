using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Assignment_2.Pages.Items;

public class IndexModel : PageModel
{
    private readonly ItemStore _store;
    public IReadOnlyList<string> Items { get; private set; } = Array.Empty<string>();

    public IndexModel(ItemStore store) => _store = store;

    public void OnGet()
    {
        Items = _store.Items;
    }
}
