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
   public static class ComboboxHelper
    {
        public static List<ComboboxItemDto> GetListForEnum(Type enumType, bool? isHaveAll = null, string allText = "全部")
        {
            var localizationSource =
                IocManager.Instance.Resolve<ILocalizationManager>().GetSource(SpartanConsts.LocalizationSourceName);
            var list = new List<ComboboxItemDto>();
            var values = System.Enum.GetValues(enumType);

            foreach (var val in values)
            {
                var obj = (System.Enum)val;
                var displayName = obj.GetDisplayName();
                var localName = localizationSource.GetString(displayName);
                list.Add(new ComboboxItemDto(val.ToString(), localName));
            }

            if (isHaveAll.HasValue)
            {
                var name = localizationSource.GetString(allText);
                list.Add(new ComboboxItemDto("", name));
            }

            return list;
        }

       public static List<ComboboxItemDto> GetListForEnable(bool? isHaveAll = null, string allText = "全部")
       {
            var localizationSource =
                IocManager.Instance.Resolve<ILocalizationManager>().GetSource(SpartanConsts.LocalizationSourceName);
            var list = new List<ComboboxItemDto>();

            list.Add(new ComboboxItemDto("True", localizationSource.GetString("是")));
            list.Add(new ComboboxItemDto("False", localizationSource.GetString("否")));

            if (isHaveAll.HasValue)
            {
                var name = localizationSource.GetString(allText);
                list.Add(new ComboboxItemDto("", name));
            }
            return list;
       }
    }
}
