#pragma checksum "E:\Study\ProjectSem3\Group6_C2009G2_eProject_SemIII\XYZ Pharmaceuticals\Pharmaceuticals\Pharmaceuticals_Client\Views\Products\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "89535b4fb80597684c78db5df223ee6901a0fb64"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Products_Detail), @"mvc.1.0.view", @"/Views/Products/Detail.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"89535b4fb80597684c78db5df223ee6901a0fb64", @"/Views/Products/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"80231ad20f996d7b78fcccfd16274f691110c9a9", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Products_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Pharmaceuticals_Client.Models.UserProductViewModels>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\Study\ProjectSem3\Group6_C2009G2_eProject_SemIII\XYZ Pharmaceuticals\Pharmaceuticals\Pharmaceuticals_Client\Views\Products\Detail.cshtml"
  
    ViewData["Title"] = "Detail";
    Layout = "~/Views/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""section-bg section-padding subheader"" style=""background-image: url(/home/images/subheader.jpg);"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-12"">
                <h1 class=""page-title"">Products Details</h1>
                <nav aria-label=""breadcrumb"">
                    <ol class=""breadcrumb"">
                        <li class=""breadcrumb-item""><a href=""/Home"">Home</a></li>
                        <li class=""breadcrumb-item active"" aria-current=""page"">Products Details</li>
                    </ol>
                </nav>
            </div>
        </div>
    </div>
</div>


<section class=""section pb-0"">
    <div class=""container"">
        <div class=""row"">
            <div class=""col-xl-8"">
                <div class=""shop_details_box"">

                    <div class=""row"">
                        <div class=""col-lg-6"">
                            <div class=""product_slider_box"">
                                <div class=""prod");
            WriteLiteral("uct_slider\">\r\n\r\n                                    <div class=\"slide_item\">\r\n                                        <img");
            BeginWriteAttribute("src", " src=\"", 1297, "\"", 1347, 2);
            WriteAttributeValue("", 1303, "/images/Products/", 1303, 17, true);
#nullable restore
#line 37 "E:\Study\ProjectSem3\Group6_C2009G2_eProject_SemIII\XYZ Pharmaceuticals\Pharmaceuticals\Pharmaceuticals_Client\Views\Products\Detail.cshtml"
WriteAttributeValue("", 1320, Model.product.ProductImage, 1320, 27, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""image-fit-contain"" alt=""img"">
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class=""col-lg-6"">
                            <div class=""product_details product_block"">
                                <h2 class=""product_title"">");
#nullable restore
#line 44 "E:\Study\ProjectSem3\Group6_C2009G2_eProject_SemIII\XYZ Pharmaceuticals\Pharmaceuticals\Pharmaceuticals_Client\Views\Products\Detail.cshtml"
                                                     Write(Model.product.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n\r\n                                <ul class=\"product_meta\">\r\n                                    <li>\r\n                                        <strong>");
#nullable restore
#line 48 "E:\Study\ProjectSem3\Group6_C2009G2_eProject_SemIII\XYZ Pharmaceuticals\Pharmaceuticals\Pharmaceuticals_Client\Views\Products\Detail.cshtml"
                                           Write(Model.product.ProductSize);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\r\n                                    </li>\r\n                                    <li>\r\n                                        <strong>");
#nullable restore
#line 51 "E:\Study\ProjectSem3\Group6_C2009G2_eProject_SemIII\XYZ Pharmaceuticals\Pharmaceuticals\Pharmaceuticals_Client\Views\Products\Detail.cshtml"
                                           Write(Model.product.Productivity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\r\n                                    </li>\r\n                                    <li>\r\n                                        <strong>");
#nullable restore
#line 54 "E:\Study\ProjectSem3\Group6_C2009G2_eProject_SemIII\XYZ Pharmaceuticals\Pharmaceuticals\Pharmaceuticals_Client\Views\Products\Detail.cshtml"
                                           Write(Model.product.MachineWeight);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\r\n                                    </li>\r\n                                    <li>\r\n                                        <strong>");
#nullable restore
#line 57 "E:\Study\ProjectSem3\Group6_C2009G2_eProject_SemIII\XYZ Pharmaceuticals\Pharmaceuticals\Pharmaceuticals_Client\Views\Products\Detail.cshtml"
                                           Write(Model.product.ModelNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\r\n                                    </li>\r\n\r\n                                    <li>\r\n                                        <strong>");
#nullable restore
#line 61 "E:\Study\ProjectSem3\Group6_C2009G2_eProject_SemIII\XYZ Pharmaceuticals\Pharmaceuticals\Pharmaceuticals_Client\Views\Products\Detail.cshtml"
                                           Write(Model.product.Category.CategoryName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\r\n                                    </li>\r\n                                    <li>\r\n                                        <strong>");
#nullable restore
#line 64 "E:\Study\ProjectSem3\Group6_C2009G2_eProject_SemIII\XYZ Pharmaceuticals\Pharmaceuticals\Pharmaceuticals_Client\Views\Products\Detail.cshtml"
                                           Write(Model.product.Manufacturer.ManufacturerName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\r\n\r\n                                    </li>\r\n");
#nullable restore
#line 67 "E:\Study\ProjectSem3\Group6_C2009G2_eProject_SemIII\XYZ Pharmaceuticals\Pharmaceuticals\Pharmaceuticals_Client\Views\Products\Detail.cshtml"
                                     foreach (var item in Model.product.Attributes)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <li>\r\n                                            <strong>");
#nullable restore
#line 70 "E:\Study\ProjectSem3\Group6_C2009G2_eProject_SemIII\XYZ Pharmaceuticals\Pharmaceuticals\Pharmaceuticals_Client\Views\Products\Detail.cshtml"
                                               Write(Html.DisplayFor(modelItem => item.AttributeName));

#line default
#line hidden
#nullable disable
            WriteLiteral(" : ");
#nullable restore
#line 70 "E:\Study\ProjectSem3\Group6_C2009G2_eProject_SemIII\XYZ Pharmaceuticals\Pharmaceuticals\Pharmaceuticals_Client\Views\Products\Detail.cshtml"
                                                                                                   Write(Html.DisplayFor(modelItem => item.Value));

#line default
#line hidden
#nullable disable
            WriteLiteral(" (");
#nullable restore
#line 70 "E:\Study\ProjectSem3\Group6_C2009G2_eProject_SemIII\XYZ Pharmaceuticals\Pharmaceuticals\Pharmaceuticals_Client\Views\Products\Detail.cshtml"
                                                                                                                                              Write(Html.DisplayFor(modelItem => item.Unit));

#line default
#line hidden
#nullable disable
            WriteLiteral(")</strong>\r\n                                        </li>\r\n");
#nullable restore
#line 72 "E:\Study\ProjectSem3\Group6_C2009G2_eProject_SemIII\XYZ Pharmaceuticals\Pharmaceuticals\Pharmaceuticals_Client\Views\Products\Detail.cshtml"
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                </ul>
                                <div class=""product_social"">
                                    <button type=""button"" class=""social_trigger"">
                                        <i class=""fas fa-share-alt""></i>
                                    </button>
                                    <ul class=""social_media"">
                                        <li>
                                            <a href=""#"">
                                                <i class=""fab fa-facebook-f""></i>
                                            </a>
                                        </li>
                                        <li>
                                            <a href=""#"">
                                                <i class=""fab fa-twitter""></i>
                                            </a>
                                        </li>
                                        <li>
                                           ");
            WriteLiteral(@" <a href=""#"">
                                                <i class=""fab fa-linkedin-in""></i>
                                            </a>
                                        </li>
                                        <li>
                                            <a href=""#"">
                                                <i class=""fab fa-pinterest-p""></i>
                                            </a>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>



                    <div class=""row"">
                        <div class=""col-12"">
                            <div class=""customer_photos"">
                                <h4>Customer Photos</h4>
                                <div class=""images"">
");
#nullable restore
#line 113 "E:\Study\ProjectSem3\Group6_C2009G2_eProject_SemIII\XYZ Pharmaceuticals\Pharmaceuticals\Pharmaceuticals_Client\Views\Products\Detail.cshtml"
                                     foreach (var item in ViewBag.products)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <img");
            BeginWriteAttribute("src", " src=\"", 5428, "\"", 5469, 2);
            WriteAttributeValue("", 5434, "/images/Products/", 5434, 17, true);
#nullable restore
#line 115 "E:\Study\ProjectSem3\Group6_C2009G2_eProject_SemIII\XYZ Pharmaceuticals\Pharmaceuticals\Pharmaceuticals_Client\Views\Products\Detail.cshtml"
WriteAttributeValue("", 5451, item.ProductImage, 5451, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"image-fit-contain\" alt=\"img\">\r\n");
#nullable restore
#line 116 "E:\Study\ProjectSem3\Group6_C2009G2_eProject_SemIII\XYZ Pharmaceuticals\Pharmaceuticals\Pharmaceuticals_Client\Views\Products\Detail.cshtml"

                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class=""row"">
                        <div class=""col-12"">
                            <h4>Customer Reviews</h4>
                            <ul class=""comments shop_comments"">
");
#nullable restore
#line 128 "E:\Study\ProjectSem3\Group6_C2009G2_eProject_SemIII\XYZ Pharmaceuticals\Pharmaceuticals\Pharmaceuticals_Client\Views\Products\Detail.cshtml"
                                 foreach (var item in ViewBag.feedback)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <li class=\"comment\">\r\n                                            <p class=\"comment_text\">\r\n                                                ");
#nullable restore
#line 132 "E:\Study\ProjectSem3\Group6_C2009G2_eProject_SemIII\XYZ Pharmaceuticals\Pharmaceuticals\Pharmaceuticals_Client\Views\Products\Detail.cshtml"
                                           Write(item.Comments);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                                            </p> \r\n                                    </li>\r\n");
#nullable restore
#line 135 "E:\Study\ProjectSem3\Group6_C2009G2_eProject_SemIII\XYZ Pharmaceuticals\Pharmaceuticals\Pharmaceuticals_Client\Views\Products\Detail.cshtml"
                                } 

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            </ul>
                        </div>
                    </div>
                </div>
            </div>
            <aside class=""col-xl-4"">
                <div class=""product_sidebar"">
                    <div class=""product_sidebar_wrap"">
                        <div class=""sidebar_widget"">
                            <h5 class=""widget_title"">Similar Products</h5>
                            <ul class=""related_products"">
");
#nullable restore
#line 147 "E:\Study\ProjectSem3\Group6_C2009G2_eProject_SemIII\XYZ Pharmaceuticals\Pharmaceuticals\Pharmaceuticals_Client\Views\Products\Detail.cshtml"
                                 foreach (var prod in ViewBag.products)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <li>\r\n                                        <div class=\"product_thumb\">\r\n                                            <a href=\"#\">\r\n                                                <img");
            BeginWriteAttribute("src", " src=\"", 7123, "\"", 7164, 2);
            WriteAttributeValue("", 7129, "/images/Products/", 7129, 17, true);
#nullable restore
#line 152 "E:\Study\ProjectSem3\Group6_C2009G2_eProject_SemIII\XYZ Pharmaceuticals\Pharmaceuticals\Pharmaceuticals_Client\Views\Products\Detail.cshtml"
WriteAttributeValue("", 7146, prod.ProductImage, 7146, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""image-fit-contain"" alt=""img"">
                                            </a>
                                        </div>
                                        <div class=""product_caption"">
                                            <h6 class=""product_title mb-0""><a href=""shop-details.html"">");
#nullable restore
#line 156 "E:\Study\ProjectSem3\Group6_C2009G2_eProject_SemIII\XYZ Pharmaceuticals\Pharmaceuticals\Pharmaceuticals_Client\Views\Products\Detail.cshtml"
                                                                                                  Write(prod.ProductName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a></h6>\r\n                                        </div>\r\n                                    </li>\r\n");
#nullable restore
#line 159 "E:\Study\ProjectSem3\Group6_C2009G2_eProject_SemIII\XYZ Pharmaceuticals\Pharmaceuticals\Pharmaceuticals_Client\Views\Products\Detail.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

                            </ul>
                        </div>
                    </div>
                </div>
            </aside>
        </div>
    </div>
</section>


<section class=""section-padding thm-bg-color-light"">
    <div class=""container"">
        <div class=""row"">

            <div class=""col-lg-3 col-sm-6"">
                <div class=""htw-block"">
                    <div class=""icon"">
                        <i class=""fal fa-truck""></i>
                    </div>
                    <div class=""text"">
                        <h6 class=""title"">Free Shipping</h6>
                        <p class=""mb-0"">Lorem ipsum dolor sit amet.</p>
                    </div>
                </div>
            </div>

            <div class=""col-lg-3 col-sm-6"">
                <div class=""htw-block"">
                    <div class=""icon"">
                        <i class=""fal fa-shopping-bag""></i>
                    </div>
                    <div class=""text"">
           ");
            WriteLiteral(@"             <h6 class=""title"">100% Secure Payment</h6>
                        <p class=""mb-0"">Lorem ipsum dolor sit amet.</p>
                    </div>
                </div>
            </div>

            <div class=""col-lg-3 col-sm-6"">
                <div class=""htw-block"">
                    <div class=""icon"">
                        <i class=""fal fa-headphones-alt""></i>
                    </div>
                    <div class=""text"">
                        <h6 class=""title"">Great Support 24x7</h6>
                        <p class=""mb-0"">Lorem ipsum dolor sit amet.</p>
                    </div>
                </div>
            </div>

            <div class=""col-lg-3 col-sm-6"">
                <div class=""htw-block"">
                    <div class=""icon"">
                        <i class=""fal fa-cube""></i>
                    </div>
                    <div class=""text"">
                        <h6 class=""title"">Money - Back Guarantee</h6>
                        <p clas");
            WriteLiteral(@"s=""mb-0"">Lorem ipsum dolor sit amet.</p>
                    </div>
                </div>
            </div>

        </div>
    </div>
</section>







<a href=""#"" data-target=""html"" class=""back-to-top ft-sticky"">
    <i class=""fal fa-chevron-up""></i>
</a>






");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Pharmaceuticals_Client.Models.UserProductViewModels> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
