using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abp.Domain.Entities
{
    public interface IMustHaveUser
    {
        int UserId { get; set; }
    }
}
