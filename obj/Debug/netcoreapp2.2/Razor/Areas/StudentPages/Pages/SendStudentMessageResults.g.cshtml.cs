#pragma checksum "C:\Users\randl\Documents\personal\education\SpringBoard\IT Sligo\Project\TRHDipComp_Project\TRHDipComp_Project\Areas\StudentPages\Pages\SendStudentMessageResults.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "53df3311fdec1f336843c5ea4426554f6361042f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_StudentPages_Pages_SendStudentMessageResults), @"mvc.1.0.razor-page", @"/Areas/StudentPages/Pages/SendStudentMessageResults.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Areas/StudentPages/Pages/SendStudentMessageResults.cshtml", typeof(AspNetCore.Areas_StudentPages_Pages_SendStudentMessageResults), null)]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"53df3311fdec1f336843c5ea4426554f6361042f", @"/Areas/StudentPages/Pages/SendStudentMessageResults.cshtml")]
    public class Areas_StudentPages_Pages_SendStudentMessageResults : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(144, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 5 "C:\Users\randl\Documents\personal\education\SpringBoard\IT Sligo\Project\TRHDipComp_Project\TRHDipComp_Project\Areas\StudentPages\Pages\SendStudentMessageResults.cshtml"
  
    ViewData["Title"] = "SendStudentMessageResults";

#line default
#line hidden
            BeginContext(207, 656, true);
            WriteLiteral(@"
<br />
<br />
<div class=""container"">
    <div class=""row"">
        <div class=""col-md-3""></div>
        <div class=""col-md-6"">
            <h2 class=""text-center"">Send Student Message Results</h2>
        </div>
        <div class=""col-md-3""></div>
    </div>
    <br />
</div>

<div class=""container"">
    <table class=""table table-sm table-bordered table-hover table-striped table-condensed table-functions-grad"">
        <thead>
            <tr>
                <th>Result status</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>
                    <p style=""white-space: pre-line"">");
            EndContext();
            BeginContext(864, 20, false);
#line 32 "C:\Users\randl\Documents\personal\education\SpringBoard\IT Sligo\Project\TRHDipComp_Project\TRHDipComp_Project\Areas\StudentPages\Pages\SendStudentMessageResults.cshtml"
                                                Write(Model.MessageResults);

#line default
#line hidden
            EndContext();
            BeginContext(884, 100, true);
            WriteLiteral("</p>\r\n                </td>\r\n            </tr>\r\n        </tbody>\r\n    </table>\r\n</div>\r\n\r\n<br />\r\n\r\n");
            EndContext();
            BeginContext(984, 29, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "53df3311fdec1f336843c5ea4426554f6361042f4944", async() => {
                BeginContext(1005, 4, true);
                WriteLiteral("Home");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1013, 2, true);
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TRHDipComp_Project.Areas.StudentPages.Pages.SendStudentMessageResultsModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<TRHDipComp_Project.Areas.StudentPages.Pages.SendStudentMessageResultsModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<TRHDipComp_Project.Areas.StudentPages.Pages.SendStudentMessageResultsModel>)PageContext?.ViewData;
        public TRHDipComp_Project.Areas.StudentPages.Pages.SendStudentMessageResultsModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
