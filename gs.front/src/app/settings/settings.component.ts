import { Component, OnInit } from '@angular/core';
import {OrganizationSettings} from "../models/settings/organization-settings";
import {SettingsService} from "../services/settings/settings.service";

@Component({
  selector: 'app-settings',
  templateUrl: './settings.component.html',
  styleUrls: ['./settings.component.css']
})
export class SettingsComponent implements OnInit {

  settings: OrganizationSettings;
  isLoading: boolean;

  constructor(private settingsService: SettingsService) { }

  ngOnInit() {
    this.Load();
  }

  private Load(){
    this.settings = new OrganizationSettings();
    this.isLoading = true;
    this.settingsService.GetOrganizationSettings().subscribe(response => {
      this.isLoading = false;
    });
  }
}
