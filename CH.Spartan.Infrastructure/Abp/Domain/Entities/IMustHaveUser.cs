using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CH.Spartan.Infrastructure
{
    public interface IMustHaveUser
    {
        long UserId { get; set; }
    }
}
