using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Abp.Timing;
using Abp.Web.Mvc.Authorization;
using Abp.WebApi.Authorization;
using CH.Spartan.Web.Models;

namespace CH.Spartan.Web.Controllers
{
    [AbpMvcAuthorize()]
    public class LayoutController : SpartanControllerBase
    {
        [ChildActionOnly]
        public PartialViewResult DateTimeRange()
        {
            return PartialView("_DateTimeRange");
        }

        [ChildActionOnly]
        public PartialViewResult AutoComplete(string name, string url, string placeholder, int? value,string text,string cls,string valueField,string textField)
        {
            ViewBag.Name = name;
            ViewBag.Url = url;
            ViewBag.Class = cls;
            ViewBag.Placeholder = placeholder;
            ViewBag.Value = value;
            ViewBag.Text = text;
            ViewBag.ValueField = valueField;
            ViewBag.TextField = textField;
            ViewBag.HasInitValue = value.HasValue;
            return PartialView("_AutoComplete");
        }
    }
}