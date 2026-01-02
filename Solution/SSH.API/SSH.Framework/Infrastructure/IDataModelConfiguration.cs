using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSH.Framework.Infrastructure
{
    public interface IDataModelConfiguration
    {
        void ApplyToBuilder(DbModelBuilder modelBuilder);
    }
}
