using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Assignment_2.Pages.Items;

public class AddModel : PageModel
{
    private readonly ItemStore _store;

    public AddModel(ItemStore store) => _store = store;

    [BindProperty]
    public string? NewItem { get; set; }

    public void OnGet() { }

    public IActionResult OnPost()
    {
        _store.Add(NewItem);
        return RedirectToPage("/Items/Index");
    }
}
