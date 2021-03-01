using System.Collections.Generic;
using AmazonBookStore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace AmazonBookStore.Infrastructure
{

    //Purpose of this class is to create a tag that can be used to dynamically display pages


    [HtmlTargetElement("div", Attributes = "page-model")]

    public class PageLinkTagHelper:TagHelper
    {
        //UrlHelperFactory - Something we use to constuct a URL (Pretty self explantatory)
        private IUrlHelperFactory urlHelperFactory;

        public PageLinkTagHelper(IUrlHelperFactory hp)
        {
            urlHelperFactory = hp;
        }


        //Variables used to create pagination, along with applying CSS elements

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        public PageInfo PageModel { get; set; }

        public string PageAction { get; set; }

        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
        public Dictionary<string, object> PageUrlValues { get; set; } = new Dictionary<string, object>();


        public bool PageClassesEnabled { get; set; } = false;

        public string PageClass { get; set; }

        public string PageClassNormal { get; set; }

        public string PageClassSelected { get; set; }


        //Overriding the process method

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);

            TagBuilder result = new TagBuilder("div");

            //Constructs the tags inserted into the HTML that will show pagination
            //along with the css

            for (int i = 1; i <= PageModel.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");

                PageUrlValues["page"] = i;
                tag.Attributes["href"] = urlHelper.Action(PageAction, PageUrlValues);

                if (PageClassesEnabled)
                {
                    tag.AddCssClass(PageClass);
                    tag.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                }

                tag.InnerHtml.Append(i.ToString());

                result.InnerHtml.AppendHtml(tag);
            }

            output.Content.AppendHtml(result.InnerHtml);
        }


    }
}
