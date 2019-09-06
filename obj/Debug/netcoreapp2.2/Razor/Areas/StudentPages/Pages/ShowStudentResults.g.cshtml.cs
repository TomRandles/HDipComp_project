#pragma checksum "C:\Users\randl\Documents\personal\education\SpringBoard\IT Sligo\Project\TRHDipComp_Project\TRHDipComp_Project\Areas\StudentPages\Pages\ShowStudentResults.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4c9fd1a8baf8e442b4d6ec8d3722b4d6f8264b9e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_StudentPages_Pages_ShowStudentResults), @"mvc.1.0.razor-page", @"/Areas/StudentPages/Pages/ShowStudentResults.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Areas/StudentPages/Pages/ShowStudentResults.cshtml", typeof(AspNetCore.Areas_StudentPages_Pages_ShowStudentResults), @"{id}")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4c9fd1a8baf8e442b4d6ec8d3722b4d6f8264b9e", @"/Areas/StudentPages/Pages/ShowStudentResults.cshtml")]
    public class Areas_StudentPages_Pages_ShowStudentResults : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "C:\Users\randl\Documents\personal\education\SpringBoard\IT Sligo\Project\TRHDipComp_Project\TRHDipComp_Project\Areas\StudentPages\Pages\ShowStudentResults.cshtml"
  
    ViewData["Title"] = "ShowStudentResults";

#line default
#line hidden
            BeginContext(144, 255, true);
            WriteLiteral("\r\n<br />\r\n<br />\r\n<div class=\"container\">\r\n    <div class=\"row\">\r\n        <div class=\"col-md-4\"></div>\r\n        <div class=\"col-md-4\">\r\n            <h2 class=\"text-center\">Show Student Results</h2>\r\n            <br />\r\n            <h4 class=\"text-center\">");
            EndContext();
            BeginContext(400, 17, false);
#line 15 "C:\Users\randl\Documents\personal\education\SpringBoard\IT Sligo\Project\TRHDipComp_Project\TRHDipComp_Project\Areas\StudentPages\Pages\ShowStudentResults.cshtml"
                               Write(Model.StudentName);

#line default
#line hidden
            EndContext();
            BeginContext(417, 43, true);
            WriteLiteral("</h4>\r\n            <h4 class=\"text-center\">");
            EndContext();
            BeginContext(461, 19, false);
#line 16 "C:\Users\randl\Documents\personal\education\SpringBoard\IT Sligo\Project\TRHDipComp_Project\TRHDipComp_Project\Areas\StudentPages\Pages\ShowStudentResults.cshtml"
                               Write(Model.ProgrammeName);

#line default
#line hidden
            EndContext();
            BeginContext(480, 91, true);
            WriteLiteral("</h4>\r\n        </div>\r\n        <div class=\"col-md-4\"></div>\r\n    </div>\r\n</div>\r\n<br />\r\n\r\n");
            EndContext();
#line 23 "C:\Users\randl\Documents\personal\education\SpringBoard\IT Sligo\Project\TRHDipComp_Project\TRHDipComp_Project\Areas\StudentPages\Pages\ShowStudentResults.cshtml"
  
    if (@Model.Student.StudentImage != null)
    {
        var base64 = Convert.ToBase64String(@Model.Student.StudentImage);
        var imgSrc = String.Format("data:image/png;base64,{0}", base64);


#line default
#line hidden
            BeginContext(779, 12, true);
            WriteLiteral("        <img");
            EndContext();
            BeginWriteAttribute("src", " src=", 791, "", 803, 1);
#line 29 "C:\Users\randl\Documents\personal\education\SpringBoard\IT Sligo\Project\TRHDipComp_Project\TRHDipComp_Project\Areas\StudentPages\Pages\ShowStudentResults.cshtml"
WriteAttributeValue("", 796, imgSrc, 796, 7, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(803, 48, true);
            WriteLiteral(" style=\"max-width:200px; max-height:200px;\" />\r\n");
            EndContext();
#line 30 "C:\Users\randl\Documents\personal\education\SpringBoard\IT Sligo\Project\TRHDipComp_Project\TRHDipComp_Project\Areas\StudentPages\Pages\ShowStudentResults.cshtml"
    }

#line default
#line hidden
            BeginContext(861, 10, true);
            WriteLiteral("<br />\r\n\r\n");
            EndContext();
            BeginContext(976, 455, true);
            WriteLiteral(@"<div class=""container"">
    <table class=""table table-sm table-bordered table-hover table-striped table-condensed table-functions-grad"">
        <thead>
            <tr>
                <th>Module</th>
                <th>Assessment</th>
                <th>Assessment date</th>
                <th>Student feedback</th>
                <th>Mark</th>
                <th>Maximum mark</th>
            </tr>
        </thead>
        <tbody>

");
            EndContext();
#line 53 "C:\Users\randl\Documents\personal\education\SpringBoard\IT Sligo\Project\TRHDipComp_Project\TRHDipComp_Project\Areas\StudentPages\Pages\ShowStudentResults.cshtml"
              
                foreach (var assessmentResult in @Model.StudentAssessmentResultsList)
                {
                    // Get the module name
                    var moduleName = @Model.ModuleList.Where(s => s.ModuleID == assessmentResult.ModuleID)
                                                      .Select(s => s)
                                                      .FirstOrDefault().ModuleName;


                    // Only one assessment matches the current assessment result
                    var assessment = @Model.AssessmentsList.Where(a => a.AssessmentID == assessmentResult.AssessmentID)
                                                           .Select(m => m)
                                                           .FirstOrDefault();

                    string assessmentName = assessment.AssessmentName;

                    int totalMark = assessment.AssessmentTotalMark;

                    

#line default
#line hidden
            BeginContext(2390, 34, true);
            WriteLiteral("<tr>\r\n                        <td>");
            EndContext();
            BeginContext(2425, 10, false);
#line 72 "C:\Users\randl\Documents\personal\education\SpringBoard\IT Sligo\Project\TRHDipComp_Project\TRHDipComp_Project\Areas\StudentPages\Pages\ShowStudentResults.cshtml"
                       Write(moduleName);

#line default
#line hidden
            EndContext();
            BeginContext(2435, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(2471, 14, false);
#line 73 "C:\Users\randl\Documents\personal\education\SpringBoard\IT Sligo\Project\TRHDipComp_Project\TRHDipComp_Project\Areas\StudentPages\Pages\ShowStudentResults.cshtml"
                       Write(assessmentName);

#line default
#line hidden
            EndContext();
            BeginContext(2485, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(2521, 51, false);
#line 74 "C:\Users\randl\Documents\personal\education\SpringBoard\IT Sligo\Project\TRHDipComp_Project\TRHDipComp_Project\Areas\StudentPages\Pages\ShowStudentResults.cshtml"
                       Write(assessmentResult.AssessmentDate.ToShortDateString());

#line default
#line hidden
            EndContext();
            BeginContext(2572, 35, true);
            WriteLiteral("</td>\r\n                        <td>");
            EndContext();
            BeginContext(2608, 44, false);
#line 75 "C:\Users\randl\Documents\personal\education\SpringBoard\IT Sligo\Project\TRHDipComp_Project\TRHDipComp_Project\Areas\StudentPages\Pages\ShowStudentResults.cshtml"
                       Write(assessmentResult.AssessmentResultDescription);

#line default
#line hidden
            EndContext();
            BeginContext(2652, 50, true);
            WriteLiteral("</td>\r\n                        <td align=\"center\">");
            EndContext();
            BeginContext(2703, 37, false);
#line 76 "C:\Users\randl\Documents\personal\education\SpringBoard\IT Sligo\Project\TRHDipComp_Project\TRHDipComp_Project\Areas\StudentPages\Pages\ShowStudentResults.cshtml"
                                      Write(assessmentResult.AssessmentResultMark);

#line default
#line hidden
            EndContext();
            BeginContext(2740, 50, true);
            WriteLiteral("</td>\r\n                        <td align=\"center\">");
            EndContext();
            BeginContext(2791, 9, false);
#line 77 "C:\Users\randl\Documents\personal\education\SpringBoard\IT Sligo\Project\TRHDipComp_Project\TRHDipComp_Project\Areas\StudentPages\Pages\ShowStudentResults.cshtml"
                                      Write(totalMark);

#line default
#line hidden
            EndContext();
            BeginContext(2800, 34, true);
            WriteLiteral("</td>\r\n                    </tr>\r\n");
            EndContext();
#line 79 "C:\Users\randl\Documents\personal\education\SpringBoard\IT Sligo\Project\TRHDipComp_Project\TRHDipComp_Project\Areas\StudentPages\Pages\ShowStudentResults.cshtml"
                }
            

#line default
#line hidden
            BeginContext(2868, 48, true);
            WriteLiteral("        </tbody>\r\n    </table>\r\n</div>\r\n\r\n<br />");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TRHDipComp_Project.Areas.StudentPages.Pages.ShowStudentResultsModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<TRHDipComp_Project.Areas.StudentPages.Pages.ShowStudentResultsModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<TRHDipComp_Project.Areas.StudentPages.Pages.ShowStudentResultsModel>)PageContext?.ViewData;
        public TRHDipComp_Project.Areas.StudentPages.Pages.ShowStudentResultsModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
