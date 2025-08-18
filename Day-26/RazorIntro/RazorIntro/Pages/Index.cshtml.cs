using Microsoft.AspNetCore.Mvc.RazorPages;

public class IndexModel : PageModel
{
    public string Message { get; set; } = "";

    public void OnGet()
    {
        Message = "Hello from backend C# code!";
    }
}
