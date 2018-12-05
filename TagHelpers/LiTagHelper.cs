using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TagHelpers.TagHelpers
{
    //Ul etiketine items diye parametre oluşturarak listelemeleri yapıyoruz.

    [HtmlTargetElement("ul", Attributes = "items")]
    public class LiTagHelper : TagHelper
    {
        public string items { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.SetAttribute("class", "list-group");

            foreach (var item in ProductManager.ProductList().Where(x => x.CategoryId == Convert.ToInt32(items)).ToList())
            {
                TagBuilder li = new TagBuilder("li");
                TagBuilder a = new TagBuilder("a");
                li.Attributes["class"] = "list-group-item";
                a.Attributes["href"] = item.PName;
                a.Attributes["title"] = item.PName;
                a.InnerHtml.AppendHtml(item.PName);
                li.InnerHtml.AppendHtml(a);
                output.PreContent.AppendHtml(li);
            }
        }
    }

    class Product
    {
        public int PId { get; set; }
        public int CategoryId { get; set; }
        public string PName { get; set; }
        public string PDesc { get; set; }
    }

    static class ProductManager
    {
        public static List<Product> ProductList()
        {
            List<Product> products = new List<Product>();
            products.Add(new Product() { PName = "Laptop 1", CategoryId = 1, PDesc = "Çok güzel laptop", PId = 1 });
            products.Add(new Product() { PName = "Laptop 2", CategoryId = 1, PDesc = "Çok güzel laptop", PId = 2 });
            products.Add(new Product() { PName = "Laptop 3", CategoryId = 1, PDesc = "Çok güzel laptop", PId = 3 });
            products.Add(new Product() { PName = "Laptop 4", CategoryId = 1, PDesc = "Çok güzel laptop", PId = 4 });
            products.Add(new Product() { PName = "Laptop 5", CategoryId = 1, PDesc = "Çok güzel laptop", PId = 5 });
            products.Add(new Product() { PName = "Laptop 6", CategoryId = 1, PDesc = "Çok güzel laptop", PId = 6 });
            products.Add(new Product() { PName = "Laptop 7", CategoryId = 1, PDesc = "Çok güzel laptop", PId = 7 });
            products.Add(new Product() { PName = "Laptop 8", CategoryId = 1, PDesc = "Çok güzel laptop", PId = 8 });

            return products;
        }
    }
}
