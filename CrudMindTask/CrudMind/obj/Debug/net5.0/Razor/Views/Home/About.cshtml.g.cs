#pragma checksum "C:\Users\Mohamed Matroud\OneDrive\Desktop\github\CRUD-BY-CORE\CrudMindTask\CrudMind\Views\Home\About.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "742d0c1c84d03841687181d62c0dd3db42dd9552"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_About), @"mvc.1.0.view", @"/Views/Home/About.cshtml")]
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
#nullable restore
#line 1 "C:\Users\Mohamed Matroud\OneDrive\Desktop\github\CRUD-BY-CORE\CrudMindTask\CrudMind\Views\_ViewImports.cshtml"
using CrudMind;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Mohamed Matroud\OneDrive\Desktop\github\CRUD-BY-CORE\CrudMindTask\CrudMind\Views\_ViewImports.cshtml"
using CrudMind.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"742d0c1c84d03841687181d62c0dd3db42dd9552", @"/Views/Home/About.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ca97a35810f7414525ccba6dd76e232958bb24ab", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_About : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<CrudMind.Models.CustomerViewModels.AdressGroup>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Mohamed Matroud\OneDrive\Desktop\github\CRUD-BY-CORE\CrudMindTask\CrudMind\Views\Home\About.cshtml"
  
    ViewData["Title"] = "Customer Body Statistics";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Customer Body Statistics</h2>\r\n\r\n<table class=\"table table-striped table-hover\">\r\n    <tr>\r\n        <th>\r\n            Birth Date\r\n\r\n        </th>\r\n        <th>\r\n            Customer\r\n        </th>\r\n    </tr>\r\n\r\n");
#nullable restore
#line 20 "C:\Users\Mohamed Matroud\OneDrive\Desktop\github\CRUD-BY-CORE\CrudMindTask\CrudMind\Views\Home\About.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 24 "C:\Users\Mohamed Matroud\OneDrive\Desktop\github\CRUD-BY-CORE\CrudMindTask\CrudMind\Views\Home\About.cshtml"
           Write(Html.DisplayFor(modelItem => item.CustomerDOB));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 27 "C:\Users\Mohamed Matroud\OneDrive\Desktop\github\CRUD-BY-CORE\CrudMindTask\CrudMind\Views\Home\About.cshtml"
           Write(item.CustomerCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 30 "C:\Users\Mohamed Matroud\OneDrive\Desktop\github\CRUD-BY-CORE\CrudMindTask\CrudMind\Views\Home\About.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<CrudMind.Models.CustomerViewModels.AdressGroup>> Html { get; private set; }
    }
}
#pragma warning restore 1591
