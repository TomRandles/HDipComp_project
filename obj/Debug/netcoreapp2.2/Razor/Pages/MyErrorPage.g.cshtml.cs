#pragma checksum "C:\Users\randl\Documents\personal\education\SpringBoard\IT Sligo\Project\TRHDipComp_Project\HDipComp_project\Pages\MyErrorPage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "157062628577d845fb40fd6cef6bd08d78de8108"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(TRHDipComp_Project.Pages.Pages_MyErrorPage), @"mvc.1.0.razor-page", @"/Pages/MyErrorPage.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/MyErrorPage.cshtml", typeof(TRHDipComp_Project.Pages.Pages_MyErrorPage), @"{id?}")]
namespace TRHDipComp_Project.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#line 1 "C:\Users\randl\Documents\personal\education\SpringBoard\IT Sligo\Project\TRHDipComp_Project\HDipComp_project\Pages\_ViewImports.cshtml"
using TRHDipComp_Project;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemMetadataAttribute("RouteTemplate", "{id?}")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"157062628577d845fb40fd6cef6bd08d78de8108", @"/Pages/MyErrorPage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b6914ccbc951ca74ccdfc642779f1c5c6d7afa46", @"/Pages/_ViewImports.cshtml")]
    public class Pages_MyErrorPage : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(65, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 4 "C:\Users\randl\Documents\personal\education\SpringBoard\IT Sligo\Project\TRHDipComp_Project\HDipComp_project\Pages\MyErrorPage.cshtml"
  
    ViewData["Title"] = "Error";

#line default
#line hidden
            BeginContext(108, 275, true);
            WriteLiteral(@"

<br />
<br />
<div class=""container"">
    <div class=""row"">
        <div class=""col-md-4""></div>
        <div class=""col-md-4"">
            <h2 class=""text-center"">Error page</h2>
        </div>
        <div class=""col-md-4""></div>
    </div>
</div>
<br />

");
            EndContext();
#line 22 "C:\Users\randl\Documents\personal\education\SpringBoard\IT Sligo\Project\TRHDipComp_Project\HDipComp_project\Pages\MyErrorPage.cshtml"
  

    if (!String.IsNullOrEmpty(RouteData.Values["id"].ToString()))
    {

#line default
#line hidden
            BeginContext(463, 38, true);
            WriteLiteral("        <h4> Error message for entity ");
            EndContext();
            BeginContext(502, 22, false);
#line 26 "C:\Users\randl\Documents\personal\education\SpringBoard\IT Sligo\Project\TRHDipComp_Project\HDipComp_project\Pages\MyErrorPage.cshtml"
                                 Write(RouteData.Values["id"]);

#line default
#line hidden
            EndContext();
            BeginContext(524, 7, true);
            WriteLiteral("</h4>\r\n");
            EndContext();
#line 27 "C:\Users\randl\Documents\personal\education\SpringBoard\IT Sligo\Project\TRHDipComp_Project\HDipComp_project\Pages\MyErrorPage.cshtml"
    }
    else
    {

#line default
#line hidden
            BeginContext(555, 34, true);
            WriteLiteral("        <h4> Error message </h4>\r\n");
            EndContext();
#line 31 "C:\Users\randl\Documents\personal\education\SpringBoard\IT Sligo\Project\TRHDipComp_Project\HDipComp_project\Pages\MyErrorPage.cshtml"
    }

    if (!String.IsNullOrEmpty(@Model.ErrorMessage))
    {

#line default
#line hidden
            BeginContext(658, 12, true);
            WriteLiteral("        <h4>");
            EndContext();
            BeginContext(671, 18, false);
#line 35 "C:\Users\randl\Documents\personal\education\SpringBoard\IT Sligo\Project\TRHDipComp_Project\HDipComp_project\Pages\MyErrorPage.cshtml"
       Write(Model.ErrorMessage);

#line default
#line hidden
            EndContext();
            BeginContext(689, 8, true);
            WriteLiteral(" </h4>\r\n");
            EndContext();
#line 36 "C:\Users\randl\Documents\personal\education\SpringBoard\IT Sligo\Project\TRHDipComp_Project\HDipComp_project\Pages\MyErrorPage.cshtml"
    }
    else
    {

#line default
#line hidden
            BeginContext(721, 44, true);
            WriteLiteral("        <h4>No error message present </h4>\r\n");
            EndContext();
#line 40 "C:\Users\randl\Documents\personal\education\SpringBoard\IT Sligo\Project\TRHDipComp_Project\HDipComp_project\Pages\MyErrorPage.cshtml"
    }

#line default
#line hidden
            BeginContext(775, 12, true);
            WriteLiteral("<br />\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TRHDipComp_Project.Pages.MyErrorPageModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<TRHDipComp_Project.Pages.MyErrorPageModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<TRHDipComp_Project.Pages.MyErrorPageModel>)PageContext?.ViewData;
        public TRHDipComp_Project.Pages.MyErrorPageModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591