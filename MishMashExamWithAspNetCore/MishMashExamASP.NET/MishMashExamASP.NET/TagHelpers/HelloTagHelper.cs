using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using MishMashExamASP.NET.Data.Models;

namespace MishMashExamASP.NET.TagHelpers
{
    [HtmlTargetElement("h1", Attributes = "greeting-name")]
    [HtmlTargetElement("Svetli")]
    public class HelloTagHelper : TagHelper
    {
        public string GreetingName { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.SetAttribute("Name",GreetingName);
            output.Content.AppendHtml($"Hello. {this.GreetingName}");
        }
    }
}
