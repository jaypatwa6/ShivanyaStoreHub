using Microsoft.EntityFrameworkCore;

namespace SSH.Framework.Persistence.Infrastructure
{
    public abstract class DataContextBase : DbContext, IDataContext
    {

    }
}
