using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace GoodManager.Web.TagHelpers;

[HtmlTargetElement("input",Attributes ="placeholder-for")]
[HtmlTargetElement("textarea",Attributes ="placeholder-for")]
[HtmlTargetElement("select",Attributes ="placeholder-for")]
public class PlaceholderTagHelper : TagHelper
{
    [HtmlAttributeName("placeholder-for")]
    public ModelExpression? ModelProperty { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        string placeholder = ModelProperty?.Metadata.DisplayName ?? ModelProperty?.Metadata.PropertyName ?? "";

        output.Attributes.Add("placeholder", placeholder);
    }
}