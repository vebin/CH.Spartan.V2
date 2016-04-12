using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Abp.Application.Services.Dto;
using CH.Spartan.Commons;

namespace CH.Spartan.Web.Models
{
    public static class HtmlHelperExtend
    {
        public static MvcHtmlString GetOptionHtmlByList(this HtmlHelper helper, List<ComboboxItemDto> list, bool? value = null,
          bool? isHaveAll = null, string allText = "全部")
        {
            return GetOptionHtml(list, value);
        }

        public static MvcHtmlString GetOptionHtmlByEnum(this HtmlHelper helper, Type enumType, object value = null,
            bool? isHaveAll = null, string allText = "全部")
        {
            var list = ComboboxHelper.GetListForEnum(enumType, isHaveAll, allText);
            return GetOptionHtml(list, value);
        }

        public static MvcHtmlString GetOptionHtmlByEnable(this HtmlHelper helper, bool? value = null,
            bool? isHaveAll = null, string allText = "全部")
        {
            var list = ComboboxHelper.GetListForEnable(isHaveAll, allText);
            return GetOptionHtml(list, value);
        }

        public static MvcHtmlString GetOptionHtml(List<ComboboxItemDto> list, object value = null)
        {
            var sb = new StringBuilder();
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
            return MvcHtmlString.Create(sb.ToString());
        }

    }
}