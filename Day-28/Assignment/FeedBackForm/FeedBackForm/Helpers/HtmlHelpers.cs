using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FeedBackForm.Helpers
{
    public static class HtmlHelpers
    {
        public static IHtmlContent StyledTextBox(this IHtmlHelper htmlHelper, string name, string placeholder)
        {
            var input = $"<input type='text' name='{name}' placeholder='{placeholder}' " +
                        $"class='form-control custom-input' />";
            return new HtmlString(input);
        }



    }
}
