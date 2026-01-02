namespace SSH.Framework.Context
{
    public interface IUserContext : IResourceContext
    {
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        /// <value>
        /// The user identifier.
        /// </value>
        Guid UserId { get; set; }

        /// <summary>
        /// Gets or sets the user name.
        /// </summary>
        /// <value>
        /// The user name.
        /// </value>
        string UserName { get; set; }

        /// <summary>
        /// Gets or sets the hash password.
        /// </summary>
        /// <value>
        /// The hash password.
        /// </value>
        string HashPassword { get; set; }

        /// <summary>
        /// Gets or sets the tenant key.
        /// </summary>
        /// <value>
        /// The tenant key.
        /// </value>
        long TenantKey { get; set; }

        /// <summary>
        /// Gets or sets the time zone.
        /// </summary>
        /// <value>
        /// The time zone.
        /// </value>
        string TimeZoneId { get; set; }

        /// <summary>
        /// Gets or sets the culture.
        /// </summary>
        /// <value>
        /// The culture.
        /// </value>
        string CultureName { get; set; }

        /// <summary>
        /// Gets or sets the UI culture.
        /// </summary>
        /// <value>
        /// The UI culture.
        /// </value>
        string UICultureName { get; set; }

        /// <summary>
        /// Gets the authorized roles.
        /// </summary>
        /// <value>
        /// The authorized roles.
        /// </value>
        List<string> AuthorizedRoles { get; set; }

        /// <summary>
        /// Gets or sets the type of the authorization.
        /// </summary>
        /// <value>
        /// The type of the authorization.
        /// </value>
        string AuthorizationType { get; set; }

        /// <summary>
        /// Get or set authorized permissions
        /// </summary>
        IEnumerable<Permission> Permissions { get; set; }
    }

    public class Permission
    {
        /// <summary>
        /// Permission keyword
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// Permission friendly name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Can Read right
        /// </summary>
        public bool CanRead { get; set; }
        /// <summary>
        /// Can Create right
        /// </summary>
        public bool CanCreate { get; set; }
        /// <summary>
        /// Can Update right
        /// </summary>
        public bool CanUpdate { get; set; }
        /// <summary>
        /// Can Delete right
        /// </summary>
        public bool CanDelete { get; set; }
        /// <summary>
        /// Navigation routes for href validation
        /// </summary>
        public IEnumerable<string> Routes { get; set; }

    }
}
