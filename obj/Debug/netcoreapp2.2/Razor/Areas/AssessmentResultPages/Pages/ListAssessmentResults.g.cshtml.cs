#pragma checksum "C:\Users\randl\Documents\personal\education\SpringBoard\IT Sligo\Project\TRHDipComp_Project\HDipComp_project\Areas\AssessmentResultPages\Pages\ListAssessmentResults.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e9c94de7786f8f08f9b5cce8ee3a0753de020d23"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_AssessmentResultPages_Pages_ListAssessmentResults), @"mvc.1.0.razor-page", @"/Areas/AssessmentResultPages/Pages/ListAssessmentResults.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Areas/AssessmentResultPages/Pages/ListAssessmentResults.cshtml", typeof(AspNetCore.Areas_AssessmentResultPages_Pages_ListAssessmentResults), null)]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e9c94de7786f8f08f9b5cce8ee3a0753de020d23", @"/Areas/AssessmentResultPages/Pages/ListAssessmentResults.cshtml")]
    public class Areas_AssessmentResultPages_Pages_ListAssessmentResults : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "All", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onchange", new global::Microsoft.AspNetCore.Html.HtmlString("this.form.submit();"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-page", "/ShowAssessmentResult", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "AssessmentResultPages", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(7, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(151, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 6 "C:\Users\randl\Documents\personal\education\SpringBoard\IT Sligo\Project\TRHDipComp_Project\HDipComp_project\Areas\AssessmentResultPages\Pages\ListAssessmentResults.cshtml"
  
    ViewData["Title"] = "ListAssessmentResults";

#line default
#line hidden
            BeginContext(210, 319, true);
            WriteLiteral(@"
<br />
<br />

<div class=""container"">
    <div class=""row"">
        <div class=""col-md-4""></div>
        <div class=""col-md-4"">
            <h3 class=""text-center"">List Assessment Results</h3>
        </div>
        <div class=""col-md-4""></div>
    </div>
</div>

<br />

<div class=""container"">
    ");
            EndContext();
            BeginContext(529, 461, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e9c94de7786f8f08f9b5cce8ee3a0753de020d235688", async() => {
                BeginContext(535, 104, true);
                WriteLiteral("\r\n        <label class=\"control-label\">Select Programme</label>\r\n        <div class=\"row\">\r\n            ");
                EndContext();
                BeginContext(639, 322, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e9c94de7786f8f08f9b5cce8ee3a0753de020d236182", async() => {
                    BeginContext(698, 18, true);
                    WriteLiteral("\r\n                ");
                    EndContext();
                    BeginContext(716, 41, false);
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e9c94de7786f8f08f9b5cce8ee3a0753de020d236602", async() => {
                        BeginContext(745, 3, true);
                        WriteLiteral("All");
                        EndContext();
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                    BeginWriteTagHelperAttribute();
                    __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                    __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    EndContext();
                    BeginContext(757, 2, true);
                    WriteLiteral("\r\n");
                    EndContext();
#line 31 "C:\Users\randl\Documents\personal\education\SpringBoard\IT Sligo\Project\TRHDipComp_Project\HDipComp_project\Areas\AssessmentResultPages\Pages\ListAssessmentResults.cshtml"
                 foreach (var prog in Model.ProgrammesList)
                {

#line default
#line hidden
                    BeginContext(839, 20, true);
                    WriteLiteral("                    ");
                    EndContext();
                    BeginContext(859, 60, false);
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e9c94de7786f8f08f9b5cce8ee3a0753de020d238922", async() => {
                        BeginContext(892, 18, false);
#line 33 "C:\Users\randl\Documents\personal\education\SpringBoard\IT Sligo\Project\TRHDipComp_Project\HDipComp_project\Areas\AssessmentResultPages\Pages\ListAssessmentResults.cshtml"
                                               Write(prog.ProgrammeName);

#line default
#line hidden
                        EndContext();
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                    BeginWriteTagHelperAttribute();
#line 33 "C:\Users\randl\Documents\personal\education\SpringBoard\IT Sligo\Project\TRHDipComp_Project\HDipComp_project\Areas\AssessmentResultPages\Pages\ListAssessmentResults.cshtml"
                      WriteLiteral(prog.ProgrammeID);

#line default
#line hidden
                    __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                    __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    EndContext();
                    BeginContext(919, 2, true);
                    WriteLiteral("\r\n");
                    EndContext();
#line 34 "C:\Users\randl\Documents\personal\education\SpringBoard\IT Sligo\Project\TRHDipComp_Project\HDipComp_project\Areas\AssessmentResultPages\Pages\ListAssessmentResults.cshtml"
                }

#line default
#line hidden
                    BeginContext(940, 12, true);
                    WriteLiteral("            ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
#line 29 "C:\Users\randl\Documents\personal\education\SpringBoard\IT Sligo\Project\TRHDipComp_Project\HDipComp_project\Areas\AssessmentResultPages\Pages\ListAssessmentResults.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.ProgrammeID);

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(961, 22, true);
                WriteLiteral("\r\n        </div>\r\n    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(990, 408, true);
            WriteLiteral(@"
</div>

<br />
<br />

<table class=""table table-sm table-bordered table-hover table-striped table-condensed table-functions-grad"">
    <thead>
        <tr>
            <th>Programme</th>
            <th>Module</th>
            <th>Assessment</th>
            <th>Assessment Date</th>
            <th>Student name</th>
            <th>Results</th>
        </tr>
    </thead>
    <tbody>

");
            EndContext();
#line 56 "C:\Users\randl\Documents\personal\education\SpringBoard\IT Sligo\Project\TRHDipComp_Project\HDipComp_project\Areas\AssessmentResultPages\Pages\ListAssessmentResults.cshtml"
          
            foreach (var assessResult in Model.AssessmentResultsFound)
            {
                string progName = Model.ProgrammesFound.Where(p => p.ProgrammeID == assessResult.ProgrammeID)
                                                       .Select(p => p)
                                                       .FirstOrDefault().ProgrammeName;

                string modName = Model.ModulesList.Where(m => m.ModuleID == assessResult.ModuleID)
                                                       .Select(m => m)
                                                       .FirstOrDefault().ModuleName;

                string assessmentName = Model.AssessmentsList.Where(a => a.AssessmentID == assessResult.AssessmentID)
                                                       .Select(a => a)
                                                       .FirstOrDefault().AssessmentName;

                string studentName = Model.StudentsList.Where(s => s.StudentID == assessResult.StudentID)
                                                       .Select(s => s)
                                                       .FirstOrDefault().ToString();


#line default
#line hidden
            BeginContext(2581, 46, true);
            WriteLiteral("                <tr>\r\n                    <td>");
            EndContext();
            BeginContext(2628, 8, false);
#line 76 "C:\Users\randl\Documents\personal\education\SpringBoard\IT Sligo\Project\TRHDipComp_Project\HDipComp_project\Areas\AssessmentResultPages\Pages\ListAssessmentResults.cshtml"
                   Write(progName);

#line default
#line hidden
            EndContext();
            BeginContext(2636, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(2668, 7, false);
#line 77 "C:\Users\randl\Documents\personal\education\SpringBoard\IT Sligo\Project\TRHDipComp_Project\HDipComp_project\Areas\AssessmentResultPages\Pages\ListAssessmentResults.cshtml"
                   Write(modName);

#line default
#line hidden
            EndContext();
            BeginContext(2675, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(2707, 14, false);
#line 78 "C:\Users\randl\Documents\personal\education\SpringBoard\IT Sligo\Project\TRHDipComp_Project\HDipComp_project\Areas\AssessmentResultPages\Pages\ListAssessmentResults.cshtml"
                   Write(assessmentName);

#line default
#line hidden
            EndContext();
            BeginContext(2721, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(2753, 47, false);
#line 79 "C:\Users\randl\Documents\personal\education\SpringBoard\IT Sligo\Project\TRHDipComp_Project\HDipComp_project\Areas\AssessmentResultPages\Pages\ListAssessmentResults.cshtml"
                   Write(assessResult.AssessmentDate.ToShortDateString());

#line default
#line hidden
            EndContext();
            BeginContext(2800, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(2832, 11, false);
#line 80 "C:\Users\randl\Documents\personal\education\SpringBoard\IT Sligo\Project\TRHDipComp_Project\HDipComp_project\Areas\AssessmentResultPages\Pages\ListAssessmentResults.cshtml"
                   Write(studentName);

#line default
#line hidden
            EndContext();
            BeginContext(2843, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(2874, 128, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e9c94de7786f8f08f9b5cce8ee3a0753de020d2318507", async() => {
                BeginContext(2991, 7, true);
                WriteLiteral("Results");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 81 "C:\Users\randl\Documents\personal\education\SpringBoard\IT Sligo\Project\TRHDipComp_Project\HDipComp_project\Areas\AssessmentResultPages\Pages\ListAssessmentResults.cshtml"
                                                                                               WriteLiteral(assessResult.AssessmentResultID);

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
            BeginContext(3002, 30, true);
            WriteLiteral("</td>\r\n                </tr>\r\n");
            EndContext();
#line 83 "C:\Users\randl\Documents\personal\education\SpringBoard\IT Sligo\Project\TRHDipComp_Project\HDipComp_project\Areas\AssessmentResultPages\Pages\ListAssessmentResults.cshtml"
            }
        

#line default
#line hidden
            BeginContext(3058, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TRHDipComp_Project.Areas.AssessmentResultPages.Pages.ListAssessmentResultsModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<TRHDipComp_Project.Areas.AssessmentResultPages.Pages.ListAssessmentResultsModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<TRHDipComp_Project.Areas.AssessmentResultPages.Pages.ListAssessmentResultsModel>)PageContext?.ViewData;
        public TRHDipComp_Project.Areas.AssessmentResultPages.Pages.ListAssessmentResultsModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591