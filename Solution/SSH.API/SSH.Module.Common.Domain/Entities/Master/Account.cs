using SSH.Framework.Model.EntityBase;
using System.ComponentModel.DataAnnotations;

namespace SSH.Module.Common.Domain.Entities.Master
{
    public class Account : MasterLongEntity
    {
        #region Fields

        public string AccountName { get; set; }

        public string Notes { get; set; }

        public Guid? AccountTypeID { get; set; }

        public string DatabaseName { get; set; }

        #region Foriegn Key References

        public virtual AccountType AccountType { get; set; }

        #endregion

        #endregion

    }
}
