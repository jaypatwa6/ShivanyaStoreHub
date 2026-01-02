using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSH.Framework.Context
{
    public interface ITenantContext : IResourceContext
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string DatabaseConnectionString { get; set; }
    }
}
