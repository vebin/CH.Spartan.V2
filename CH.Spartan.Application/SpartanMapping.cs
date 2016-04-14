using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Dependency;
using Abp.Localization;
using AutoMapper;
using CH.Spartan.Devices;
using CH.Spartan.Devices.Dto;
using CH.Spartan.MultiTenancy;
using CH.Spartan.MultiTenancy.Dto;
using CH.Spartan.Users;
using CH.Spartan.Users.Dto;

namespace CH.Spartan
{
   public static class SpartanMapping
    {
       public static void Map()
       {
           Mapper.CreateMap<Tenant, GetTenantListDto>()
               .ForMember(d => d.IsActiveText, opt => opt.MapFrom(o => o.IsActive ? L("是") : L("否")));

           Mapper.CreateMap<User, GetUserListDto>()
               .ForMember(d => d.IsActiveText, opt => opt.MapFrom(o => o.IsActive ? L("是") : L("否")))
               .ForMember(d => d.TenantText, opt => opt.MapFrom(o => o.Tenant != null ? o.Tenant.Name : "-"));

           Mapper.CreateMap<Device, GetDeviceListDto>()
               .ForMember(d => d.TenancyName, opt => opt.MapFrom(o => o.Tenant != null ? o.Tenant.Name : ""))
               .ForMember(d => d.UserName, opt => opt.MapFrom(o => o.User != null ? o.User.Name : ""))
               .ForMember(d => d.DeviceTypeName, opt => opt.MapFrom(o => o.DeviceType != null ? o.DeviceType.Name : ""))
               .ForMember(d => d.IsOnlineText, opt => opt.MapFrom(o => DeviceHelper.IsOnline(o) ? L("是") : L("否")))
               .ForMember(d => d.IsExpireText, opt => opt.MapFrom(o => DeviceHelper.IsExpire(o) ? L("是") : L("否")))
               .ForMember(d => d.IsLocatedText, opt => opt.MapFrom(o => o.GIsLocated? L("是") : L("否")));
        }

        private static string L(string name)
       {
           return LocalizationHelper.GetString(SpartanConsts.LocalizationSourceName, name);
       }
    }
}
