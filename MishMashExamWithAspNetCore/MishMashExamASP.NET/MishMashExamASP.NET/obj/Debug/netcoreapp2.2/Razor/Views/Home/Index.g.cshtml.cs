#pragma checksum "D:\SoftUni\ASP.NET-Core-Mini-Projects\MishMashExamWithAspNetCore\MishMashExamASP.NET\MishMashExamASP.NET\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e644459746c7f43e7f420d85be9b30a0f47b97dc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Index.cshtml", typeof(AspNetCore.Views_Home_Index))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "D:\SoftUni\ASP.NET-Core-Mini-Projects\MishMashExamWithAspNetCore\MishMashExamASP.NET\MishMashExamASP.NET\Views\_ViewImports.cshtml"
using MishMashExamASP.NET;

#line default
#line hidden
#line 2 "D:\SoftUni\ASP.NET-Core-Mini-Projects\MishMashExamWithAspNetCore\MishMashExamASP.NET\MishMashExamASP.NET\Views\_ViewImports.cshtml"
using MishMashExamASP.NET.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e644459746c7f43e7f420d85be9b30a0f47b97dc", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ca6dcfc8a5d2e6aaf53fd5d29e77bcec04cda1d9", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ChannelsCollectionViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "_ChannelsListPartial", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "D:\SoftUni\ASP.NET-Core-Mini-Projects\MishMashExamWithAspNetCore\MishMashExamASP.NET\MishMashExamASP.NET\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
            BeginContext(81, 134, true);
            WriteLiteral("\r\n<main class=\"mt-3 mb-5 container\">\r\n    <h3>Your channels</h3>\r\n    <hr />\r\n    <div class=\"channel-group\" id=\"followed-channels\">\r\n");
            EndContext();
#line 10 "D:\SoftUni\ASP.NET-Core-Mini-Projects\MishMashExamWithAspNetCore\MishMashExamASP.NET\MishMashExamASP.NET\Views\Home\Index.cshtml"
         foreach (var channel in Model.FollowedChannels)
        {

#line default
#line hidden
            BeginContext(284, 59, true);
            WriteLiteral("            <div class=\"channel-box\">\r\n                <h5>");
            EndContext();
            BeginContext(344, 12, false);
#line 13 "D:\SoftUni\ASP.NET-Core-Mini-Projects\MishMashExamWithAspNetCore\MishMashExamASP.NET\MishMashExamASP.NET\Views\Home\Index.cshtml"
               Write(channel.Name);

#line default
#line hidden
            EndContext();
            BeginContext(356, 51, true);
            WriteLiteral("</h5>\r\n                <hr />\r\n                <h5>");
            EndContext();
            BeginContext(408, 12, false);
#line 15 "D:\SoftUni\ASP.NET-Core-Mini-Projects\MishMashExamWithAspNetCore\MishMashExamASP.NET\MishMashExamASP.NET\Views\Home\Index.cshtml"
               Write(channel.Type);

#line default
#line hidden
            EndContext();
            BeginContext(420, 69, true);
            WriteLiteral(" Channel</h5>\r\n                <hr />\r\n                <h5>Followers ");
            EndContext();
            BeginContext(490, 17, false);
#line 17 "D:\SoftUni\ASP.NET-Core-Mini-Projects\MishMashExamWithAspNetCore\MishMashExamASP.NET\MishMashExamASP.NET\Views\Home\Index.cshtml"
                         Write(channel.Followers);

#line default
#line hidden
            EndContext();
            BeginContext(507, 87, true);
            WriteLiteral("</h5>\r\n                <hr />\r\n                <h5>Following</h5>\r\n            </div>\r\n");
            EndContext();
#line 21 "D:\SoftUni\ASP.NET-Core-Mini-Projects\MishMashExamWithAspNetCore\MishMashExamASP.NET\MishMashExamASP.NET\Views\Home\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(605, 89, true);
            WriteLiteral("    </div>\r\n    <h3>Suggested</h3>\r\n    <hr />\r\n    <div class=\"channel-group\">\r\n        ");
            EndContext();
            BeginContext(694, 71, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "e644459746c7f43e7f420d85be9b30a0f47b97dc6191", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#line 26 "D:\SoftUni\ASP.NET-Core-Mini-Projects\MishMashExamWithAspNetCore\MishMashExamASP.NET\MishMashExamASP.NET\Views\Home\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = Model.SuggestedChannels;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(765, 107, true);
            WriteLiteral("\r\n    </div>\r\n    <h3>Other</h3>\r\n    <hr />\r\n    <div class=\"channel-group\" id=\"other-channels\">\r\n        ");
            EndContext();
            BeginContext(872, 68, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "e644459746c7f43e7f420d85be9b30a0f47b97dc8044", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#line 31 "D:\SoftUni\ASP.NET-Core-Mini-Projects\MishMashExamWithAspNetCore\MishMashExamASP.NET\MishMashExamASP.NET\Views\Home\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = Model.OtherChannels;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(940, 25, true);
            WriteLiteral("\r\n    </div>\r\n</main>\r\n\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ChannelsCollectionViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
