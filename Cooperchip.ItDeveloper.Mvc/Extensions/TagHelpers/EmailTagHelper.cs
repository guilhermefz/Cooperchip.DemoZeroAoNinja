using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Cooperchip.ItDeveloper.Mvc.Extensions.TagHelpers
{
    public class EmailTagHelper : TagHelper
    {
        public string Dominio { get; set; } = "gmail.com";
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            var prefixo = await output.GetChildContentAsync();
            var meuemail = prefixo.GetContent() + "@" + Dominio;
            output.Attributes.SetAttribute("href", "mailto:" + meuemail);
            output.Content.SetContent(meuemail);
        }
    }
}
