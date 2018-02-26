using System;
using System.Collections.Generic;
using System.Linq;
using gs.api.storage.model;
using gs.api.storage.repositories.interfaces;
using JetBrains.Annotations;

namespace gs.api.storage.repositories
{
    public class OrganizationsRepository : IOrganizationsRepository
    {
        private readonly Context Context;

        public OrganizationsRepository([NotNull] Context context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddOrganization(Organization source)
        {
            Context.Add(source);
            Context.SaveChanges();
        }

        public IEnumerable<Organization> GetAll()
        {
            return Context.Organizations.ToList();
        }
    }
}