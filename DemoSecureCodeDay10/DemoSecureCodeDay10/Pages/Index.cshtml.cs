using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DemoSecureCodeDay10.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            _logger.LogInformation("Someone has visited the homepage");
            try
            {
                throw new Exception("This is a test exception to demonstrate error logging.");
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Something Faild");
            }

        }
    }
}
