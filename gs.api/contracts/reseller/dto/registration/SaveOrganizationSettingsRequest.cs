﻿using System.Runtime.Serialization;

namespace gs.api.contracts.reseller.dto.registration
{
    [DataContract]
    public class SaveOrganizationSettingsRequest : BaseRequest
    {
        public SaveOrganizationSettingsRequest(OrganizationSettings settings)
        {
            Settings = settings;
        }

        [DataMember(IsRequired = true)]
        public OrganizationSettings Settings { get; set; }
    }
}