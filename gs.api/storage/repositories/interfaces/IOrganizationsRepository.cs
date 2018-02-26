using System.Collections.Generic;
using gs.api.storage.model;

namespace gs.api.storage.repositories.interfaces
{
    public interface IOrganizationsRepository
    {
        void AddOrganization(Organization source);
        IEnumerable<Organization> GetAll();
    }
}