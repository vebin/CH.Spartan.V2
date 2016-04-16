using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Entities;

namespace CH.Spartan.Infrastructure
{
    /// <summary>
    /// Implement this interface for an entity which must have UserId and TenantId.
    /// </summary>
    public interface IMustHaveUserAndTenant : IMustHaveUser, IMustHaveTenant
    {
    }
}
