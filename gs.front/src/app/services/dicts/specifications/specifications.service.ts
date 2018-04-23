import { Injectable } from '@angular/core';
import {AuthService} from "../../auth/auth.service";
import {Observable} from "rxjs/Observable";
import {environment} from "../../../../environments/environment";
import {HttpClient} from "@angular/common/http";
import {catchError} from "rxjs/operators";
import {GetResponse} from "../../../models/dicts/specifications/get-response";
import {AddRequest} from "../../../models/dicts/specifications/add-request";
import {AddResponse} from "../../../models/dicts/specifications/add-response";
import {RemoveRequest} from "../../../models/dicts/specifications/remove-request";
import {GetDetailsRequest} from "../../../models/dicts/specifications/get-details-request";
import {GetDetailsResponse} from "../../../models/dicts/specifications/get-details-response";
import {SaveRequest} from "../../../models/dicts/specifications/save-request";

@Injectable()
export class SpecificationsService {

  private getUrl = environment.apiServerAddress + '/api/resellers/specifications/list/getAll';
  private addUrl = environment.apiServerAddress + '/api/resellers/specifications/list/add';
  private removeUrl = environment.apiServerAddress + '/api/resellers/specifications/list/remove';
  private getDetailsUrl = environment.apiServerAddress + '/api/resellers/specifications/list/getDetails';
  private saveDetailsUrl = environment.apiServerAddress + '/api/resellers/specifications/list/save';

  constructor(private http: HttpClient,
              private authService: AuthService) { }

  public Get(): Observable<GetResponse> {
    return this.http.post<GetResponse>(this.getUrl, {}).pipe(
      catchError(this.authService.handleError<GetResponse>('Get'))
    );
  }

  public Add(request: AddRequest): Observable<AddResponse> {
    return this.http.post<AddResponse>(this.addUrl, request).pipe(
      catchError(this.authService.handleError<AddResponse>('Add'))
    );
  }

  public Remove(request: RemoveRequest): Observable<any> {
    return this.http.post<RemoveRequest>(this.removeUrl, request).pipe(
      catchError(this.authService.handleError<RemoveRequest>('Remove'))
    );
  }

  public GetDetails(request: GetDetailsRequest): Observable<GetDetailsResponse> {
    return this.http.post<GetDetailsResponse>(this.getDetailsUrl, request).pipe(
      catchError(this.authService.handleError<GetDetailsResponse>('GetDetails'))
    );
  }

  public SaveDetails(request: SaveRequest): Observable<any> {
    return this.http.post(this.saveDetailsUrl, request).pipe(
      catchError(this.authService.handleError<any>('SaveDetails'))
    );
  }
}
