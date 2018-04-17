import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {AuthService} from '../../auth/auth.service';
import {catchError} from 'rxjs/operators';
import {Observable} from 'rxjs/Observable';
import {GetStoresResponse} from '../../../models/dicts/stores/get-stores-response';
import {environment} from '../../../../environments/environment';
import {RemoveStoreRequest} from '../../../models/dicts/stores/remove-store-request';
import {GetStoreDetailsRequest} from '../../../models/dicts/stores/get-store-details-request';
import {AddStoreRequest} from '../../../models/dicts/stores/add-store-request';
import {SaveStoreDetailsRequest} from '../../../models/dicts/stores/save-store-details-request';
import {AddStoreResponse} from '../../../models/dicts/stores/add-store-response';
import {GetStoreDetailsResponse} from '../../../models/dicts/stores/get-store-details-response';

@Injectable()
export class StoresService {

  private getStoresUrl = environment.apiServerAddress + '/api/resellers/stores/list/getAll';
  private addStoresUrl = environment.apiServerAddress + '/api/resellers/stores/list/add';
  private removeUrl = environment.apiServerAddress + '/api/resellers/stores/list/remove';
  private getDetailsUrl = environment.apiServerAddress + '/api/resellers/stores/list/getDetails';
  private saveDetailsUrl = environment.apiServerAddress + '/api/resellers/stores/list/save';

  constructor(private http: HttpClient,
              private authService: AuthService) { }

  public GetStores(): Observable<GetStoresResponse> {
    return this.http.post<GetStoresResponse>(this.getStoresUrl, {}).pipe(
      catchError(this.authService.handleError<GetStoresResponse>('GetStores'))
    );
  }

  Remove(request: RemoveStoreRequest): Observable<any> {
    return this.http.post(this.removeUrl, request).pipe(
      catchError(this.authService.handleError('Remove'))
    );
  }

  GetStoreDetails(request: GetStoreDetailsRequest): Observable<GetStoreDetailsResponse> {
    return this.http.post<GetStoreDetailsResponse>(this.getDetailsUrl, request).pipe(
      catchError(this.authService.handleError<GetStoreDetailsResponse>('GetStoreDetails'))
    );
  }

  AddStore(request: AddStoreRequest): Observable<AddStoreResponse> {
    return this.http.post<AddStoreResponse>(this.addStoresUrl, request).pipe(
      catchError(this.authService.handleError<AddStoreResponse>('AddStore'))
    );
  }

  SaveStoreDetails(request: SaveStoreDetailsRequest): Observable<any> {
    return this.http.post(this.saveDetailsUrl, request).pipe(
      catchError(this.authService.handleError<any>('SaveStoreDetails'))
    );
  }
}
