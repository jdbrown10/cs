#pragma checksum "/Users/joshuabrown/Desktop/Josh/Coding/Coding Dojo/dojo_assignments/c_sharp/ORMs/CRUDelicious/Views/Home/ShowDish.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8939698b542271f80cb01dfa99c6bf5fd4e5b245"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ShowDish), @"mvc.1.0.view", @"/Views/Home/ShowDish.cshtml")]
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
#line 1 "/Users/joshuabrown/Desktop/Josh/Coding/Coding Dojo/dojo_assignments/c_sharp/ORMs/CRUDelicious/Views/_ViewImports.cshtml"
using CRUDelicious;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/joshuabrown/Desktop/Josh/Coding/Coding Dojo/dojo_assignments/c_sharp/ORMs/CRUDelicious/Views/_ViewImports.cshtml"
using CRUDelicious.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8939698b542271f80cb01dfa99c6bf5fd4e5b245", @"/Views/Home/ShowDish.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"815eae4269ab1eac71e8261ccfa9294c33285639", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_ShowDish : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Dish>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
            WriteLiteral("\n<div class=\"text-center container\">\n    <h1>");
#nullable restore
#line 5 "/Users/joshuabrown/Desktop/Josh/Coding/Coding Dojo/dojo_assignments/c_sharp/ORMs/CRUDelicious/Views/Home/ShowDish.cshtml"
   Write(ViewBag.Dish.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\n    <hr>\n        <div>\n            <p>");
#nullable restore
#line 8 "/Users/joshuabrown/Desktop/Josh/Coding/Coding Dojo/dojo_assignments/c_sharp/ORMs/CRUDelicious/Views/Home/ShowDish.cshtml"
          Write(ViewBag.Dish.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n            <p>Tastiness: ");
#nullable restore
#line 9 "/Users/joshuabrown/Desktop/Josh/Coding/Coding Dojo/dojo_assignments/c_sharp/ORMs/CRUDelicious/Views/Home/ShowDish.cshtml"
                     Write(ViewBag.Dish.Tastiness);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n            <p>Calories: ");
#nullable restore
#line 10 "/Users/joshuabrown/Desktop/Josh/Coding/Coding Dojo/dojo_assignments/c_sharp/ORMs/CRUDelicious/Views/Home/ShowDish.cshtml"
                    Write(ViewBag.Dish.Calories);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n        </div>\n\n        <div class=\"d-flex justify-content-around\">\n            <a");
            BeginWriteAttribute("href", " href=\"", 338, "\"", 373, 2);
            WriteAttributeValue("", 345, "/update/", 345, 8, true);
#nullable restore
#line 14 "/Users/joshuabrown/Desktop/Josh/Coding/Coding Dojo/dojo_assignments/c_sharp/ORMs/CRUDelicious/Views/Home/ShowDish.cshtml"
WriteAttributeValue("", 353, ViewBag.Dish.DishId, 353, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary\">Edit Dish</a>\n            <a");
            BeginWriteAttribute("href", " href=\"", 427, "\"", 462, 2);
            WriteAttributeValue("", 434, "/delete/", 434, 8, true);
#nullable restore
#line 15 "/Users/joshuabrown/Desktop/Josh/Coding/Coding Dojo/dojo_assignments/c_sharp/ORMs/CRUDelicious/Views/Home/ShowDish.cshtml"
WriteAttributeValue("", 442, ViewBag.Dish.DishId, 442, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-danger\">Delete Dish</a>\n        </div>\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Dish> Html { get; private set; }
    }
}
#pragma warning restore 1591
