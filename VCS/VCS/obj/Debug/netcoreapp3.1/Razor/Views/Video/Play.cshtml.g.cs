#pragma checksum "/Users/lin/Documents/codecamp2020/liftoff/VCS_csharp/VCS/VCS/Views/Video/Play.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e3361632b449f2c4c86a8f4d23fe9199e44c29b8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Video_Play), @"mvc.1.0.view", @"/Views/Video/Play.cshtml")]
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
#line 1 "/Users/lin/Documents/codecamp2020/liftoff/VCS_csharp/VCS/VCS/Views/_ViewImports.cshtml"
using VCS;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/lin/Documents/codecamp2020/liftoff/VCS_csharp/VCS/VCS/Views/_ViewImports.cshtml"
using VCS.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e3361632b449f2c4c86a8f4d23fe9199e44c29b8", @"/Views/Video/Play.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"db6ee2b7e5fe1ca004cb91a57d74db26dc5f4358", @"/Views/_ViewImports.cshtml")]
    public class Views_Video_Play : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
            WriteLiteral("\n<video id=\"videoplayer\"");
            BeginWriteAttribute("src", " src=\"", 30, "\"", 49, 1);
#nullable restore
#line 5 "/Users/lin/Documents/codecamp2020/liftoff/VCS_csharp/VCS/VCS/Views/Video/Play.cshtml"
WriteAttributeValue("", 36, ViewBag.path, 36, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" controls width=\"450\" height=\"450\" loop></video>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591