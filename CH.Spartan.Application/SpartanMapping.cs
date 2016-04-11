using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Dependency;
using Abp.Localization;
using AutoMapper;
using CH.Spartan.MultiTenancy;
using CH.Spartan.MultiTenancy.Dto;

namespace CH.Spartan
{
   public static class SpartanMapping
    {
       public static void Map()
       {
           Mapper.CreateMap<Tenant, GetTenantListDto>()
               .ForMember(d => d.IsActiveText, opt => opt.MapFrom(o => o.IsActive ? L("是") : L("否")));
       }

       private static string L(string name)
       {
           return LocalizationHelper.GetString(SpartanConsts.LocalizationSourceName, name);
       }
    }
}
