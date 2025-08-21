using Microsoft.AspNetCore.Razor.TagHelpers;
namespace FeedBackForm.TagHelpers
{
    [HtmlTargetElement("star-rating")]
    public class StarRatingTagHelper: TagHelper
    {
        public int value { get; set; }
        public int max { get; set; } = 5;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            string starsHtml = "";


            for (int i = 1; i <= max; i++)
            {
                if (i <= value)
                    starsHtml += $"<span style='color: gold; font-size:20px;'>&#9733;</span>"; // Filled star
                else
                    starsHtml += $"<span style='color: gray; font-size:20px;'>&#9734;</span>"; // Empty star
            }

            output.Content.SetHtmlContent(starsHtml);
        }
        

    }
}
