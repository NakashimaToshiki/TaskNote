using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Buffers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Threading.Tasks;

namespace TaskNote.JQruery.TagHelpers
{
    public class PartialFixTagHelper : PartialTagHelper
    {
        public string Pre { get; set; }

        public string Suffix { get; set; }

        public PartialFixTagHelper(ICompositeViewEngine viewEngine,
                                IViewBufferScope viewBufferScope)
                               : base(viewEngine, viewBufferScope)
        {
            Console.WriteLine("ab");
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            // Append ".min" to load the minified partial view.
            var content = await output.GetChildContentAsync();

            await base.ProcessAsync(context, output);
        }

        public override void Init(TagHelperContext context)
        {
            base.Init(context);
        }
    }
}
