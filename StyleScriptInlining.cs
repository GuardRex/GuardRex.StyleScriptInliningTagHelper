using System.IO;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace GuardRex.StyleScriptInliningTagHelper
{
    [HtmlTargetElement("script", Attributes = "inline")]
    [HtmlTargetElement("style", Attributes = "inline")]
    public class StyleScriptInliningTagHelper : TagHelper
    {
        private readonly string _wwwrootPath;

        public StyleScriptInliningTagHelper(IHostingEnvironment env)
        {
            _wwwrootPath = env.WebRootPath + "\\";
        }

        [ViewContext]
        public ViewContext ViewContext { get; set; }
        public bool Inline { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (!Inline)
            {
                return;
            }
            var src = output.Attributes["src"];
            var path = src?.Value.ToString();
            if (path == null)
            {
                return;
            }
            FileInfo fileInfo = new FileInfo(_wwwrootPath + path);
            if (!fileInfo.Exists)
            {
                return;
            }
            using (var readStream = fileInfo.OpenRead())
            using (var reader = new StreamReader(readStream, Encoding.UTF8))
            {
                output.Content.AppendHtml(reader.ReadToEnd());
            }
            output.Attributes.Remove(src);
        }
    }
}
