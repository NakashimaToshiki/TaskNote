using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;



public static class HtmlHelperPartialExtensions
{
    public static IHtmlContent PartialWithPrefix(this IHtmlHelper htmlHelper, string partialViewName, object model, string prefix)
    {
        var htmlFieldPrefix = (string.Empty.Equals(prefix) ? "." : "") + prefix;
        return htmlHelper.Partial(partialViewName, model, new ViewDataDictionary(htmlHelper.ViewData) { TemplateInfo = { HtmlFieldPrefix = htmlFieldPrefix } });
    }

    public static Task<IHtmlContent> PartialWithPrefixAsync(this IHtmlHelper htmlHelper, string partialViewName, object model, string prefix)
    {
        var htmlFieldPrefix = (string.Empty.Equals(prefix) ? "." : "") + prefix;
        return htmlHelper.PartialAsync(partialViewName, model, new ViewDataDictionary(htmlHelper.ViewData) { TemplateInfo = { HtmlFieldPrefix = htmlFieldPrefix } });
    }

    /*
    public static IHtmlContent PartialWithPrefixFor<TModel, TProperty>(this IHtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, string partialViewName)
    {
        string prefix = ExpressionHelper.GetExpressionText(expression);
        object model = ExpressionMetadataProvider.FromLambdaExpression(expression, helper.ViewData, helper.MetadataProvider).Model;
        return PartialWithPrefix(helper, partialViewName, model, prefix);
    }

    public static Task<IHtmlContent> PartialWithPrefixForAsync<TModel, TProperty>(this IHtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, string partialViewName)
    {
        string prefix = ExpressionHelper.GetExpressionText(expression);
        object model = ExpressionMetadataProvider.FromLambdaExpression(expression, helper.ViewData, helper.MetadataProvider).Model;
        return PartialWithPrefixAsync(helper, partialViewName, model, prefix);
    }*/
}