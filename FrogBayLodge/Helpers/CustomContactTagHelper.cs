using Microsoft.AspNetCore.Razor.TagHelpers;
using System;

namespace FrogBayLodge.Helpers
{
    public class CustomContactTagHelper : TagHelper
    {
        //Note: Custom Tag helper will create a <a> phone tag that will allow the user to trigger a phone call 
        public string PhoneNumber { get; set; }
         public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";
            output.Attributes.SetAttribute("href", "tel: +" + PhoneNumber);
            output.Content.SetContent(PhoneNumber);
        }
    }
}
