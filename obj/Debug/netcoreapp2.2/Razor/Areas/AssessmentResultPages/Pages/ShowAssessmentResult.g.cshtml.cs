#pragma checksum "C:\Users\randl\Documents\personal\education\SpringBoard\IT Sligo\Project\TRHDipComp_Project\HDipComp_project\Areas\AssessmentResultPages\Pages\ShowAssessmentResult.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "96d50fd531794597b319ac3323866d7cacfe5e7f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_AssessmentResultPages_Pages_ShowAssessmentResult), @"mvc.1.0.razor-page", @"/Areas/AssessmentResultPages/Pages/ShowAssessmentResult.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Areas/AssessmentResultPages/Pages/ShowAssessmentResult.cshtml", typeof(AspNetCore.Areas_AssessmentResultPages_Pages_ShowAssessmentResult), @"{id}")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemMetadataAttribute("RouteTemplate", "{id}")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"96d50fd531794597b319ac3323866d7cacfe5e7f", @"/Areas/AssessmentResultPages/Pages/ShowAssessmentResult.cshtml")]
    public class Areas_AssessmentResultPages_Pages_ShowAssessmentResult : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/UpdateAssessmentResult", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "AssessmentResultPages", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/DeleteAssessmentResult", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(155, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 5 "C:\Users\randl\Documents\personal\education\SpringBoard\IT Sligo\Project\TRHDipComp_Project\HDipComp_project\Areas\AssessmentResultPages\Pages\ShowAssessmentResult.cshtml"
  
    ViewData["Title"] = "Show Assessment Result";

#line default
#line hidden
            BeginContext(215, 909, true);
            WriteLiteral(@"
<br />
<br />
<div class=""container"">
    <div class=""row"">
        <div class=""col-md-4""></div>
        <div class=""col-md-4"">
            <h2 class=""text-center"">Show Assessment Result</h2>
        </div>
        <div class=""col-md-4""></div>
    </div>
    <br />
</div>

<div class=""container"">
    <h3>Assessment Result Details</h3>
    <table class=""table table-sm table-bordered table-hover table-striped table-condensed table-functions-grad"">
        <thead>
            <tr>
                <th>Student</th>
                <th>Programme</th>
                <th>Module</th>
                <th>Assessment</th>
                <th>Assessment date</th>
                <th>Feedback</th>
                <th>Mark</th>
                <th>Edit</th>
                <th>Delete</th>
            </tr>
        </thead>
        <tbody>

            <tr>
                <td>");
            EndContext();
            BeginContext(1125, 17, false);
#line 41 "C:\Users\randl\Documents\personal\education\SpringBoard\IT Sligo\Project\TRHDipComp_Project\HDipComp_project\Areas\AssessmentResultPages\Pages\ShowAssessmentResult.cshtml"
               Write(Model.StudentName);

#line default
#line hidden
            EndContext();
            BeginContext(1142, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(1170, 19, false);
#line 42 "C:\Users\randl\Documents\personal\education\SpringBoard\IT Sligo\Project\TRHDipComp_Project\HDipComp_project\Areas\AssessmentResultPages\Pages\ShowAssessmentResult.cshtml"
               Write(Model.ProgrammeName);

#line default
#line hidden
            EndContext();
            BeginContext(1189, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(1217, 16, false);
#line 43 "C:\Users\randl\Documents\personal\education\SpringBoard\IT Sligo\Project\TRHDipComp_Project\HDipComp_project\Areas\AssessmentResultPages\Pages\ShowAssessmentResult.cshtml"
               Write(Model.ModuleName);

#line default
#line hidden
            EndContext();
            BeginContext(1233, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(1261, 20, false);
#line 44 "C:\Users\randl\Documents\personal\education\SpringBoard\IT Sligo\Project\TRHDipComp_Project\HDipComp_project\Areas\AssessmentResultPages\Pages\ShowAssessmentResult.cshtml"
               Write(Model.AssessmentName);

#line default
#line hidden
            EndContext();
            BeginContext(1281, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(1309, 57, false);
#line 45 "C:\Users\randl\Documents\personal\education\SpringBoard\IT Sligo\Project\TRHDipComp_Project\HDipComp_project\Areas\AssessmentResultPages\Pages\ShowAssessmentResult.cshtml"
               Write(Model.AssessmentResult.AssessmentDate.ToShortDateString());

#line default
#line hidden
            EndContext();
            BeginContext(1366, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(1394, 50, false);
#line 46 "C:\Users\randl\Documents\personal\education\SpringBoard\IT Sligo\Project\TRHDipComp_Project\HDipComp_project\Areas\AssessmentResultPages\Pages\ShowAssessmentResult.cshtml"
               Write(Model.AssessmentResult.AssessmentResultDescription);

#line default
#line hidden
            EndContext();
            BeginContext(1444, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(1472, 43, false);
#line 47 "C:\Users\randl\Documents\personal\education\SpringBoard\IT Sligo\Project\TRHDipComp_Project\HDipComp_project\Areas\AssessmentResultPages\Pages\ShowAssessmentResult.cshtml"
               Write(Model.AssessmentResult.AssessmentResultMark);

#line default
#line hidden
            EndContext();
            BeginContext(1515, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(1542, 154, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "96d50fd531794597b319ac3323866d7cacfe5e7f8705", async() => {
                BeginContext(1671, 21, true);
                WriteLiteral("Edit AssessmentResult");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 48 "C:\Users\randl\Documents\personal\education\SpringBoard\IT Sligo\Project\TRHDipComp_Project\HDipComp_project\Areas\AssessmentResultPages\Pages\ShowAssessmentResult.cshtml"
                                                                                             WriteLiteral(Model.AssessmentResult.AssessmentResultID);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1696, 27, true);
            WriteLiteral("</td>\r\n                <td>");
            EndContext();
            BeginContext(1723, 156, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "96d50fd531794597b319ac3323866d7cacfe5e7f11453", async() => {
                BeginContext(1852, 23, true);
                WriteLiteral("Delete AssessmentResult");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 49 "C:\Users\randl\Documents\personal\education\SpringBoard\IT Sligo\Project\TRHDipComp_Project\HDipComp_project\Areas\AssessmentResultPages\Pages\ShowAssessmentResult.cshtml"
                                                                                             WriteLiteral(Model.AssessmentResult.AssessmentResultID);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1879, 66, true);
            WriteLiteral("</td>\r\n            </tr>\r\n        </tbody>\r\n    </table>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TRHDipComp_Project.Areas.AssessmentResultPages.Pages.ShowAssessmentResultModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<TRHDipComp_Project.Areas.AssessmentResultPages.Pages.ShowAssessmentResultModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<TRHDipComp_Project.Areas.AssessmentResultPages.Pages.ShowAssessmentResultModel>)PageContext?.ViewData;
        public TRHDipComp_Project.Areas.AssessmentResultPages.Pages.ShowAssessmentResultModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591