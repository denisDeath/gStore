import { Injectable } from '@angular/core';
import {environment} from "../../../environments/environment";
import {AuthService} from "../auth/auth.service";
import {HttpClient} from "@angular/common/http";
import {catchError} from "rxjs/operators";
import {GetStoresResponse} from "../../models/dicts/stores/get-stores-response";
import {Observable} from "rxjs/Observable";
import {GetOrganizationSettingsResponse} from "../../models/settings/get-organization-settings-response";

@Injectable()
export class SettingsService {

  private getSettingsUrl = environment.apiServerAddress + '/api/resellers/registration/getOrganizationSettings';

  constructor(private http: HttpClient,
              private authService: AuthService) { }

  public GetOrganizationSettings(): Observable<GetOrganizationSettingsResponse> {
    return this.http.post<GetOrganizationSettingsResponse>(this.getSettingsUrl, {}).pipe(
      catchError(this.authService.handleError<GetOrganizationSettingsResponse>('GetOrganizationSettings'))
    );
  }

}
