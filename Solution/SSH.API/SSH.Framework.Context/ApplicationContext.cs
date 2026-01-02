using System.Security.Claims;

namespace SSH.Framework.Context
{
    public class ApplicationContext
    {
        #region Properties
        /// <summary>
        /// Gets or sets the transaction identifier.
        /// </summary>
        /// <value>
        /// The transaction identifier.
        /// </value>
        public Guid TransactionId { get; set; }

        /// <summary>
        /// Gets or sets the current user identity.
        /// Should be set after user authenticated
        /// </summary>
        /// <value>
        /// The current user identity.
        /// </value>
        public ClaimsIdentity UserIdentity { get; set; }


        /// <summary>
        /// Gets the current user context.
        /// </summary>
        /// <value>
        /// The current user context.
        /// </value>
        public IUserContext UserContext { get; set; }

        /// <summary>
        /// Gets the current tenant context.
        /// </summary>
        /// <value>
        /// The current tenant context.
        /// </value>
        public ITenantContext TenantContext { get; set; }

        /// <summary>
        /// Returns true if this application context is valid.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is valid; otherwise, <c>false</c>.
        /// </value>
        public bool IsValid
        {
            get { return UserContext != null && TenantContext != null; }
        }

        /// <summary>
        /// Gets the service resolver.
        /// </summary>
        /// <value>
        /// The service resolver.
        /// </value>
        public Func<Type, object> ServiceResolver { get; set; }

        #endregion
    }
}
