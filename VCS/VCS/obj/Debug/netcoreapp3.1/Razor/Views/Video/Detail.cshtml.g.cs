#pragma checksum "/Users/lin/Documents/codecamp2020/liftoff/VCS_csharp/VCS/VCS/Views/Video/Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "eb1d5cc08e5d556c41b48785234015a1c5b6ead1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Video_Detail), @"mvc.1.0.view", @"/Views/Video/Detail.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"eb1d5cc08e5d556c41b48785234015a1c5b6ead1", @"/Views/Video/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"db6ee2b7e5fe1ca004cb91a57d74db26dc5f4358", @"/Views/_ViewImports.cshtml")]
    public class Views_Video_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<VCS.Models.Video>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div>\n    <table class=\"table\">\n        <tr>\n            <th>Name</th>\n            <td>");
#nullable restore
#line 6 "/Users/lin/Documents/codecamp2020/liftoff/VCS_csharp/VCS/VCS/Views/Video/Detail.cshtml"
           Write(Model.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n        </tr>\n        <tr>\n            <th>Duration</th>\n            <td>");
#nullable restore
#line 10 "/Users/lin/Documents/codecamp2020/liftoff/VCS_csharp/VCS/VCS/Views/Video/Detail.cshtml"
           Write(Model.Duration);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n        </tr>\n        <tr>\n            <th>Size</th>\n            <td>");
#nullable restore
#line 14 "/Users/lin/Documents/codecamp2020/liftoff/VCS_csharp/VCS/VCS/Views/Video/Detail.cshtml"
           Write(Model.Size);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n        </tr>\n        <tr>\n            <th>Resolution</th>\n            <td>");
#nullable restore
#line 18 "/Users/lin/Documents/codecamp2020/liftoff/VCS_csharp/VCS/VCS/Views/Video/Detail.cshtml"
           Write(Model.Resolution);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n        </tr>\n        <tr>\n            <th>Container</th>\n            <td>");
#nullable restore
#line 22 "/Users/lin/Documents/codecamp2020/liftoff/VCS_csharp/VCS/VCS/Views/Video/Detail.cshtml"
           Write(Model.Container);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n        </tr>\n        <tr>\n            <th>Video Codec</th>\n            <td>");
#nullable restore
#line 26 "/Users/lin/Documents/codecamp2020/liftoff/VCS_csharp/VCS/VCS/Views/Video/Detail.cshtml"
           Write(Model.Video_Codec);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n        </tr>\n        <tr>\n            <th>Audio Codec</th>\n            <td>");
#nullable restore
#line 30 "/Users/lin/Documents/codecamp2020/liftoff/VCS_csharp/VCS/VCS/Views/Video/Detail.cshtml"
           Write(Model.Audio_Codec);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n        </tr>\n        <tr>\n            <th>Video Bitrate</th>\n            <td>");
#nullable restore
#line 34 "/Users/lin/Documents/codecamp2020/liftoff/VCS_csharp/VCS/VCS/Views/Video/Detail.cshtml"
           Write(Model.Video_bitrate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n        </tr>\n    </table>\n</div>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<VCS.Models.Video> Html { get; private set; }
    }
}
#pragma warning restore 1591
