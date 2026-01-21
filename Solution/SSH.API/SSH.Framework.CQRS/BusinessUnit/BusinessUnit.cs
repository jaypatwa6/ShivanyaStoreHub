using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSH.Framework.CQRS
{
    public abstract class BusinessUnit : IBusinessUnit
    {
        protected BusinessUnit(IApplicationModule applicationModule)
        {
            ApplicationModule = applicationModule;
            Name = GetType().Name;
        }

        public string Name { get; protected set; }

        public IApplicationModule ApplicationModule { get; protected set; }
    }
}
