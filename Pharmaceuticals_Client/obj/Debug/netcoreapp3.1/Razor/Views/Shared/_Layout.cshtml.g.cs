#pragma checksum "E:\Study\ProjectSem3\Group6_C2009G2_eProject_SemIII\XYZ Pharmaceuticals\Pharmaceuticals\Pharmaceuticals_Client\Views\Shared\_Layout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "049775c270a68976936745b7965f03a2d2cd7d8a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Layout), @"mvc.1.0.view", @"/Views/Shared/_Layout.cshtml")]
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
#line 1 "E:\Study\ProjectSem3\Group6_C2009G2_eProject_SemIII\XYZ Pharmaceuticals\Pharmaceuticals\Pharmaceuticals_Client\Views\_ViewImports.cshtml"
using Pharmaceuticals_Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Study\ProjectSem3\Group6_C2009G2_eProject_SemIII\XYZ Pharmaceuticals\Pharmaceuticals\Pharmaceuticals_Client\Views\_ViewImports.cshtml"
using Pharmaceuticals_Client.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"049775c270a68976936745b7965f03a2d2cd7d8a", @"/Views/Shared/_Layout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"80231ad20f996d7b78fcccfd16274f691110c9a9", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Shared__Layout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<!DOCTYPE HTML>\r\n<html lang=\"zxx\">\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "049775c270a68976936745b7965f03a2d2cd7d8a3516", async() => {
                WriteLiteral(@"
    <meta charset=""UTF-8"">
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"" />
    <meta http-equiv=""X-UA-Compatible"" content=""ie=edge"">
    <title>Mediscare - Medical Supplies Shop HTML5 Template | Homepage</title>
    <link rel=""icon"" href=""favicon.ico"">

    <link href=""/home/css/plugins/bootstrap.min.css"" rel=""stylesheet"">
    <link href=""/home/fonts/font-awesome.min.css"" rel=""stylesheet"">
    <link href=""/home/fonts/bs-icons/bootstrap-icons.css"" rel=""stylesheet"">
    <link href=""/home/css/plugins/slick.css"" rel=""stylesheet"">
    <link href=""/home/css/style.css"" rel=""stylesheet"">
    <link href=""/home/css/responsive.css"" rel=""stylesheet"">
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "049775c270a68976936745b7965f03a2d2cd7d8a5270", async() => {
                WriteLiteral("\r\n\r\n    <!--start header-->\r\n    ");
#nullable restore
#line 23 "E:\Study\ProjectSem3\Group6_C2009G2_eProject_SemIII\XYZ Pharmaceuticals\Pharmaceuticals\Pharmaceuticals_Client\Views\Shared\_Layout.cshtml"
Write(Html.Partial("_LayoutHeaderPartialView"));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    <!--end header-->\r\n\r\n    ");
#nullable restore
#line 26 "E:\Study\ProjectSem3\Group6_C2009G2_eProject_SemIII\XYZ Pharmaceuticals\Pharmaceuticals\Pharmaceuticals_Client\Views\Shared\_Layout.cshtml"
Write(RenderBody());

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n\r\n    <!--start footer-->\r\n    ");
#nullable restore
#line 29 "E:\Study\ProjectSem3\Group6_C2009G2_eProject_SemIII\XYZ Pharmaceuticals\Pharmaceuticals\Pharmaceuticals_Client\Views\Shared\_Layout.cshtml"
Write(Html.Partial("_LayoutFooterPartialView"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
    <!--end footer-->

    <a href=""#"" data-target=""html"" class=""back-to-top ft-sticky"">
        <i class=""fal fa-chevron-up""></i>
    </a>

    <script data-cfasync=""false"" src=""../../../cdn-cgi/scripts/5c5dd728/cloudflare-static/email-decode.min.js""></script>
    <script src=""/home/js/plugins/jquery-3.6.0.min.js""></script>
    <script src=""/home/js/plugins/bootstrap.bundle.min.js""></script>
    <script src=""/home/js/plugins/slick.min.js""></script>
    <script src=""/home/js/plugins/jquery.countdown.min.js""></script>
    <script src=""/home/js/plugins/jquery.counterup.min.js""></script>
    <script src=""/home/js/plugins/jquery.inview.min.js""></script>
    <script src=""/home/js/custom.js""></script>
    ");
#nullable restore
#line 44 "E:\Study\ProjectSem3\Group6_C2009G2_eProject_SemIII\XYZ Pharmaceuticals\Pharmaceuticals\Pharmaceuticals_Client\Views\Shared\_Layout.cshtml"
Write(RenderSection("Scripts", required: false));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n</html>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
