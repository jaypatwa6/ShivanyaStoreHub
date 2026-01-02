using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSH.Framework.Context
{
    public interface IResourceContext
    {
        DateTime GrantUtcTime { get; set; }
        DateTime? LastAccessUtcTime { get; set; }
        long TotalAccessCount { get; set; }
    }
}
