using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Dependency;
using Abp.Localization;

namespace CH.Spartan.Commons
{
    #region Enum扩展

    public static class EnumExtend
    {
        public static string GetDisplayName(this System.Enum enumItem)
        {
            var field = enumItem.GetType().GetField(enumItem.ToString());
            if (field == null) return enumItem.ToString();

            var attributes = field.GetCustomAttributes(typeof(EnumDisplayNameAttribute), false);
            foreach (var attribute in attributes)
            {
                if (attribute is EnumDisplayNameAttribute)
                {
                    return ((EnumDisplayNameAttribute)attribute).DisplayName;
                }
            }
            return string.Empty;
        }
    }

    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field)]
    public class EnumDisplayNameAttribute : Attribute
    {
        public EnumDisplayNameAttribute()
        { }

        public EnumDisplayNameAttribute(string text)
        {
            this.DisplayName = text;
        }

        public string DisplayName { get; set; }
    }

    [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Field, AllowMultiple = true)]
    public class EnumFilterAttribute : Attribute
    {
        public EnumFilterAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }

    #endregion Enum扩展
}
