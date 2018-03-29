using System;
using System.ComponentModel;
using gs.api.storage;
using gs.api.storage.model;
using JetBrains.Annotations;

namespace gs.api.infrastructure
{
    public class CallContext
    {
        private bool _initialized;
        private readonly object _initSyncRoot = new object();

        public Guid CorrelationId { get; private set; }
        public Lazy<(Organization Organization, User User)> OrganizationAndUser { get; private set; }
        public long CurrentOrganizationId => OrganizationAndUser.Value.Organization.OrganizationId;
        
        public Context DbContext { get; private set; }

        internal void Initialize(Guid correlationId, 
            [NotNull] Context dbContext, 
            [NotNull] Lazy<(Organization Organization, User User)> organizationAndUser)
        {
            if (dbContext == null) throw new ArgumentNullException(nameof(dbContext));
            if (organizationAndUser == null) throw new ArgumentNullException(nameof(organizationAndUser));
            if (_initialized)
                throw new InvalidOperationException("CallContext already initialized!");
            
            if (!_initialized)
            {
                lock (_initSyncRoot)
                {
                    if (!_initialized)
                    {
                        CorrelationId = correlationId;
                        DbContext = dbContext;
                        OrganizationAndUser = organizationAndUser;
                        _initialized = true;
                    }
                }
            }
        }
    }
}