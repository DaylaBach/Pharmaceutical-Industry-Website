#pragma checksum "E:\Study\ProjectSem3\Group6_C2009G2_eProject_SemIII\XYZ Pharmaceuticals\Pharmaceuticals\Pharmaceuticals_Client\Areas\Admin\Views\Attributes\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "bff5f2cb01abcd4b16e3a2ac9da409ea418b623b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Attributes_Detail), @"mvc.1.0.view", @"/Areas/Admin/Views/Attributes/Detail.cshtml")]
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
#line 1 "E:\Study\ProjectSem3\Group6_C2009G2_eProject_SemIII\XYZ Pharmaceuticals\Pharmaceuticals\Pharmaceuticals_Client\Areas\Admin\_ViewImports.cshtml"
using Pharmaceuticals_Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Study\ProjectSem3\Group6_C2009G2_eProject_SemIII\XYZ Pharmaceuticals\Pharmaceuticals\Pharmaceuticals_Client\Areas\Admin\_ViewImports.cshtml"
using Pharmaceuticals_Client.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bff5f2cb01abcd4b16e3a2ac9da409ea418b623b", @"/Areas/Admin/Views/Attributes/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"80231ad20f996d7b78fcccfd16274f691110c9a9", @"/Areas/Admin/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_Attributes_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Pharmaceuticals_Client.Areas.Admin.Models.AdminViewModel>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\Study\ProjectSem3\Group6_C2009G2_eProject_SemIII\XYZ Pharmaceuticals\Pharmaceuticals\Pharmaceuticals_Client\Areas\Admin\Views\Attributes\Detail.cshtml"
  
    ViewData["Title"] = "Detail";
    Layout = "~/Areas/Admin/Views/Shared/_LayoutAdmin.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div>\r\n    <h4>Attribute</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 13 "E:\Study\ProjectSem3\Group6_C2009G2_eProject_SemIII\XYZ Pharmaceuticals\Pharmaceuticals\Pharmaceuticals_Client\Areas\Admin\Views\Attributes\Detail.cshtml"
       Write(Html.DisplayNameFor(model => model.attribute.AttributeId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 16 "E:\Study\ProjectSem3\Group6_C2009G2_eProject_SemIII\XYZ Pharmaceuticals\Pharmaceuticals\Pharmaceuticals_Client\Areas\Admin\Views\Attributes\Detail.cshtml"
       Write(Html.DisplayFor(model => model.attribute.AttributeId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 19 "E:\Study\ProjectSem3\Group6_C2009G2_eProject_SemIII\XYZ Pharmaceuticals\Pharmaceuticals\Pharmaceuticals_Client\Areas\Admin\Views\Attributes\Detail.cshtml"
       Write(Html.DisplayNameFor(model => model.attribute.AttributeName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 22 "E:\Study\ProjectSem3\Group6_C2009G2_eProject_SemIII\XYZ Pharmaceuticals\Pharmaceuticals\Pharmaceuticals_Client\Areas\Admin\Views\Attributes\Detail.cshtml"
       Write(Html.DisplayFor(model => model.attribute.AttributeName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 25 "E:\Study\ProjectSem3\Group6_C2009G2_eProject_SemIII\XYZ Pharmaceuticals\Pharmaceuticals\Pharmaceuticals_Client\Areas\Admin\Views\Attributes\Detail.cshtml"
       Write(Html.DisplayNameFor(model => model.attribute.Value));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 28 "E:\Study\ProjectSem3\Group6_C2009G2_eProject_SemIII\XYZ Pharmaceuticals\Pharmaceuticals\Pharmaceuticals_Client\Areas\Admin\Views\Attributes\Detail.cshtml"
       Write(Html.DisplayFor(model => model.attribute.Value));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 31 "E:\Study\ProjectSem3\Group6_C2009G2_eProject_SemIII\XYZ Pharmaceuticals\Pharmaceuticals\Pharmaceuticals_Client\Areas\Admin\Views\Attributes\Detail.cshtml"
       Write(Html.DisplayNameFor(model => model.attribute.Unit));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 34 "E:\Study\ProjectSem3\Group6_C2009G2_eProject_SemIII\XYZ Pharmaceuticals\Pharmaceuticals\Pharmaceuticals_Client\Areas\Admin\Views\Attributes\Detail.cshtml"
       Write(Html.DisplayFor(model => model.attribute.Unit));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 37 "E:\Study\ProjectSem3\Group6_C2009G2_eProject_SemIII\XYZ Pharmaceuticals\Pharmaceuticals\Pharmaceuticals_Client\Areas\Admin\Views\Attributes\Detail.cshtml"
       Write(Html.DisplayNameFor(model => model.attribute.ProductId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 40 "E:\Study\ProjectSem3\Group6_C2009G2_eProject_SemIII\XYZ Pharmaceuticals\Pharmaceuticals\Pharmaceuticals_Client\Areas\Admin\Views\Attributes\Detail.cshtml"
       Write(Html.DisplayFor(model => model.attribute.Product.ProductName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
#nullable restore
#line 45 "E:\Study\ProjectSem3\Group6_C2009G2_eProject_SemIII\XYZ Pharmaceuticals\Pharmaceuticals\Pharmaceuticals_Client\Areas\Admin\Views\Attributes\Detail.cshtml"
Write(Html.ActionLink("Edit", "Edit", new { id = Model.attribute.AttributeId }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bff5f2cb01abcd4b16e3a2ac9da409ea418b623b8655", async() => {
                WriteLiteral("Back to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Pharmaceuticals_Client.Areas.Admin.Models.AdminViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
