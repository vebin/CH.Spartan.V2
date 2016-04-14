using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Abp.Application.Services.Dto;
using Abp.Dependency;
using Abp.Timing;
using CH.Spartan.Commons;
using CH.Spartan.MultiTenancy;

namespace CH.Spartan.Web.Models
{
    public static class HtmlHelperExtend
    {

        public static MvcHtmlString DateTimeRange(this HtmlHelper helper)
        {
            return helper.Action("DateTimeRange", "Layout");
        }

        public static MvcHtmlString AutoCompleteTenant(this HtmlHelper helper, string name, string placeholder,
            int? value = null, string cls = "w180")
        {
            var text = "";
            if (value.HasValue)
            {
                text =
                    IocManager.Instance.Resolve<ITenantAppService>()
                        .GetTenantAsync(new IdInput(value.Value))
                        .Result.Tenant?.Name;
            }
            var valueField = "id";
            var textField = "name";
            var url = "/AutoComplete/Tenant";
            return helper.Action("AutoComplete", "Layout",
                new { name, url, placeholder, value, text, cls, valueField, textField });
        }

        public static MvcHtmlString GetSelectByList(this HtmlHelper helper, List<ComboboxItemDto> list, string name, bool? value = null,
          bool? isHaveAll = null, string allText = "全部", string cls = "w180")
        {
            return GetSelectHtml(list, name, cls, value);
        }

        public static MvcHtmlString GetSelectByEnum(this HtmlHelper helper, Type enumType, string name, string allText = "全部", object value = null,string cls = "w180")
        {
            var list = ComboboxHelper.GetListForEnum(enumType,allText);
            return GetSelectHtml(list, name, cls, value);
        }

        public static MvcHtmlString GetSelectByEnable(this HtmlHelper helper, string name, string allText = "全部", bool? value = null,string cls = "w180")
        {
            var list = ComboboxHelper.GetListForEnable(allText);
            return GetSelectHtml(list, name, cls, value);
        }

        public static MvcHtmlString GetSelectHtml(List<ComboboxItemDto> list, string name, string cls, object value = null)
        {
            var sb = new StringBuilder();
            sb.Append("<select class=\"form-control " + cls + "\" name=\"" + name + "\">");
            foreach (var item in list)
            {
                if (value != null && item.Value.ToLower().Equals(value.ToString().ToLower()))
                {
                    sb.AppendFormat("<option value=\"{0}\" selected=\"selected\">{1}</option>", item.Value.ToLower(), item.DisplayText);
                }
                else
                {
                    sb.AppendFormat("<option value=\"{0}\">{1}</option>", item.Value.ToLower(), item.DisplayText);
                }
            }
            sb.Append("</select>");
            return MvcHtmlString.Create(sb.ToString());
        }

        public static MvcHtmlString SearchText(this HtmlHelper helper, string placeholder, string btnText, string cls = "w300")
        {
            var sb = new StringBuilder();
            sb.Append("<div class=\"input-group\">");
            sb.Append("<input type=\"text\" class=\"form-control " + cls + "\" placeholder=\"" + placeholder + "\" name=\"SearchText\">");
            sb.Append("<span class=\"input-group-btn\">");
            sb.Append("<button class=\"btn btn-default\" type=\"button\" id=\"btn-search\">" + btnText + "</button>");
            sb.Append("</span>");
            sb.Append("</div>");
            return MvcHtmlString.Create(sb.ToString());
        }

    }
}