import {OrganizationSettings} from './organization-settings';

export class SaveOrganizationSettingsRequest {
  settings: OrganizationSettings;


  constructor(settings: OrganizationSettings) {
    this.settings = settings;
  }
}
