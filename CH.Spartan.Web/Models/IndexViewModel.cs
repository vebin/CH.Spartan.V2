using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Abp.Application.Navigation;
using Abp.Localization;
using CH.Spartan.Sessions.Dto;

namespace CH.Spartan.Web.Models
{
    public class IndexViewModel
    {
        /// <summary>
        /// 主菜单
        /// </summary>
        public UserMenu MainMenu { get; set; }

        /// <summary>
        /// 当前语言
        /// </summary>
        public LanguageInfo CurrentLanguage { get; set; }

        /// <summary>
        /// 全部语言
        /// </summary>
        public IReadOnlyList<LanguageInfo> Languages { get; set; }

        /// <summary>
        /// 当前登录信息
        /// </summary>
        public GetCurrentLoginInformationsOutput LoginInformations { get; set; }
    }
}