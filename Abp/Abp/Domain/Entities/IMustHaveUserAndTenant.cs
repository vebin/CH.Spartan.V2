using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abp.Domain.Entities
{
    /// <summary>
    /// Implement this interface for an entity which must have UserId and TenantId.
    /// </summary>
    public interface IMustHaveUserAndTenant : IMustHaveUser, IMustHaveTenant
    {
    }
}
