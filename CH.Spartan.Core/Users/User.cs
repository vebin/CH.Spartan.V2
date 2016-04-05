using System;
using Abp.Authorization.Users;
using Abp.Extensions;
using CH.Spartan.MultiTenancy;
using Microsoft.AspNet.Identity;

namespace CH.Spartan.Users
{
    public class User : AbpUser<Tenant, User>
    {
        public const string DefaultPassword = "123456";

        public static string CreateRandomPassword()
        {
            return Guid.NewGuid().ToString("N").Truncate(16);
        }

        public static User CreateTenantAdminUser(int tenantId,string userName,string emailAddress,string password)
        {
            return new User
            {
                TenantId = tenantId,
                UserName = userName,
                Name = userName,
                Surname = userName,
                IsEmailConfirmed = true,
                EmailAddress = emailAddress,
                IsActive = true,
                Password = new PasswordHasher().HashPassword(password)
            };
        }
    }
}