import { Injectable } from '@angular/core';
import {environment} from '../../../environments/environment';
import {AuthService} from '../auth/auth.service';
import {HttpClient} from '@angular/common/http';
import {catchError} from 'rxjs/operators';
import {Observable} from 'rxjs/Observable';
import {GetOrganizationSettingsResponse} from '../../models/settings/get-organization-settings-response';
import {SaveOrganizationSettingsRequest} from '../../models/settings/save-organization-settings-request';

@Injectable()
export class SettingsService {

  private getSettingsUrl = environment.apiServerAddress + '/api/resellers/registration/getOrganizationSettings';
  private saveSettingsUrl = environment.apiServerAddress + '/api/resellers/registration/saveOrganizationSettings';

  constructor(private http: HttpClient,
              private authService: AuthService) { }

  public GetOrganizationSettings(): Observable<GetOrganizationSettingsResponse> {
    return this.http.post<GetOrganizationSettingsResponse>(this.getSettingsUrl, {}).pipe(
      catchError(this.authService.handleError<GetOrganizationSettingsResponse>('GetOrganizationSettings'))
    );
  }

  public SaveOrganizationSettings(request: SaveOrganizationSettingsRequest): Observable<any> {
    return this.http.post<SaveOrganizationSettingsRequest>(this.saveSettingsUrl, request).pipe(
      catchError(this.authService.handleError<SaveOrganizationSettingsRequest>('SaveOrganizationSettings'))
    );
  }
}
