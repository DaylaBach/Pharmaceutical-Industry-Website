#pragma checksum "E:\Study\ProjectSem3\Group6_C2009G2_eProject_SemIII\XYZ Pharmaceuticals\Pharmaceuticals\Pharmaceuticals_Client\Areas\Admin\Views\Managers\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ab2290f1fca6a4ed16b45dd67cbd492adce60c44"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Managers_Detail), @"mvc.1.0.view", @"/Areas/Admin/Views/Managers/Detail.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ab2290f1fca6a4ed16b45dd67cbd492adce60c44", @"/Areas/Admin/Views/Managers/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"80231ad20f996d7b78fcccfd16274f691110c9a9", @"/Areas/Admin/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Admin_Views_Managers_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Pharmaceuticals_Client.Areas.Admin.Models.AdminViewModel>
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
#line 3 "E:\Study\ProjectSem3\Group6_C2009G2_eProject_SemIII\XYZ Pharmaceuticals\Pharmaceuticals\Pharmaceuticals_Client\Areas\Admin\Views\Managers\Detail.cshtml"
  
    ViewData["Title"] = "Detail";
    Layout = "~/Areas/Admin/Views/Shared/_LayoutAdmin.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div>\r\n    <h4>Manager</h4>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 13 "E:\Study\ProjectSem3\Group6_C2009G2_eProject_SemIII\XYZ Pharmaceuticals\Pharmaceuticals\Pharmaceuticals_Client\Areas\Admin\Views\Managers\Detail.cshtml"
       Write(Html.DisplayNameFor(model => model.managerInfo.AdminId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 16 "E:\Study\ProjectSem3\Group6_C2009G2_eProject_SemIII\XYZ Pharmaceuticals\Pharmaceuticals\Pharmaceuticals_Client\Areas\Admin\Views\Managers\Detail.cshtml"
       Write(Html.DisplayFor(model => model.managerInfo.AdminId));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 19 "E:\Study\ProjectSem3\Group6_C2009G2_eProject_SemIII\XYZ Pharmaceuticals\Pharmaceuticals\Pharmaceuticals_Client\Areas\Admin\Views\Managers\Detail.cshtml"
       Write(Html.DisplayNameFor(model => model.managerInfo.FullName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 22 "E:\Study\ProjectSem3\Group6_C2009G2_eProject_SemIII\XYZ Pharmaceuticals\Pharmaceuticals\Pharmaceuticals_Client\Areas\Admin\Views\Managers\Detail.cshtml"
       Write(Html.DisplayFor(model => model.managerInfo.FullName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 25 "E:\Study\ProjectSem3\Group6_C2009G2_eProject_SemIII\XYZ Pharmaceuticals\Pharmaceuticals\Pharmaceuticals_Client\Areas\Admin\Views\Managers\Detail.cshtml"
       Write(Html.DisplayNameFor(model => model.managerInfo.Address));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 28 "E:\Study\ProjectSem3\Group6_C2009G2_eProject_SemIII\XYZ Pharmaceuticals\Pharmaceuticals\Pharmaceuticals_Client\Areas\Admin\Views\Managers\Detail.cshtml"
       Write(Html.DisplayFor(model => model.managerInfo.Address));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 31 "E:\Study\ProjectSem3\Group6_C2009G2_eProject_SemIII\XYZ Pharmaceuticals\Pharmaceuticals\Pharmaceuticals_Client\Areas\Admin\Views\Managers\Detail.cshtml"
       Write(Html.DisplayNameFor(model => model.managerInfo.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 34 "E:\Study\ProjectSem3\Group6_C2009G2_eProject_SemIII\XYZ Pharmaceuticals\Pharmaceuticals\Pharmaceuticals_Client\Areas\Admin\Views\Managers\Detail.cshtml"
       Write(Html.DisplayFor(model => model.managerInfo.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 37 "E:\Study\ProjectSem3\Group6_C2009G2_eProject_SemIII\XYZ Pharmaceuticals\Pharmaceuticals\Pharmaceuticals_Client\Areas\Admin\Views\Managers\Detail.cshtml"
       Write(Html.DisplayNameFor(model => model.managerInfo.Phone));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 40 "E:\Study\ProjectSem3\Group6_C2009G2_eProject_SemIII\XYZ Pharmaceuticals\Pharmaceuticals\Pharmaceuticals_Client\Areas\Admin\Views\Managers\Detail.cshtml"
       Write(Html.DisplayFor(model => model.managerInfo.Phone));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 43 "E:\Study\ProjectSem3\Group6_C2009G2_eProject_SemIII\XYZ Pharmaceuticals\Pharmaceuticals\Pharmaceuticals_Client\Areas\Admin\Views\Managers\Detail.cshtml"
       Write(Html.DisplayNameFor(model => model.managerInfo.Username));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 46 "E:\Study\ProjectSem3\Group6_C2009G2_eProject_SemIII\XYZ Pharmaceuticals\Pharmaceuticals\Pharmaceuticals_Client\Areas\Admin\Views\Managers\Detail.cshtml"
       Write(Html.DisplayFor(model => model.managerInfo.Username));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 49 "E:\Study\ProjectSem3\Group6_C2009G2_eProject_SemIII\XYZ Pharmaceuticals\Pharmaceuticals\Pharmaceuticals_Client\Areas\Admin\Views\Managers\Detail.cshtml"
       Write(Html.DisplayNameFor(model => model.managerInfo.Role));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 52 "E:\Study\ProjectSem3\Group6_C2009G2_eProject_SemIII\XYZ Pharmaceuticals\Pharmaceuticals\Pharmaceuticals_Client\Areas\Admin\Views\Managers\Detail.cshtml"
       Write(Html.DisplayFor(model => model.managerInfo.Role));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 55 "E:\Study\ProjectSem3\Group6_C2009G2_eProject_SemIII\XYZ Pharmaceuticals\Pharmaceuticals\Pharmaceuticals_Client\Areas\Admin\Views\Managers\Detail.cshtml"
       Write(Html.DisplayNameFor(model => model.managerInfo.Image));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            <img");
            BeginWriteAttribute("src", " src=\"", 1993, "\"", 2043, 2);
            WriteAttributeValue("", 1999, "/images/AdminImages/", 1999, 20, true);
#nullable restore
#line 58 "E:\Study\ProjectSem3\Group6_C2009G2_eProject_SemIII\XYZ Pharmaceuticals\Pharmaceuticals\Pharmaceuticals_Client\Areas\Admin\Views\Managers\Detail.cshtml"
WriteAttributeValue("", 2019, Model.managerInfo.Image, 2019, 24, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" alt=\"Alternate Text\" width=\"100\" />\r\n        </dd>\r\n        <dt class=\"col-sm-2\">\r\n            ");
#nullable restore
#line 61 "E:\Study\ProjectSem3\Group6_C2009G2_eProject_SemIII\XYZ Pharmaceuticals\Pharmaceuticals\Pharmaceuticals_Client\Areas\Admin\Views\Managers\Detail.cshtml"
       Write(Html.DisplayNameFor(model => model.managerInfo.Created_date));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-sm-10\">\r\n            ");
#nullable restore
#line 64 "E:\Study\ProjectSem3\Group6_C2009G2_eProject_SemIII\XYZ Pharmaceuticals\Pharmaceuticals\Pharmaceuticals_Client\Areas\Admin\Views\Managers\Detail.cshtml"
       Write(Html.DisplayFor(model => model.managerInfo.Created_date));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    ");
#nullable restore
#line 69 "E:\Study\ProjectSem3\Group6_C2009G2_eProject_SemIII\XYZ Pharmaceuticals\Pharmaceuticals\Pharmaceuticals_Client\Areas\Admin\Views\Managers\Detail.cshtml"
Write(Html.ActionLink("Edit", "Edit", new { id = Model.managerInfo.AdminId }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ab2290f1fca6a4ed16b45dd67cbd492adce60c4412072", async() => {
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