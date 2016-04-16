using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Abp.Application.Services.Dto;
using Abp.Dependency;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Extensions;
using Abp.Timing;
using CH.Spartan.DeviceTypes;
using CH.Spartan.Infrastructure;
using CH.Spartan.MultiTenancy;
using CH.Spartan.Users;

namespace CH.Spartan.Web.Models
{
    public static class HtmlHelperExtend
    {

        #region Layout

        public static MvcHtmlString DateTimeRange(this HtmlHelper helper)
        {
            return helper.Action("DateTimeRange", "Layout");
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
        #endregion

        #region AutoComplete
        public static MvcHtmlString AutoCompleteTenant(this HtmlHelper helper, string name, string placeholder, int? value = null, string cls = "w180")
        {
            var text = "";
            if (value.HasValue)
            {
                var def = IocManager.Instance.Resolve<IRepository<Tenant>>().Get(value.Value);
                if (def != null)
                {
                    text = $"{def.Name}";
                }
            }
            var valueField = "value";
            var textField = "displayText";
            var url = "/AutoComplete/Tenant";
            return helper.Action("AutoComplete", "Layout",new { name, url, placeholder, value, text, cls, valueField, textField });
        }

        public static MvcHtmlString AutoCompleteUser(this HtmlHelper helper, string name, string placeholder, long? value = null, string cls = "w180")
        {
            var text = "";
            if (value.HasValue)
            {
                var def = IocManager.Instance.Resolve<IRepository<User,long>>().Get(value.Value);
                if (def != null)
                {
                    text = $"{def.Name}";
                }
            }
            var valueField = "value";
            var textField = "displayText";
            var url = "/AutoComplete/User";
            return helper.Action("AutoComplete", "Layout",
                new { name, url, placeholder, value, text, cls, valueField, textField });
        }
        #endregion

        #region Select

        public static MvcHtmlString GetSelectByDeviceType(this HtmlHelper helper, string name, string allText = "", bool? value = null, string cls = "w180")
        {
            using (IocManager.Instance.Resolve<IUnitOfWorkManager>().Begin())
            {
                var result = IocManager.Instance.Resolve<IRepository<DeviceType>>().GetAll().ToList();
                var list = result.Select(p => new ComboboxItemDto(p.Id.ToString(), p.Name)).ToList();
                if (!allText.IsNullOrEmpty())
                {
                    list.Insert(0, new ComboboxItemDto("", allText));
                }
                return GetSelectHtml(list, name, cls, value);
            }
        }

        public static MvcHtmlString GetSelectByList(this HtmlHelper helper, List<ComboboxItemDto> list, string name, string allText = "", bool? value = null, string cls = "w180")
        {
            return GetSelectHtml(list, name, cls, value);
        }

        public static MvcHtmlString GetSelectByEnum(this HtmlHelper helper, Type enumType, string name, string allText = "", object value = null, string cls = "w180")
        {
            var list = ComboboxHelper.GetListForEnum(enumType, allText);
            return GetSelectHtml(list, name, cls, value);
        }

        public static MvcHtmlString GetSelectByEnable(this HtmlHelper helper, string name, string allText = "", bool? value = null, string cls = "w180")
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
        #endregion
    }
}